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
        
        // Här har vi en till en relationen mellan Address till Customer.
        public Address Address { get; protected set; }

        // Ifall att det finns en konto så vi vill inte att account
        // ska vara null utan att den skapa upp en töm lista -->  new List<Account>()
        // Här har vi en till många relationen mellan Account till Customer. det menar att
        // en kund har en konto eller flera konto
        public List<Account> Accounts { get; protected set; } = new List<Account>();
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
