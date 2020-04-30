using DublinCarRental.Entities;
using DublinCarRental.Services;
using System;
using System.Globalization;

namespace DublinCarRental
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n =====  Car Rental ===== \n");

            var rentalService = new RentalService(new IrelandTaxService());

            Console.WriteLine($"Hour Rates: {rentalService.HourRates.ToString("F2", CultureInfo.InvariantCulture)} \nDaily Rates: {rentalService.DailyRates.ToString("F2", CultureInfo.InvariantCulture)}");

            Console.Write("\nCar Model: ");
            var carModel = Console.ReadLine();

            Console.Write("Pickup (DD/ MM/ YYYY HH:MM): ");
            var dateStart = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Return (DD/ MM/ YYYY HH:MM): ");
            var dateReturn = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            
            var carRental = new CarRental(dateStart, dateReturn, new Vehicle(carModel));

            Console.WriteLine("\n\n =====  Car Rental Details ===== \n");

            Console.WriteLine($"{carRental.CarRentalDetails()}   Total Days / Hours: {dateReturn.Subtract(dateStart)}");

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("\n\n =====  Car Rental Invoice ===== \n");

            Console.WriteLine($"{carRental.Invoice}");
            
        }
    }
}
