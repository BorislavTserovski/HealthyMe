using HealthyMe.Services.Admin.Models;
using System.Collections.Generic;

namespace HealthyMe.Web.Areas.Admin.Models.Messages
{
    public class MessagesListingViewModel
    {
        public IEnumerable<MessagesListingModel> Messages { get; set; }
    }
}