using LetsFest.Data;
using LetsFest.Data.Dto;
using LetsFest.Web.DataService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LetsFest.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventParticipationController : Controller
    {
        IDataUnitOfWork _unitOfWork;
        ParticipationService service;
        public EventParticipationController(IDataUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            service=new ParticipationService(unitOfWork);
        }
        [HttpGet] 
        public ActionResult<IEnumerable<EventParticipationDto>> Get() { return Ok("Return"); }

        [HttpGet("{eventId}")]
        public async Task<JsonResult> GetById(long eventId)
        {
            var ep= await _unitOfWork.EventRepository.GetEventParticipationOfEventAsync(eventId);
            return Json(AutoMapperConfig.Mapper.Map<IList<EventParticipationDto>>(ep)); 
        }
        [Authorize]
        [HttpPost("{eventId}/{roleId}")]
        public async Task<JsonResult> participate(long eventId,short roleId)
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            await service.Participate(eventId, roleId, claimsIdentity);
            return Json(GetById(eventId));
        }
        [HttpPost("{eventId}/{roleId}/{username}")]
        public async Task<ActionResult> participate(long eventId, short roleId,string userName)
        {
            await service.Participate(eventId, roleId, userName);
            return RedirectToAction(nameof(GetById), new { eventId = eventId });
        }
    }
}
