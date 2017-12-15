﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthyMe.Data.Models
{
    public class Training
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public bool IsForLoosingWeight { get; set; }

        public bool IsForGainingWeight { get; set; }

        public MuscleGroup MuscleGroup  { get; set; }

        public List<UserTraining> Users { get; set; } = new List<UserTraining>();


    }
}
