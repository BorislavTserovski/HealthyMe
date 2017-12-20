using HealthyMe.Services.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyMe.Web.Areas.Admin.Models.Messages
{
    public class MessagesListingViewModel 
    {
        public IEnumerable<MessagesListingModel> Messages { get; set; }
    }
}
