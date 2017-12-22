using HealthyMe.Data.Models;

namespace HealthyMe.Services
{
    public interface ICalculatorService
    {
        double Calculate(Gender gender, double weight, double height, int age);
    }
}