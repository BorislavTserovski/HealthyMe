using HealthyMe.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyMe.Services
{
    public interface ICalculatorService
    {
        double Calculate(Gender gender, double weight, double height, int age);

        
    }
}
