using System;
using System.Collections.Generic;
using System.Threading;
using Datalagring_CarPark_EFCore.Domain.Model;
using static System.Console;


namespace Datalagring_CarPark_EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            bool shouldExit = false;
​
            while (!shouldExit)
            {
                WriteLine("1. Register arrival");
                WriteLine("2. Register departure");
                WriteLine("3. Show registry");
                WriteLine("4. Exit");
​
                ConsoleKeyInfo keyPressed = ReadKey(true);
​
                Clear();
​
                switch (keyPressed.Key)
                {
                    // Register arrival
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
​
                        RegisterArrival();
​
                        break;
​
                    // Register departure
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
​
                        RegisterDeparture();
​
                        break;
​
                    // Show registry
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
​
                        ShowRegistry();
​
                        break;
​
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
​
                        shouldExit = true;
​
                        break;
                }
​
                Clear();
            }
        }
​
        private static void ShowRegistry()
        {
            List<Parking> parkingList = FetchAllActiveParkings();
​
            foreach (Parking parking in parkingList)
            {
                Write($"{parking.Person.FirstName} {parking.Person.LastName}".PadRight(20, ' '));
                Write(parking.Vehicle.RegistrationNumber.PadRight(10, ' '));
                Write(parking.ArrivedAt.ToString().PadRight(25, ' '));
                WriteLine(parking.DepartedAt);
            }
        }
​
        private static List<Parking> FetchAllActiveParkings()
        {
            // TODO: Fetch parkings from database
​
            return new List<Parking>();
        }
​
        private static void RegisterArrival()
        {
            // Vehicle
            Write("Registration number: ");
​
            string registrationNumber = ReadLine();
​
            Write("Notes: ");
​
            string notes = ReadLine();
​
            Vehicle vehicle = new Vehicle(registrationNumber, notes);
​
​
            // Person
            Write("Social security number: ");
​
            string socialSecurityNumber = ReadLine();
​
            Write("First name: ");
​
            string firstName = ReadLine();
​
            Write("Last name: ");
​
            string lastName = ReadLine();
​
            Write("Phone number: ");
​
            string phoneNumber = ReadLine();
​
            Write("E-mail: ");
​
            string email = ReadLine();
​
            Person person = new Person(firstName, lastName, socialSecurityNumber, phoneNumber, email);
​
            Parking parking = new Parking(person, vehicle);
​
            SaveParking(parking);
​
            Clear();
​
            WriteLine("Arrival registered");
​
            Thread.Sleep(2000);
        }
​
        private static void SaveParking(Parking parking)
        {
​
        }
​
        private static void RegisterDeparture()
        {
            Write("Registration number: ");
​
            string registrationNumber = ReadLine();
​
            Parking parking = FetchActiveParkingsByRegistrationNumber(registrationNumber);
​
            if (parking != null)
            {
                parking.Departed();
​
                SaveParking(parking);
            }
            else
            {
                Clear();
​
                WriteLine("Parking not found");
​
                Thread.Sleep(2000);
            }
        }
​
        private static Parking FetchActiveParkingsByRegistrationNumber(string registrationNumber)
        {
            throw new NotImplementedException();
        }
    }
}