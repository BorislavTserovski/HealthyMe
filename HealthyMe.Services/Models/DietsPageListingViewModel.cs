using System.Collections.Generic;

namespace HealthyMe.Services.Models
{
    public class DietsPageListingViewModel
    {
        public int Id { get; set; }

        public IEnumerable<DietListingModel> Diets { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}