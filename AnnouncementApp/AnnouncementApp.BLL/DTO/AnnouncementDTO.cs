using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AnnouncementApp.BLL.Interfaces;
using AnnouncementApp.BLL.Services;

namespace AnnouncementApp.BLL.DTO
{
    /// <summary>
    /// AnnouncementDTO model for working on the business layer, contains constraint attributes
    /// </summary>
    public class AnnouncementDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "enter title")]
        [MaxLength(20, ErrorMessage = "max length of field title is 20")]
        [MinLength(3, ErrorMessage = "min length of field title is 3")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "enter description")]
        [MinLength(5, ErrorMessage = "min length of field description is 5")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "enter date")]
        public DateTime Date { get; set; }
    }
}