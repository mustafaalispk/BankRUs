using BankRUs.Domain;
using System;
using static System.Console;

namespace BankRUs
{
    class Program
    {
        // Vi behöver skapa en instans av DbContext-klassen.
        static BankRUsContext context = new BankRUsContext();
        static void Main(string[] args)
        {
            bool isShouldNotExit = true;

            while (isShouldNotExit)
            {
                WriteLine("1. Registrera kund");

                WriteLine("2. Avsluta");

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

                        isShouldNotExit = false;

                        break;
                }
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
                    customer = new Customer(
                        firstName, 
                        lastName, 
                        socialSecurityNumber, 
                        street, 
                        city, 
                        postCode);

                    SaveCustomer(customer);

                    isCorrect = false;
                }

            } while (isCorrect);

            Clear();

        }

        private static void SaveCustomer(Customer customer)
        {
            // Vi använder EntityFrame work att spara våra kund i databasen.
            // Den är samma som git add.
            context.Customer.Add(customer);

            // Här pratar vi med databasen
            // Den är samma som git commit
            context.SaveChanges();
        }
    }
}
