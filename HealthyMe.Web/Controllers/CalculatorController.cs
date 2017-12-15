using HealthyMe.Data.Models;
using HealthyMe.Services;
using HealthyMe.Web.Models.Calculator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        //GET
        public IActionResult Calculate()
        {
            return View();
        }

        //POST
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
