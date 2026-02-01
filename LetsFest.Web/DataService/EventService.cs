using LetsFest.Data.Dto;
using LetsFest.Data.Entity;
using LetsFest.Mysql;
using Microsoft.EntityFrameworkCore;

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
        public async Task<int> UpdateEventFromDto(EventCreateEditDto dto) {
            var dbEvent = await efWorkUnit.EventRepository.SingleAsync(e => e.EventID == dto.EventID);
            AutoMapperConfig.Mapper.Map(dto, dbEvent);
            return efWorkUnit.Complete();
        }
    }
}
