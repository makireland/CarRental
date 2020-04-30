using DublinCarRental.Entities;
using System;

namespace DublinCarRental.Services
{
    public class RentalService
    {
        public double HourRates { get; private set; }
        public double DailyRates { get; private set; }

        private ITaxService _taxService;

        public RentalService(ITaxService taxService)
        {
            HourRates = 10.00;
            DailyRates = 130.00;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.CarReturn.Subtract(carRental.CarPickup);

            var basicPayment = 0.0;

            if (duration.TotalHours <= 12.0)
            {
                basicPayment = HourRates * Math.Ceiling(duration.TotalHours);
            }

            else
            {
                basicPayment = DailyRates * Math.Ceiling(duration.TotalDays);
            }

            var tax = _taxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);

        }
    }
}
