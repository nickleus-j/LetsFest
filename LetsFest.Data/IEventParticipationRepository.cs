using LetsFest.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsFest.Data
{
    public interface IEventParticipationRepository : IRepository<EventParticipation>
    {
        Task<IList<EventParticipation>> GetEventParticipationOfUserAsync(long eventId);
    }
}
