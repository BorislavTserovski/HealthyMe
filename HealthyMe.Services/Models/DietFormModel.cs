using HealthyMe.Common.Mapping;
using HealthyMe.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthyMe.Services.Models
{
    public class DietFormModel: IMapFrom<Diet>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        public byte[] Image { get; set; }


    }
}
