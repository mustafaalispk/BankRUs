using System;
using System.Collections.Generic;
using System.Text;

namespace BankRUs.Domain
{
    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        public Customer(string firstName, string lastName, string socialSecurityNumber, string street, string city, string postCode)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
            Street = street;
            City = city;
            PostCode = postCode;
        }
        public Customer(int id,string firstName, string lastName, string socialSecurityNumber, string street, string city, string postCode)
        : this(firstName,lastName,socialSecurityNumber,street,city,postCode)
        {
            Id = id;
        }
                     
    }
}
