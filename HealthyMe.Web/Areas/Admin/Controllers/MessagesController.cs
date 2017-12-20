using HealthyMe.Services.Admin;
using HealthyMe.Web.Areas.Admin.Models.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyMe.Web.Areas.Admin.Controllers
{
    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class MessagesController : Controller
    {
        private IMessagesService messages;

        public MessagesController(IMessagesService messages)
        {
            this.messages = messages;
        }

        public async Task<IActionResult> Index()
        => View(new MessagesListingViewModel
            {
                Messages = await this.messages.AllAsync(),
            });
        
    }
}
