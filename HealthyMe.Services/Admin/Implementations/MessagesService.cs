using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HealthyMe.Services.Admin.Models;
using HealthyMe.Data;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task Delete(int id)
        {
            var message = await this.db.Messages.FirstOrDefaultAsync();

            this.db.Remove(message);

            await this.db.SaveChangesAsync();
        }

        public async Task<MessagesListingModel> GetById(int id)
       => await this.db.Messages.Where(m => m.Id == id)
            .ProjectTo<MessagesListingModel>()
            .FirstOrDefaultAsync();

    }
}
