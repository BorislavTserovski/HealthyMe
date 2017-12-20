using HealthyMe.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyMe.Web.Areas.Trainer.Models
{
    public class TrainingFormModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        [RegularExpression("^https(.)+", ErrorMessage = "The video url must start with \"https\"")]
        public string VideoUrl { get; set; }

        public bool IsForLoosingWeight { get; set; }

        public bool IsForGainingWeight { get; set; }

        public MuscleGroup MuscleGroup { get; set; }
    }
}
