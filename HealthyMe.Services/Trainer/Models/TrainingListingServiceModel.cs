using HealthyMe.Common.Mapping;
using HealthyMe.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyMe.Services.Trainer.Models
{
    public class TrainingListingServiceModel : IMapFrom<Training>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public bool IsForLoosingWeight { get; set; }

        public bool IsForGainingWeight { get; set; }

        public MuscleGroup MuscleGroup { get; set; }
    }
}
