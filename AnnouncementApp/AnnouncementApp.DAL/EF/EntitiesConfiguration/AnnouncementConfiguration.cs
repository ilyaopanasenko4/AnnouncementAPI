using AnnouncementApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.DAL.EF
{
    /// <summary>
    /// this class contains the constraint setting for the model Announcement
    /// </summary>
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.Title).IsUnique();
            builder.Property(a => a.Title).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Description).IsRequired();
            builder.Property(a => a.Date).IsRequired();
        }
    }
}
