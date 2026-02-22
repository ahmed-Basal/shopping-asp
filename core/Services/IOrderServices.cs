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
        Task<orders> CreateOrdersAsync(orderDto orderDTO, string BuyerEmail);
        Task<IReadOnlyList<orderToReturn>> GetAllOrdersForUserAsync(string BuyerEmail);
        Task<orderToReturn> GetOrderByIdAsync(int   id, string BuyerEmail);
         Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();

    }
}
