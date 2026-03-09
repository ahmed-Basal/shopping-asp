using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace core.Entities
{
    public class Order : BaseEntities<int>
    {
        public string BuyerEmail { get; set; }

        public int DeliveryMethodId { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }

        public Address ShippingAddress { get; set; }

        public decimal Subtotal { get; set; }

        public string PaymentIntentId { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public ICollection<orderitem> Items { get; set; } = new List<orderitem>();

        public decimal GetTotal() => Subtotal + DeliveryMethod.Price;
    }
}
