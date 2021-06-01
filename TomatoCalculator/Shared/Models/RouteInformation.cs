using System;
using static TomatoCalculator.Shared.Helpers.TomatoCalculatorEnums;

namespace TomatoCalculator.Shared.Models
{
    public class RouteInformation
    {
        public Guid Id { get; set; }
        public Locations DepartureLocation { get; set; } = Locations.NotSet;
        public Locations ArrivalLocation { get; set; } = Locations.NotSet;
        public float ApproximateMileage { get; set; } = 0;
        public string MapImage { get; set; }

        public RouteInformation()
        {
            
        }
    }
}