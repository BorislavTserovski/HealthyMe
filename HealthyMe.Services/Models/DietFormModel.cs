using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyMe.Services.Models
{
    public class DietFormModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }


    }
}
