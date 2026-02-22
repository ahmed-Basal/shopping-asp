using core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace core.Dto
{
    public  record orderToReturn
    {
        public int Id { get; set; }
        public string buyeremail { get; set; }
        public decimal subtotal { get; set; }
        public decimal total { get; set; }
        public DateTime orderDate { get; set; }
        public shoppingAddress address { get; set; }

        public DeliveryMethod deliveryMethod { get; set; }
        public IReadOnlyList<orderitemDto> orderItems { get; set; }
        public statues statues { get; set; } = statues.pending;
    }
    public record orderitemDto
    {

        public int ProductItemId { get; set; }
        public string MainImage { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
