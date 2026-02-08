using LetsFest.Data.Dto;
using LetsFest.Data.Entity;
using LetsFest.Mysql;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LetsFest.Web.DataService
{
    public class EventService
    {
        private readonly FestContext _context;
        private EfWorkUnit efWorkUnit;
        public EventService(FestContext context)
        {
            _context=context;
            efWorkUnit = new EfWorkUnit(_context);
        }
        public async Task<EventCreateEditDto> GetEventDtoWithId(long id)
        {
            var dbEvent = efWorkUnit.EventRepository.SingleOrDefault(e => e.EventID == id);

            var dto = AutoMapperConfig.Mapper.Map<EventCreateEditDto>(dbEvent);
            UserProfile profile = await _context.UserProfile.SingleAsync(up => up.UserId == dto.InitiatorId);
            dto.InitiatorName = profile.GivenName + " " + profile.Surname; 

            return dto;
        }
        public int CreateFromDto(EventCreateEditDto dto,string InitiatorId)
        {
            var dbEvent = AutoMapperConfig.Mapper.Map<Event>(dto);
            dbEvent.CreatedOn = DateTime.UtcNow;
            dbEvent.InitiatorId = InitiatorId;
            efWorkUnit.EventRepository.Add(dbEvent);
            int creationResult= efWorkUnit.Complete();
            EventParticipation ep = new EventParticipation { EventId = dbEvent.EventID
                , RoleId = efWorkUnit.EventRoles.GetAll().First().Id
                ,UserId=InitiatorId
                ,CreatedOn= DateTime.UtcNow
            };
            efWorkUnit.EventParticipationRepository.Add(ep);
            efWorkUnit.Complete();
            return creationResult;
        }
        public async Task<int> UpdateEventFromDto(EventCreateEditDto dto) {
            var dbEvent = await efWorkUnit.EventRepository.SingleAsync(e => e.EventID == dto.EventID);
            AutoMapperConfig.Mapper.Map(dto, dbEvent);
            return efWorkUnit.Complete();
        }
        public async Task<IList<EventCreateEditDto>> GetEventsOfUserAsync(ClaimsIdentity claimsIdentity)
        {
            // the principal identity is a claims identity.
            // now we need to find the NameIdentifier claim
            var userIdClaim = claimsIdentity.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim != null)
            {
                var userIdValue = userIdClaim.Value;
            }
            var result = await efWorkUnit.EventRepository.GetEventsOfUserAsync(userIdClaim.Value);
            var dtoList = AutoMapperConfig.Mapper.Map<IList<EventCreateEditDto>>(result);
            return dtoList;
        }
    }
}
