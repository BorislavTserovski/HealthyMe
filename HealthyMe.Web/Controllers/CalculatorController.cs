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
        private readonly UserManager<User> userManager;

        public CalculatorController(ICalculatorService calculators, UserManager<User> userManager)
        {
            this.calculators = calculators;
            this.userManager = userManager;
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
        [Authorize]
        public IActionResult Calculate(CalculatorModel calculatorModel)
        {
            var userId = this.userManager.GetUserId(User);
            double result = this.calculators.Calculate
                (calculatorModel.Gender, calculatorModel.Weight, calculatorModel.Height, calculatorModel.Age, userId);
            CalculatorResultViewModel viewModel = new CalculatorResultViewModel
            {
                Result = result
            };
            return View(nameof(Result), viewModel);
        }

        [Authorize]
        public IActionResult Result(CalculatorModel calculatorModel)
        {
            var userId = this.userManager.GetUserId(User);
            double result = this.calculators.Calculate
                (calculatorModel.Gender, calculatorModel.Weight, calculatorModel.Height, calculatorModel.Age, userId);
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
