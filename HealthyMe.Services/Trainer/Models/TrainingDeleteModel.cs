using HealthyMe.Common.Mapping;
using HealthyMe.Data.Models;

namespace HealthyMe.Services.Trainer.Models
{
    public class TrainingDeleteModel : IMapFrom<Training>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}