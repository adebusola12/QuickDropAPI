using QuickDropAPI.Logic.Interface;
using QuickDropAPI.Models;
using QuickDropAPI.Services.Interface;
namespace QuickDropAPI.Logic.Implementation
{
    public class DeliveryLogic : IDeliveryLogic
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryLogic(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        public async Task<ApiResponseModel> CreateDeliveryHandler(Delivery delivery)
        {
            return await _deliveryService.CreateDeliveryAsync(delivery);
        }

        public async Task<ApiResponseModel> GetDeliveryByIdHandler(int id)
        {
            return await _deliveryService.GetDeliveryByIdAsync(id);
        }

        public async Task<ApiResponseModel> GetUserDeliveriesHandler(Guid userId)
        {
            return await _deliveryService.GetUserDeliveriesAsync(userId);
        }

        public async Task<ApiResponseModel> UpdateDeliveryHandler(Delivery delivery)
        {
            return await _deliveryService.UpdateDeliveryAsync(delivery);
        }

        public async Task<ApiResponseModel> DeleteDeliveryHandler(int id)
        {
            return await _deliveryService.DeleteDeliveryAsync(id);
        }

    }
}
