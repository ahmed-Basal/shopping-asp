using core.Dto;
using core.Entities;
using core.Services;
using inftastructer.Repository.Services;
using MailKit.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;
using StackExchange.Redis;
using System.Security.Claims;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices orderServices;

        public OrdersController(IOrderServices orderServices)
        {
            this.orderServices = orderServices;
        }

        [HttpPost("create-order")]
        public async Task<ActionResult> create(orderDto orderDTO)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            orders order = await orderServices.CreateOrdersAsync(orderDTO, email);

            return Ok(order);
        }
        [HttpGet("get-orders-for-user")]
        public async Task<ActionResult> getorders()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var orders = await orderServices.GetAllOrdersForUserAsync(email);
            return Ok(orders);
        }
        [HttpGet("get-order-by-id/{id}")]
        public async Task<ActionResult> getorderbyid(int id)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var order = await orderServices.GetOrderByIdAsync(id, email);
            return Ok(order);
        }
        [HttpGet("get-delivery-methods")]
        public async Task<ActionResult> getdeliverymethods()
        {
            var deliveryMethods = await orderServices.GetDeliveryMethodsAsync();
            return Ok(deliveryMethods);
        }
    }
}