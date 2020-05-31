using System;
namespace OrderAccessors.Entities
{
    public class Customer
    {
        public Customer()
        {
        }

        public int Id { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string CustomerNumber { get; set; }

        public string CustomerName { get; set; }
    }
}
