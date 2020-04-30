using System;

namespace DublinCarRental.Entities
{
    public class CarRental
    {
        public DateTime CarPickup { get; set; }
        public DateTime CarReturn { get; set; }

        public Vehicle Vehicle { get; set; }
        public Invoice Invoice { get; set; }

        public CarRental(DateTime carPickup, DateTime carReturn, Vehicle vehicle)
        {
            CarPickup = carPickup;
            CarReturn = carReturn;
            Vehicle = vehicle;
            Invoice = null;
        }

        public string CarRentalDetails()
        {
            return $"Car Model: {Vehicle.CarModel}  \nDate Pickup: {CarPickup}   Date Return: {CarReturn} ";
        }
    }
}
