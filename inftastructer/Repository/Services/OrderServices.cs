using AutoMapper;
using core.Dto;
using core.Entities;
using core.interfaces;
using core.Services;
using inftastructer.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace inftastructer.Repository.Services
{
    public class OrderServices : IOrderServices
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;
        public IMapper _mapper;
        public OrderServices(IUnitOfWork unitOfWork, AppDbContext context,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            this._context = context;
        }
        public async Task<orders> CreateOrdersAsync(orderDto orderDTO, string BuyerEmail)
        {
            var basket = await _unitOfWork.basketyRepository.GetBasketAsync(orderDTO.basketId);

            List<orderitem> orderItems = new List<orderitem>();

            foreach (var item in basket.basketItems)
            {
                var Product = await _unitOfWork.productRepository.GetByIdAsync(item.Id);
                var orderItem = new orderitem
                    (Product.Id, item.Image, Product.Name, item.Price, item.Qunatity);
                orderItems.Add(orderItem);

            }
            var deliverMethod = await _context.deliveryMethods.FirstOrDefaultAsync(m => m.Id == orderDTO.deliveryMethodId);

            var subTotal = orderItems.Sum(m => m.Price * m.Quantity);

            var ship = _mapper.Map<shoppingAddress>(orderDTO.shipaddressDto);

           

           

            var order = new
                orders(BuyerEmail, subTotal, ship, deliverMethod, orderItems, basket.PaymentIntentId);

            await _context.orders.AddAsync(order);
            await _context.SaveChangesAsync();
          
            return order;
        }

        public async Task<IReadOnlyList<orderToReturn>> GetAllOrdersForUserAsync(string BuyerEmail)
        {
            var orders = await _context.orders
            .Where(m => m.buyeremail == BuyerEmail)
            .Include(inc => inc.orderItems)
            .Include(inc => inc.deliveryMethod)
              .ToListAsync();

            var result = _mapper.Map<IReadOnlyList<orderToReturn>>(orders);
            return result;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        
        =>    await _context.deliveryMethods.AsNoTracking().ToListAsync();





        public async Task<orderToReturn> GetOrderByIdAsync(int id, string BuyerEmail)
        {
            var order = await _context.orders
                .Where(m => m.Id == id && m.buyeremail == BuyerEmail)
                .Include(inc => inc.deliveryMethod)
                .FirstOrDefaultAsync();

            if (order == null) return null;

            var result = _mapper.Map<orderToReturn>(order);
            return result;
        }
    }
}

