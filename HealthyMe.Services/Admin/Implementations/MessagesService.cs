using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HealthyMe.Services.Admin.Models;
using HealthyMe.Data;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace HealthyMe.Services.Admin.Implementations
{
    public class MessagesService : IMessagesService
    {
        private readonly HealthyMeDbContext db;

        public MessagesService(HealthyMeDbContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<MessagesListingModel>> AllAsync()
        => await this.db
            .Messages
            .ProjectTo<MessagesListingModel>()
            .ToListAsync();

    }
}
