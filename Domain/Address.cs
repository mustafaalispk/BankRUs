using System;
using System.Collections.Generic;
using System.Text;

namespace BankRUs.Domain
{
    class Address
    {
        public int Id { get; protected set; } // AddressId
        public string Street { get; protected set; }
        public string City { get; protected set; }
        public string PostCode { get; protected set; }          
        public int CustomerId { get; protected set; }
        public Customer Customer { get; protected set; }
       
        public Address(string street, string city, string postCode)
        {
            Street = street;
            City = city;
            PostCode = postCode;           
        }
    }
}
