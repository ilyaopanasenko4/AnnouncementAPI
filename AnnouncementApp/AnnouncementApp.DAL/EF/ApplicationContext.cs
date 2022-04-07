using AnnouncementApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementApp.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Announcement> Announcements => Set<Announcement>();
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=announcement.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
            modelBuilder.Seed();
        }
    }
}
