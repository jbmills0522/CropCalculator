using System;

namespace TomatoCalculator.Shared.Models
{
    public class DriverInformation
    {
        public Guid Id { get; set; }
        public int DriverNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DriverInformation()
        {
            
        }
    }
}