using AutoMapper;
using HealthyMe.Common.Mapping;
using HealthyMe.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyMe.Services.Writer.Models
{
    public class WriterArticleDetailsServiceModel : IMapFrom<Article>, IHaveCustomMapping
    {

        public string Content { get; set; }

        public string Title { get; set; }

        public DateTime PublishDate { get; set; }


        public string Author { get; set; }

        public void ConfigureMapping(Profile mapper)
       => mapper.CreateMap<Article, WriterArticleDetailsServiceModel>()
            .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}
