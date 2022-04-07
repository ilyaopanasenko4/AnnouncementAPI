using AnnouncementApp.BLL.DTO;
using AnnouncementApp.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementApp.Controllers
{
    /// <summary>
    /// controller contains http methods GET by id that returns result with similiar announcements
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class SimiliarAnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService announcementService;

        public SimiliarAnnouncementController(IAnnouncementService announcementService)
        {
            this.announcementService = announcementService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AnnouncementDTO>>> Get(int? id)
        {
            return Ok(await announcementService.ShowSimiliar(id));
        }
    }
}
