using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HealthyMe.Data.Models;
using HealthyMe.Data;
using HealthyMe.Services.Trainer.Models;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace HealthyMe.Services.Trainer.Implementations
{
    public class TrainingsService : ITrainingsService
    {
        private HealthyMeDbContext db;

        public TrainingsService(HealthyMeDbContext db)
        {
            this.db = db;
        }

       
        public async Task<IEnumerable<TrainingListingServiceModel>> AllAsync(int page = 1)
        => await this.db.Trainings
            .OrderBy(t => t.Id)
            .Skip((page - 1) * ServiceConstants.TrainingsPageSize)
            .Take(ServiceConstants.TrainingsPageSize)
            .ProjectTo<TrainingListingServiceModel>()
            .ToListAsync();

        public async Task Create(string name, string description, string videoUrl,
            bool isForLoosingWeight, bool isForGainingWeight, MuscleGroup muscleGroup)
        {
            var training = new Training
            {
                Name = name,
                Description = description,
                VideoUrl = videoUrl,
                IsForLoosingWeight = isForLoosingWeight,
                IsForGainingWeight = isForGainingWeight,
                MuscleGroup = muscleGroup
            };
            this.db.Add(training);
            await this.db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Training training = this.db.Trainings
                .Where(t => t.Id == id)
                .FirstOrDefault();

            this.db.Trainings.Remove(training);

            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TrainingListingServiceModel>> GetFilteredTrainings(string group)
       => await this.db.Trainings
            .Where(t=>t.MuscleGroup.ToString()==group)
            .OrderBy(t => t.Id)
            .ProjectTo<TrainingListingServiceModel>()
            .ToListAsync();

        public async Task<TrainingDeleteModel> GetTrainingById(int id)
        =>  await this.db.Trainings.Where(t => t.Id == id)
            .ProjectTo<TrainingDeleteModel>()
            .FirstOrDefaultAsync();

      

        public async Task<int> TotalAsync()
        => await this.db.Trainings.CountAsync();
    }
}
