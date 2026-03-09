using core.Entities;
using core.interfaces;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;

namespace inftastructer.Repository.Services
{
    public  class PaymentService: IPaymentService
    {
        private readonly ICustomerBasketService customerBasket;
        private readonly IGenricRepo<DeliveryMethod> _deliveryRepo;

        public PaymentService(ICustomerBasketService cartRepo,
                              IGenricRepo<DeliveryMethod> deliveryRepo)
        {
            customerBasket = cartRepo;
            _deliveryRepo = deliveryRepo;
        }

        public async Task<string> CreateOrUpdatePaymentIntent(string userId, int deliveryMethodId)
        {
            var cart = await customerBasket.GetBasketAsync(
                userId);//GetCartByUserIdAsync(userId);
            if (cart == null) throw new Exception("Cart not found");

            var deliveryMethod = await _deliveryRepo.GetByIdAsync(deliveryMethodId);
            if (deliveryMethod == null) throw new Exception("Delivery method not found");

            var subtotal = cart.Items.Sum(i => i.Price * i.Quantity);
            var total = subtotal + deliveryMethod.Price;

            StripeConfiguration.ApiKey = "YOUR_SECRET_KEY";

            var service = new PaymentIntentService();

            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(total * 100),
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" }
            };

            var intent = await service.CreateAsync(options);

            //PaymentIntentId = intent.Id;
            cart.ClientSecret = intent.ClientSecret;

            await _cartRepo.UpdateCartAsync(cart);

            return intent.ClientSecret;
        }
    }
}
