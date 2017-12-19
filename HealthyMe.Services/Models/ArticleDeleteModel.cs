using HealthyMe.Common.Mapping;
using HealthyMe.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace HealthyMe.Services.Models
{
    public class ArticleDeleteModel : IMapFrom<Article>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public byte[] Image { get; set; }

        public string Author { get; set; }

        public void ConfigureMapping(Profile mapper)
       => mapper.CreateMap<Article, ArticleDeleteModel>()
            .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.Name));
    }
}
