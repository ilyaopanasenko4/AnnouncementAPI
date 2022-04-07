using AnnouncementApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.DAL.EF
{
    /// <summary>
    /// this class contains a method that initializes the database with initial data
    /// </summary>
    public static class ApplicationSeeder
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Announcement>().HasData(
                new Announcement
                {
                    Id = 1,
                    Title = "LINQ overview",
                    Description = "Language-Integrated Query LINQ provides language-level querying capabilities, " +
                    "and a higher-order function API to C# and Visual Basic, that enable you to write expressive declarative code.",
                    Date = DateTime.Now
                },
                new Announcement
                {
                    Id = 2,
                    Title = "Essential LINQ",
                    Description = "The following examples are a quick demonstration of some of the essential pieces of LINQ. This is in no way comprehensive, " +
                    "as LINQ provides more functionality than what is showcased here.",
                    Date = DateTime.Now
                }, 
                new Announcement
                {
                    Id = 3,
                    Title = "Title",
                    Description = "Description",
                    Date = DateTime.Now
                },
                new Announcement
                {
                    Id = 4,
                    Title = "LINQ LINQ",
                    Description = "Empty Description",
                    Date = DateTime.Now
                });
        }
    }
}
