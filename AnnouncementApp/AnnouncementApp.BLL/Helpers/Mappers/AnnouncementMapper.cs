using AnnouncementApp.BLL.DTO;
using AnnouncementApp.DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.BLL.Helpers.Mappers
{
    /// <summary>
    /// the class contains a setting for mapping Announcement types that are used at different levels of the application
    /// </summary>
    public class AnnouncementMapper : Profile
    {
        public AnnouncementMapper()
        {
            CreateMap<Announcement, AnnouncementDTO>();
            CreateMap<AnnouncementDTO, Announcement>();
        }
    }
}
