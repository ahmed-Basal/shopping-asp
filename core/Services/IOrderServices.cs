using core.Dto;
using core.Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace core.Services
{
    public  interface  IOrderServices
    {
       
        Task<Entities.Order> CreateOrderAsync(orderDto orderDTO, string BuyerEmail);

        
        Task<Entities.Order> UpdateOrderAsync(int orderId, orderDto orderDTO);

   
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();

        
        Task<orderToReturn> GetOrderByIdAsync(int id, string BuyerEmail);

        Task<IReadOnlyList<orderToReturn>> GetAllOrdersForUserAsync(string BuyerEmail);

    }
}
