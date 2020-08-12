using BankRUs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static System.Console;

namespace BankRUs
{
    class Program
    {
        // Vi behöver skapa en instans av DbContext-klassen.
        static ILoggerFactory MyLoggerFactory = LoggerFactory.Create(DbContextOptionsBuilder => { DbContextOptionsBuilder.AddConsole();});

        static BankRUsContext context = new BankRUsContext(MyLoggerFactory);
        static void Main(string[] args)
        {
            bool isShouldNotExit = true;

            while (isShouldNotExit)
            {
                Clear(); 

                WriteLine("1. Registrera kund");

                WriteLine("2. Visa kunder");

                WriteLine("3. Öppna konto");

                WriteLine("4. Visa kund");

                WriteLine("5. Avsluta");

                ConsoleKeyInfo keyPressed = ReadKey(true);

                Clear();

                switch (keyPressed.Key)
                { 
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                    RegisterCustomer();

                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        DisplayCustomers();

                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:

                        OpenAccount();

                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:

                        DisplayCustomer();

                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:

                        isShouldNotExit = false;

                        break;                    
                }
            }
        }

        private static void DisplayCustomers()
        {
            // TODO: Ersätt new List<Customer>() med lista av kunder som
            // laddas in från databasen.

            List<Customer> customerLIst = context.Customer.ToList();

            Write("Namn".PadRight(20, ' '));
            WriteLine("Personnummer");
            WriteLine("--------------------------------");

            foreach (Customer customer in customerLIst)
            {
                string fullName = $"{customer.FirstName} {customer.LastName}";

                Write(fullName.PadRight(20, ' '));
                WriteLine(customer.SocialSecurityNumber);
            }

            ReadKey(true);

            Clear();
        
        }

        private static void OpenAccount()
        {
            WriteLine("Personnummer: ");

            string socialSecurityNumber = ReadLine();

            // Här har vi reference till customer från
            // vår context.Customer 
            Customer customer = context.Customer
                .FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);

            Clear();

            if ( customer != null)
            {
                // TODO: Skapa konto

                Write("Kontonummer: ");

                string accountNumber = ReadLine();

                Account account = new Account(accountNumber);

                // Vi har en instance/objekt till customer och
                // den har samling med Accounts och den samling har 
                // Add metod och vi ta lägga in vår account där. 
                customer.Accounts.Add(account);

                context.SaveChanges();

                WriteLine("Konto skapat");
            
            }
            else
            {
                
                WriteLine("Kund finns ej");

               
            }
           
            Thread.Sleep(2000);
        }

        private static void DisplayCustomer()
        {
            WriteLine("Personnummer: ");

            string socialSecurityNumber = ReadLine();

            // Här har vi reference till customer från
            // vår context.Customer 
            Customer customer = context.Customer
                .Include(x => x.Accounts)
                .Include(x => x.Address)
                .FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);

            Clear();

            if (customer != null)
            {
                WriteLine($"Namn: {customer.FirstName}{ customer.LastName}");

                WriteLine($"Address: {customer.Address.Street} {customer.Address.City} {customer.Address.PostCode}");
                WriteLine();

                Write("kontor:".PadRight(15, ' '));
                WriteLine("Balance");
                WriteLine("-------------------------------------");

                foreach (Account account in customer.Accounts)
                {
                    Write(account.AccountNumber.PadRight(15, ' '));
                    WriteLine(account.Balance);
                }

                ReadKey(true);

            }
            else
            {

                WriteLine("Kund finns ej");

                Thread.Sleep(2000);
            }         

        }

        private static void RegisterCustomer()
        {
            bool isCorrect = true;

            Customer customer = null;

            do
            {
                Clear();

                Write("FirstName: ");

                string firstName = ReadLine();

                Write("LastName: ");

                string lastName = ReadLine();

                Write("Social security number: ");

                string socialSecurityNumber = ReadLine();

                Write("Street: ");

                string street = ReadLine();

                Write("City: ");

                string city = ReadLine();

                Write("Postal address: ");

                string postCode = ReadLine();
                
                WriteLine();

                WriteLine("Är detta korrekt? (J)a eller (N)ej");

                ConsoleKeyInfo keyPressed;

                bool isValidKey = false;

                do
                {
                    keyPressed = ReadKey(true);

                    isValidKey = keyPressed.Key == ConsoleKey.J ||
                        keyPressed.Key == ConsoleKey.N;

                } while (!isValidKey);

                if (keyPressed.Key == ConsoleKey.J)
                {
                    Address address = new Address(street, city, postCode);
                    
                    customer = new Customer(
                        firstName, 
                        lastName, 
                        socialSecurityNumber,
                        address                        
                        );

                    SaveCustomer(customer);

                    Clear();

                    WriteLine("Kund registrerad");

                    Thread.Sleep(2000);

                    isCorrect = false;
                }

                Clear();

            } while (isCorrect);            

        }

        private static void SaveCustomer(Customer customer)
        {
            // Vi har vi detta inte sparat ner vår customer ännu.
            context.Customer.Add(customer);

            // Det är först när vi anropar SaveChanges() som våra ändringar sparas till
            // databasen.
            context.SaveChanges();
        }
    }
}
