using LetsFest.Data.Dto;
using LetsFest.Mysql;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LetsFest.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventParticipationController : Controller
    {
        private readonly FestContext _context;
        public EventParticipationController(FestContext context)
        {
            _context = context;
        }
        [HttpGet] 
        public ActionResult<IEnumerable<EventParticipationDto>> Get() { return Ok("Return"); }

        [HttpGet("{eventId}")]
        public async Task<JsonResult> GetById(long eventId)
        {
            EfWorkUnit efWorkUnit = new EfWorkUnit(_context);
            var ep= await efWorkUnit.EventRepository.GetEventParticipationOfUserAsync(eventId);
            return Json(AutoMapperConfig.Mapper.Map<IList<EventParticipationDto>>(ep)); 
        }
    }
}
