using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.DAL.Entities
{
    /// <summary>
    /// Announcement model
    /// </summary>
    public  class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Date { get; set; }
    }
}
