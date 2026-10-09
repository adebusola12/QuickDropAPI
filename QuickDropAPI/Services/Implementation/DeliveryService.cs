using Newtonsoft.Json;
using QuickDropAPI.Models;
using QuickDropAPI.Repository.Interface;
using QuickDropAPI.Services.Interface;
using System.Reflection.Metadata.Ecma335;

namespace QuickDropAPI.Services.Implementation
{
    public class DeliveryService: IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        
        public DeliveryService (IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<ApiResponseModel> CreateDeliveryAsync(Delivery delivery)
        {
            await _deliveryRepository.AddAsync(delivery);
            await _deliveryRepository.SaveChangesAsync();

            return new ApiResponseModel
            {
                StatusCode = 201,
                Message = "Delivery created successfully",
                Body = JsonConvert.SerializeObject(delivery)
            };
        }

        public async Task<ApiResponseModel> GetDeliveryByIdAsync(int id)
        {
            Delivery delivery = await _deliveryRepository.GetByIdAsync(id);

            if (delivery == null)
            {
                return new ApiResponseModel
                {
                    StatusCode = 404,
                    Message = "Delivery not found."
                };
            }

            return new ApiResponseModel
            {
                StatusCode = 201,
                Message = "Delivery retrieved successfully",
                Body = JsonConvert.SerializeObject(delivery)
            };
        }


        public async Task<ApiResponseModel> GetUserDeliveriesAsync(Guid userId)
        {
            List<Delivery> deliveries = await _deliveryRepository.GetByUserIdAsync(userId);

            if(deliveries ==null || deliveries.Count ==0)
            {
                return new ApiResponseModel

                {
                    StatusCode = 404,
                    Message = "No delivery found for this user"
                };
            }

            return new ApiResponseModel
            {
                StatusCode = 200,
                Message = "Deliveries retrieved successfully",
                Body = JsonConvert.SerializeObject(deliveries)
            };
        }

        public async Task<ApiResponseModel> UpdateDeliveryAsync(Delivery delivery)
        {
            Delivery existingDelivery = await _deliveryRepository.GetByIdAsync(delivery.Id);

            if (existingDelivery == null)
            {
                return new ApiResponseModel
                {
                    StatusCode = 404,
                    Message = "Delivery not found"
                };
            }

            existingDelivery.PickupAddress = delivery.PickupAddress;
            existingDelivery.DeliveryAddress = delivery.DeliveryAddress;
            existingDelivery.RecipientName = delivery.RecipientName;
            existingDelivery.RecipientPhone = delivery.RecipientPhone;
            existingDelivery.PackageDescription = delivery.PackageDescription;
            existingDelivery.DeliveryFee = delivery.DeliveryFee;
            existingDelivery.Status = delivery.Status;

            await _deliveryRepository.UpdateAsync(existingDelivery);

            await _deliveryRepository.SaveChangesAsync();

            return new ApiResponseModel
            {
                StatusCode = 200,
                Message = "Delivery updated successfully.",
                Body = JsonConvert.SerializeObject(existingDelivery)
            };

        }

        public async Task<ApiResponseModel> DeleteDeliveryAsync(int id)
        {
            Delivery delivery = await _deliveryRepository.GetByIdAsync(id);
            
            if(delivery == null)
            {
                return new ApiResponseModel
                {
                    StatusCode = 404,
                    Message = "Delivery not found"
                };
            }

            await _deliveryRepository.DeleteAsync(delivery);
            await _deliveryRepository.SaveChangesAsync();

            return new ApiResponseModel
            {
                StatusCode = 200,
                Message = "Delivery Deleted Successfully"
            };
        }
    }
}
