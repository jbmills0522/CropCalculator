using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TomatoCalculator.Shared.Helpers
{
    public class TomatoCalculatorEnums
    {
        public enum TomatoType
        {
            [Display(Name = "Not Set")]
            NotSet,
            [Display(Name = "Heirloom")]
            Heirloom, 
            [Display(Name = "Roma")]
            Roma,
            [Display(Name = "Cherry")]
            Cherry,
            [Display(Name = "Grape")]
            Grape,
            [Display(Name = "Green Tomatoes")]
            Green
        }

        public enum Locations
        {
            [Display(Name = "Not Set")]
            NotSet,
            [Display(Name = "Corcoran, Ca")]
            CorcoranCa,
            [Display(Name = "Sacramento, Ca")]
            SacramentoCa, 
            [Display(Name = "Portland, Or")]
            PortlandOr,
            [Display(Name = "Atlanta, Ga")]
            AtlantaGa, 
            [Display(Name = "Lubbock, Tx")]
            LubbockTx
        }

        public enum LoadingUnloading
        {
            [Display(Name = "Select Loading or Unloading")]
            NotSet,
            [Display(Name = "Loading")]
            Loading, 
            [Display(Name = "Unloading")]
            Unloading
        }
    }
}