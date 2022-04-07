using AnnouncementApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.DAL.Interfaces
{
    /// <summary>
    /// interface for working with repositories, implements the unit of work pattern
    /// </summary>
    public interface IRepositoryManager : IDisposable
    {
        IRepository<Announcement> AnnouncementRepository { get; }
        Task Save();
    }
}
