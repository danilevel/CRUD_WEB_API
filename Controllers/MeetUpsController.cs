using AutoMapper;
using CRUD_WEB_API.Models;
using CRUD_WEB_API.Options;
using CRUD_WEB_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_WEB_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetUpsController : ControllerBase
    {
        readonly IRepository<MeetUp> _meetUpRepository;
        readonly IMeetUpService _meetUpService;
        readonly IMapper _mapper;

        public MeetUpsController(IRepository<MeetUp> dbRepository, IMeetUpService meetUpService, IMapper mapper)
        {
            _meetUpRepository = dbRepository;
            _meetUpService = meetUpService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<MeetUpDTO> GetAllMeetUps([FromQuery] Pagination pagination,
                                                 [FromQuery] SortingOptions sortingOptions,
                                                 [FromQuery] string? searchString)
        {

            var search = searchString is null ? "" : searchString;
            var meetUps = _meetUpService.GetWithOptions(pagination, sortingOptions, search);

            foreach (var item in meetUps)
            {
                yield return _mapper.Map<MeetUpDTO>(item);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var meetUp = _meetUpRepository.GetById(id);

            if (meetUp == null)
            {
                return NotFound();
            }

            return new ObjectResult(_mapper.Map<MeetUpDTO>(meetUp));
        }

        [HttpPost]
        public IActionResult Create([FromBody] MeetUpDTO MeetUpDTO)
        {
            if (MeetUpDTO == null)
            {
                return BadRequest();
            }
            var meetUP = _mapper.Map<MeetUp>(MeetUpDTO);
            _meetUpRepository.Create(meetUP);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MeetUpDTO updatedMeetUp)
        {
            if (updatedMeetUp == null)
            {
                return BadRequest();
            }

            var meetUp = _meetUpRepository.GetById(id);
            if (meetUp == null)
            {
                return NotFound();
            }

            var newMeetUp = _mapper.Map(updatedMeetUp, meetUp);
            _meetUpRepository.Update(newMeetUp);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedMeetUp = _meetUpRepository.Delete(id);
            if (deletedMeetUp == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}