using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace core.Entities
{
    public  class orders: BaseEntities<int>
    {
        private object deliveryMethod1;
        private List<orderitem> items;

        public orders() { }

        public orders(string buyerEmail, decimal subtotal, object deliveryMethod1, List<orderitem> items)
        {
            buyeremail = buyerEmail;
            this.subtotal = subtotal;
            this.deliveryMethod1 = deliveryMethod1;
            this.items = items;
        }

        public orders(string buyeremail, decimal subtotal,  shoppingAddress address, DeliveryMethod deliveryMethod, IReadOnlyList<orderitem> orderItems)
        {
            this.buyeremail = buyeremail;
            this.subtotal = subtotal;
          
            this.address = address;
            this.deliveryMethod = deliveryMethod;
            this.orderItems = orderItems;
          
        }

        public orders(string buyeremail, decimal subtotal, shoppingAddress address, DeliveryMethod deliveryMethod, IReadOnlyList<orderitem> orderItems, string paymentIntentId) : this(buyeremail, subtotal, address, deliveryMethod, orderItems)
        {
        }

        public string buyeremail { get; set; }
        public decimal subtotal { get; set; }
        public decimal total { get { return Gettotal(); } }
        public DateTime orderDate { get; set; }= DateTime.Now;
        public shoppingAddress address { get; set; }   

        public DeliveryMethod deliveryMethod { get; set; }
        public IReadOnlyList<orderitem> orderItems { get; set; }
        public statues statues { get; set; }=statues.pending;
        public decimal Gettotal()
        {
            return  subtotal + deliveryMethod.Price;
        }
    }
}
