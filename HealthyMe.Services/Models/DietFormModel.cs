using HealthyMe.Common.Mapping;
using HealthyMe.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyMe.Services.Models
{
    public class DietFormModel: IMapFrom<Diet>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }


    }
}
