using AnnouncementApp.BLL.DTO;
using AnnouncementApp.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementApp.Controllers
{
    /// <summary>
    /// controller contains basic http methods like GET, POST, PUT, DELETE
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            this.announcementService = announcementService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnnouncementDTO>> Get(int? id)
        {
            return Ok(await announcementService.ShowDetails(id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnnouncementDTO>>> Get()
        { 
            return Ok(await announcementService.ShowList());
        }

        [HttpPost]
        public async Task<ActionResult<AnnouncementDTO>> Post(AnnouncementDTO announcement)
        {
            return Ok(await announcementService.Add(announcement));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AnnouncementDTO>> Delete(int? id)
        {
            return Ok(await announcementService.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<AnnouncementDTO>> Put(AnnouncementDTO announcement)
        {
            return Ok(await announcementService.Edit(announcement));
        }
    }
}
