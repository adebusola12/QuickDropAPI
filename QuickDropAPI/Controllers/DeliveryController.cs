using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickDropAPI.Logic.Interface;
using QuickDropAPI.Models;

namespace QuickDropAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryLogic _deliveryLogic;

        public DeliveryController (IDeliveryLogic deliveryLogic)
        {
            _deliveryLogic = deliveryLogic;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDelivery(Delivery delivery)
        {
            ApiResponseModel response = await _deliveryLogic.CreateDeliveryHandler(delivery);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeliveryById(int id)
        {
            ApiResponseModel response = await _deliveryLogic.GetDeliveryByIdHandler(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserDeliveries(Guid userId)
        {
            ApiResponseModel response = await _deliveryLogic.GetUserDeliveriesHandler(userId);

            return StatusCode(response.StatusCode, response);

        }

        [HttpPut("{id}")]
        public async Task <IActionResult> UpdateDelivery(int id, Delivery delivery)
        {
            ApiResponseModel response = await _deliveryLogic.UpdateDeliveryHandler(delivery);

            return StatusCode(response.StatusCode, response);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            ApiResponseModel response = await _deliveryLogic.DeleteDeliveryHandler(id);
            return StatusCode(response.StatusCode, response);
        }

    }
}
