using QuickDropAPI.Models;
namespace QuickDropAPI.Logic.Interface
{
    public interface IDeliveryLogic
    {
        Task<ApiResponseModel> CreateDeliveryHandler(Delivery delivery);
        Task<ApiResponseModel> GetDeliveryByIdHandler(int id);
        Task<ApiResponseModel> GetUserDeliveriesHandler(Guid UserId);
        Task<ApiResponseModel> UpdateDeliveryHandler(Delivery delivery);
        Task<ApiResponseModel> DeleteDeliveryHandler(int id);

    }
}
