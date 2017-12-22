using HealthyMe.Services;
using HealthyMe.Services.Writer.Models;
using System;
using System.Collections.Generic;

namespace HealthyMe.Web.Areas.Writer.Models.Articles
{
    public class ArticleListingViewModel
    {
        public IEnumerable<WriterArticleListingServiceModel> Articles { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalArticles / ServiceConstants.ArticlePageSize);

        public int NextPage
            => this.CurrentPage == this.TotalPages
            ? this.TotalPages
            : this.CurrentPage + 1;

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int TotalArticles { get; set; }
    }
}