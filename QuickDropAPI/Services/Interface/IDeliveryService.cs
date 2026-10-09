using QuickDropAPI.Models;

namespace QuickDropAPI.Services.Interface
{
    public interface IDeliveryService
    {
        Task<ApiResponseModel> CreateDeliveryAsync(Delivery delivery);
        Task<ApiResponseModel> GetDeliveryByIdAsync(int id);
        Task<ApiResponseModel> GetUserDeliveriesAsync(Guid userId);
        Task<ApiResponseModel> UpdateDeliveryAsync(Delivery delivery);
        Task<ApiResponseModel> DeleteDeliveryAsync(int id);
    }
}
