using AnnouncementApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.BLL.Interfaces
{
    /// <summary>
    /// business logic interface
    /// </summary>
    public interface IAnnouncementService
    {
        Task<IEnumerable<AnnouncementDTO>> ShowList();
        Task<AnnouncementDTO> ShowDetails(int? id);
        Task<IEnumerable<AnnouncementDTO>> ShowSimiliar(int? id);
        Task<AnnouncementDTO> Add(AnnouncementDTO announcementDTO);
        Task<AnnouncementDTO> Edit(AnnouncementDTO announcementDTO);
        Task<AnnouncementDTO> Delete(int? id);
    }
}
