using AnnouncementApp.DAL.EF;
using AnnouncementApp.DAL.Entities;
using AnnouncementApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.DAL.Repositories
{
    /// <summary>
    /// class for working with repositories, implementation of unity of work pattern
    /// </summary>
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationContext context;
        public RepositoryManager(ApplicationContext context)
        {
            this.context = context;
        }

        private readonly IRepository<Announcement>? announcementRepository;
        public IRepository<Announcement> AnnouncementRepository => announcementRepository ?? new AnnouncementRepository(context);

        public async Task Save()
            => await context.SaveChangesAsync();

        public async void Dispose()
            => await context.DisposeAsync();
    }
}
