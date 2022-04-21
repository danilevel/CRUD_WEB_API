using CRUD_WEB_API.Models;
using CRUD_WEB_API.Paginations;
using CRUD_WEB_API.Repositories;
using CRUD_WEB_API.SortingModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_WEB_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetUpsController : ControllerBase
    {
        readonly IDbRepository<MeetUp> _meetUpRepository;

        public MeetUpsController(IDbRepository<MeetUp> dbRepository)
        {
            _meetUpRepository = dbRepository;
        }

        [HttpGet]
        public IEnumerable<MeetUp> GetAllMeetUps([FromQuery] Pagination pagination,
                                                 [FromQuery] SortingOptions sortingOptions, [FromQuery] string searchString = "")
        {
            return _meetUpRepository.GetWithOptions(pagination, sortingOptions, searchString);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var meetUp = _meetUpRepository.Get(id);

            if (meetUp == null)
            {
                return NotFound();
            }

            return new ObjectResult(meetUp);
        }

        [HttpPost]
        public IActionResult Create([FromBody] MeetUp meetUp)
        {
            if (meetUp == null)
            {
                return BadRequest();
            }

            _meetUpRepository.Create(meetUp);
            return CreatedAtRoute("GetMeetUp", new { id = meetUp.Id }, meetUp);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MeetUp updatedMeetUp)
        {
            if (updatedMeetUp == null || updatedMeetUp.Id != id)
            {
                return BadRequest();
            }

            var meetUp = _meetUpRepository.Get(id);
            if (meetUp == null)
            {
                return NotFound();
            }

            _meetUpRepository.Update(updatedMeetUp);
            return RedirectToRoute("GetAllItems");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedMeetUp = _meetUpRepository.Delete(id);
            if (deletedMeetUp == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedMeetUp);
        }
    }
}