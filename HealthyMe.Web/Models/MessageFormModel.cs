using HealthyMe.Common.Mapping;
using HealthyMe.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace HealthyMe.Web.Models
{
    public class MessageFormModel : IMapFrom<Message>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        public string User { get; set; }

        public void ConfigureMapping(Profile mapper)
        => mapper.CreateMap<Message, MessageFormModel>()
            .ForMember(m => m.User, cfg => cfg.MapFrom(m => m.User.Name));
    }
}
