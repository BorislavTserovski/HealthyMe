using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyMe.Data.Models
{
    public class UserTraining
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int TrainingId { get; set; }

        public Training Training { get; set; }
    }
}
