using HealthyMe.Services;
using HealthyMe.Web.Models.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace HealthyMe.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService calculators;

        public CalculatorController(ICalculatorService calculators)
        {
            this.calculators = calculators;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(CalculatorModel calculatorModel)
        {
            double result = this.calculators.Calculate
                (calculatorModel.Gender, calculatorModel.Weight, calculatorModel.Height, calculatorModel.Age);
            CalculatorResultViewModel viewModel = new CalculatorResultViewModel
            {
                Result = result
            };
            return View(nameof(Result), viewModel);
        }

        public IActionResult Result(CalculatorModel calculatorModel)
        {
            double result = this.calculators.Calculate
                (calculatorModel.Gender, calculatorModel.Weight, calculatorModel.Height, calculatorModel.Age);
            CalculatorResultViewModel viewModel = new CalculatorResultViewModel
            {
                Result = result
            };
            return View(viewModel);
        }

        public IActionResult Chart()
        {
            return View();
        }

        public IActionResult Recommendation()
        {
            return View();
        }
    }
}