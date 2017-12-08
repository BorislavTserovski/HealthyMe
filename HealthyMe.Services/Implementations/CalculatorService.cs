using HealthyMe.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyMe.Services.Implementations
{
    public class CalculatorService : ICalculatorService
    {
        public double Calculate(Gender gender, double weight, double height, int age)
        {
            return Math.Round(weight / ((height / 100) * (height / 100)), 2);
        }
    }
}
