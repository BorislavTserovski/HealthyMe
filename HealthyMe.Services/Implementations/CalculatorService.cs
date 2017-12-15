using HealthyMe.Data;
using HealthyMe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyMe.Services.Implementations
{
    public class CalculatorService : ICalculatorService
    {
        private readonly HealthyMeDbContext db;

        public CalculatorService(HealthyMeDbContext db)
        {
            this.db = db;
        }
        public double Calculate(Gender gender, double weight, double height, int age, string userId)
        {
            var user = this.db.Users.Where(u => u.Id == userId).FirstOrDefault();
            var BMI = Math.Round(weight / ((height / 100) * (height / 100)), 2);
            user.BodyMassIndex = BMI;

            db.SaveChanges();

            return BMI;
        }
    }
}
