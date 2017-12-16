using HealthyMe.Services;
using HealthyMe.Services.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyMe.Web.Areas.Admin.Models.Products
{
    public class ProductListingViewModel
    {
        public IEnumerable<ProductListingModel> Products { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalProducts / ServiceConstants.ProductsPageSize);

        public int NextPage
            => this.CurrentPage == this.TotalPages
            ? this.TotalPages
            : this.CurrentPage + 1;

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int TotalProducts { get; set; }

       
    }
}
