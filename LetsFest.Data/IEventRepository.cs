using LetsFest.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsFest.Data
{
    public interface IEventRepository: IRepository<Event>
    {
        Task<IList<Event>> GetEventsOfUserAsync(string userId);
        Task<IList<Event>> GetEventsOfFutureLocationAsync(int locationId);
        Task<IList<EventParticipation>> GetEventParticipationOfEventAsync(long eventId);
    }
}
