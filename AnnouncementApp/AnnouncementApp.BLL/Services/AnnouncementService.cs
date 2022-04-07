using AnnouncementApp.BLL.DTO;
using AnnouncementApp.BLL.Helpers.ExceptionModels;
using AnnouncementApp.BLL.Interfaces;
using AnnouncementApp.DAL.Entities;
using AnnouncementApp.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.BLL.Services
{
    /// <summary>
    /// interface implementation IAnnouncementService
    /// </summary>
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IRepositoryManager db;
        private readonly IMapper mapper;

        public AnnouncementService(IRepositoryManager db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<AnnouncementDTO> Add(AnnouncementDTO announcementDTO)
        {
            if (announcementDTO == null)
                throw new CustomException("Announcement is not found", 404);

            if (announcementDTO.Id != 0)
                throw new CustomException("Model Id should be 0 while adding to db", 400);

            var announcement = mapper.Map<AnnouncementDTO, Announcement>(announcementDTO);
            await db.AnnouncementRepository.Create(announcement);
            await db.Save();

            return mapper.Map<Announcement, AnnouncementDTO>(announcement);
        }

        public async Task<AnnouncementDTO> Delete(int? id)
        {
            if (!id.HasValue)
                throw new CustomException("Id is not found", 404);

            var announcement = await db.AnnouncementRepository.Get(id.Value);

            if (announcement == null)
                throw new CustomException("Announcement is not found", 400);

            db.AnnouncementRepository.Delete(announcement);
            await db.Save();
            return mapper.Map<Announcement, AnnouncementDTO>(announcement);
        }

        public async Task<AnnouncementDTO> Edit(AnnouncementDTO announcementDTO)
        {
            var announcement = mapper.Map<AnnouncementDTO, Announcement>(announcementDTO);

            if (!await db.AnnouncementRepository.Exist(announcement))
                throw new CustomException("Announcement is not found", 400);

            db.AnnouncementRepository.Update(announcement);
            await db.Save();
            return mapper.Map<Announcement, AnnouncementDTO>(announcement);
        }

        /// <summary>
        /// this method contains an algorithm for finding 3 similar announcements
        /// </summary>
        /// <param name="id">id of the model to be searched for</param>
        /// <returns>list of similar announcements</returns>
        public async Task<IEnumerable<AnnouncementDTO>> ShowSimiliar(int? id)
        {
            if (!id.HasValue)
                throw new CustomException("Id is not Found", 404);

            var announcement = await db.AnnouncementRepository.Get(id.Value);

            if (announcement == null)
                throw new CustomException("Announcement is not found", 400);

            static string[] SplitItems(string str)
            {
                return str.ToLower().Split(' ', ',', '.');
            }

            var announcements = mapper.Map<IEnumerable<Announcement>, IEnumerable<AnnouncementDTO>>(await db.AnnouncementRepository.GetAll());

            return announcements.Select(a => new
                    {
                        Announcement = a,
                        TitleMatchesCount = SplitItems(a.Title).Intersect(SplitItems(announcement.Title)).Count(),
                        DescriptionMatchesCount = SplitItems(a.Description).Intersect(SplitItems(announcement.Description)).Count()
                    })
                        .Where(a => a.TitleMatchesCount > 0 || a.DescriptionMatchesCount > 0)
                        .OrderByDescending(a => a.TitleMatchesCount)
                        .ThenByDescending(a => a.DescriptionMatchesCount)
                        .Select(a => a.Announcement)
                        .Take(3);
        }

        public async Task<AnnouncementDTO> ShowDetails(int? id)
        {
            if (!id.HasValue)
                throw new CustomException("Id is not found", 404);

            var announcement = await db.AnnouncementRepository.Get(id.Value);

            if (announcement == null)
                throw new CustomException("Announcement is not found", 400);

            return mapper.Map<Announcement, AnnouncementDTO>(announcement);
        }

        public async Task<IEnumerable<AnnouncementDTO>> ShowList()
            => mapper.Map<IEnumerable<Announcement>, IEnumerable<AnnouncementDTO>>(await db.AnnouncementRepository.GetAll());
    }
}
