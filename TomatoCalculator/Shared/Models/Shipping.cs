using System;
using static TomatoCalculator.Shared.Helpers.TomatoCalculatorEnums;

namespace TomatoCalculator.Shared.Models
{
    public class Shipping
    {
        public Guid Id { get; set; }
        public int DriverNumber { get; set; }
        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }
        public TomatoType TomatoType { get; set; }
        public float PricePerPound { get; set; }
        public float ExpectedLosePerMile { get; set; }
        public Locations DepartureLocation { get; set; } = Locations.NotSet;
        public Locations ArrivalLocation { get; set; } = Locations.NotSet;
        public float ApproximateMileage { get; set; } = 0;
        public float DepartureWeight { get; set; } = 0;
        public float UnloadWeight { get; set; } = 0;
        public float ExpectedLossTrip { get; set; }
        public float ActualLossTrip { get; set; }
        public float TotalLoadValue { get; set; }
        public float ExpectedLoadValue { get; set; }
        public float AdjustedLoadValue { get; set; }
        public DateTime DepartureDate { get; set; } = DateTime.Now;
        public DateTime UnloadDate { get; set; }

        public Shipping()
        {
            
        }
    }
}