using AutoMapper;
using HealthyMe.Common.Mapping;
using HealthyMe.Data.Models;

namespace HealthyMe.Services.Admin.Models
{
    public class MessagesListingModel : IMapFrom<Message>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string User { get; set; }

        public void ConfigureMapping(Profile mapper)
        => mapper.CreateMap<Message, MessagesListingModel>()
            .ForMember(m => m.User, cfg => cfg.MapFrom(m => m.User.Name));
    }
}