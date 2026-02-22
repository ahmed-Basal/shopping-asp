namespace core.Entities
{
    public class shoppingAddress : BaseEntities<int>
    {
        public shoppingAddress() { }
        public shoppingAddress(string firstName, string lastName, string city, string zipCode, string street, string state)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            ZipCode = zipCode;
            Street = street;
            State = state;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string State { get; set; }

    }
}