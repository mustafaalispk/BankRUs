using System;
using System.Collections.Generic;
using System.Text;

namespace BankRUs.Domain
{
    class Customer
    {
        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set;  }
        public string SocialSecurityNumber { get; protected set; }
        public Address Address { get; protected set; }

        public Customer(string firstName, string lastName, string socialSecurityNumber)
        { 
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;         
        }

        public Customer(string firstName, string lastName, string socialSecurityNumber, Address address)
            : this(firstName,lastName,socialSecurityNumber)
        {
              Address = address;
        }
                     
    }
}
