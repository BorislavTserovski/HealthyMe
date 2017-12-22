using HealthyMe.Data.Models;
using HealthyMe.Services.Trainer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthyMe.Services.Trainer
{
    public interface ITrainingsService
    {
        Task<IEnumerable<TrainingListingServiceModel>> AllAsync(int page = 1);

        Task Create(string name, string description, string videoUrl, bool isForLoosingWeight,
            bool isForGainingWeight, MuscleGroup muscleGroup);

        Task<int> TotalAsync();

        Task Delete(int id);

        Task<TrainingDeleteModel> GetTrainingById(int id);

        Task<IEnumerable<TrainingListingServiceModel>> GetFilteredTrainings(string group);
    }
}