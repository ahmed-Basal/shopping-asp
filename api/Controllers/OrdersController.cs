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
using Stripe.Climate;
using System.Security.Claims;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderServices _orderService;

        public OrdersController(IOrderServices orderService)
        {
            _orderService = orderService;
        }

        private string GetUserEmail()
        {
            return User?.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value
                ?? User?.FindFirst("email")?.Value;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] orderDto dto)
        {
            var email = GetUserEmail();
            if (email == null)
                return Unauthorized(new { message = "Invalid token" });

            var order = await _orderService.CreateOrderAsync(dto, email);

            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }


        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] orderDto dto)
        {
            var order = await _orderService.UpdateOrderAsync(id, dto);

            return Ok(order);
        }


        [HttpGet("details/{id:int}", Name = "GetOrderByIdRoute")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var email = GetUserEmail();
            if (email == null)
                return Unauthorized();

            var order = await _orderService.GetOrderByIdAsync(id, email);

            if (order == null)
                return NotFound(new { message = "Order not found" });

            return Ok(order);
        }


        [HttpGet("my-orders")]
        public async Task<IActionResult> GetMyOrders()
        {
            var email = GetUserEmail();
            if (email == null)
                return Unauthorized();

            var orders = await _orderService.GetAllOrdersForUserAsync(email);

            return Ok(orders);
        }

     
        [HttpGet("delivery-methods")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDeliveryMethods()
        {
            var methods = await _orderService.GetDeliveryMethodsAsync();
            return Ok(methods);
        }


    }
}