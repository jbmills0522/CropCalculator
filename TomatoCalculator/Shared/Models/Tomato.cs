using System;
using System.ComponentModel.DataAnnotations.Schema;
using static TomatoCalculator.Shared.Helpers.TomatoCalculatorEnums;

namespace TomatoCalculator.Shared.Models
{
    public class Tomato
    {
        public Guid Id { get; set; }
        public TomatoType Type { get; set; } = TomatoType.NotSet;
        public float PricePerPound { get; set; } = 0;
        public float ExpectedWastePerPound { get; set; } = 0;
        
        public Tomato()
        {}
        
    }
    
}