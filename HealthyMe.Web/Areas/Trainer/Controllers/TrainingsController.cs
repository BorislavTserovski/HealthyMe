using HealthyMe.Services.Trainer;
using HealthyMe.Web.Areas.Trainer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthyMe.Web.Areas.Trainer.Controllers
{
    [Area(WebConstants.TrainerArea)]
    [Authorize(Roles = WebConstants.TrainerRole)]
    public class TrainingsController : Controller
    {
        private readonly ITrainingsService trainings;

        public TrainingsController(ITrainingsService trainings)
        {
            this.trainings = trainings;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
        => View(new TrainingListingViewModel
        {
            Trainings = await this.trainings.AllAsync(page),
            TotalTrainings = await this.trainings.TotalAsync(),
            CurrentPage = page
        });

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrainingFormModel trainingModel)
        {
            if (!ModelState.IsValid)
            {
                return View(trainingModel);
            }

            await this.trainings.Create(trainingModel.Name, trainingModel.Description, trainingModel.VideoUrl,
                 trainingModel.IsForLoosingWeight, trainingModel.IsForGainingWeight, trainingModel.MuscleGroup);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var training = await this.trainings.GetTrainingById(id);

            if (training == null)
            {
                return NotFound();
            }
            return View(training);
        }

        [HttpPost]
        public async Task<IActionResult> Destroy(int id)
        {
            await this.trainings.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> FilterTrainings(string group)
       => View(new TrainingListingViewModel
       {
           Trainings = await this.trainings.GetFilteredTrainings(group)
       });
    }
}