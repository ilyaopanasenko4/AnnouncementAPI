using AnnouncementApp.DAL.EF;
using AnnouncementApp.DAL.Entities;
using AnnouncementApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.DAL.Repositories
{
    /// <summary>
    /// repository class for working with the model Announcement
    /// </summary>
    public class AnnouncementRepository : IRepository<Announcement>
    {
        protected readonly ApplicationContext context;

        public AnnouncementRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Announcement>> GetAll() 
            => await context.Announcements.ToListAsync();

        public async Task<Announcement> Get(int id) 
            => await context.Announcements.FindAsync(id);

        public async Task<IEnumerable<Announcement>> Find(Expression<Func<Announcement, bool>> predicate) 
            => await context.Announcements.Where(predicate).ToListAsync();

        public async Task Create(Announcement item) 
            => await context.Announcements.AddAsync(item);

        public void Delete(Announcement item)
           => context.Announcements.Remove(item);
        
        public void Update(Announcement item)
            => context.Announcements.Update(item);

        public async Task<bool> Exist(Announcement item)
            => await context.Announcements.AsNoTracking().AnyAsync(a => a.Id == item.Id);
    }
}
