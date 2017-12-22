using HealthyMe.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe.Web.Models.Calculator
{
    public class CalculatorModel
    {
        public Gender Gender { get; set; }

        [Range(10, 500)]
        [Display(Name = "Weight in KGs")]
        public double Weight { get; set; }

        [Range(50, 300)]
        [Display(Name = "Height in centimeters")]
        public double Height { get; set; }

        [Range(1, 130)]
        public int Age { get; set; }
    }
}