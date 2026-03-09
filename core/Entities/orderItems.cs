namespace core.Entities
{
    public class orderitem:BaseEntities<int>
    {
        public orderitem()
        {
        }

        public orderitem(int productItemId, string image, string productName, decimal price, int quantity)
        {
            ProductItemId = productItemId;
           this. image = image;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }

        public orderitem(int id, List<photo>? photos, string name, decimal newPrice, int qunatity)
        {
            Id = id;
        }

        public int ProductItemId { get; set; }
        public string image { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}