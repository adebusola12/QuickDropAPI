using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using QuickDropAPI.Models;
using QuickDropAPI.Services.Interface;

namespace QuickDropAPI.Services.Implementation
{
    public class CustomService : ICustomService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _httpClient;

        public CustomService(
            IHttpClientFactory httpClientFactory,
            HttpClient httpClient)
        {
            _httpClientFactory =
                httpClientFactory ??
                throw new ArgumentNullException(nameof(httpClientFactory));

            _httpClient =
                httpClient ??
                throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<ApiResponseModel> MakeHttpCall(
            object request,
            string baseURL,
            string requestURL,
            HttpMethod method,
            Dictionary<string, string> headers = null)
        {
            // ADDED: Put the HTTP operation inside try
            try
            {
                ApiResponseModel apiResponse = new ApiResponseModel();
                HttpResponseMessage response = new HttpResponseMessage();

                _httpClient = _httpClientFactory.CreateClient();

                _httpClient.BaseAddress = new Uri(baseURL);

                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                _httpClient.Timeout = TimeSpan.FromSeconds(180);

                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> header in headers)
                    {
                        _httpClient.DefaultRequestHeaders.Add(
                            header.Key,
                            header.Value);
                    }
                }

                if (method == HttpMethod.Post)
                {
                    string jsonContent =
                        JsonConvert.SerializeObject(request);

                    HttpRequestMessage httpRequest =
                        new HttpRequestMessage(
                            HttpMethod.Post,
                            requestURL);

                    httpRequest.Content =
                        new StringContent(
                            jsonContent,
                            Encoding.UTF8,
                            "application/json");

                    response =
                        await _httpClient.SendAsync(httpRequest);
                }
                else if (method == HttpMethod.Get)
                {
                    response =
                        await _httpClient.GetAsync(requestURL);
                }
                else
                {
                    throw new NotSupportedException(
                        $"HTTP method {method} is not supported.");
                }

                apiResponse.Body =
                    await response.Content.ReadAsStringAsync();

                apiResponse.StatusCode =
                    (int)response.StatusCode;

                // ADDED: Give a message based on the response
                if (response.IsSuccessStatusCode)
                {
                    apiResponse.Message = "Request successful.";
                }
                else
                {
                    apiResponse.Message =
                        $"Third-party API returned status code {(int)response.StatusCode}.";
                }

                return apiResponse;
            }

            // ADDED: Handles timeout
            catch (TaskCanceledException)
            {
                return new ApiResponseModel
                {
                    StatusCode = 408,
                    Message = "The third-party API request timed out."
                };
            }

            // ADDED: Handles connection/server/network problems
            catch (HttpRequestException)
            {
                return new ApiResponseModel
                {
                    StatusCode = 503,
                    Message = "The third-party API is currently unavailable."
                };
            }

            // ADDED: Handles unexpected errors
            catch (Exception ex)
            {
                return new ApiResponseModel
                {
                    StatusCode = 500,
                    Message = $"An unexpected error occurred: {ex.Message}"
                };
            }
        }
    }
}