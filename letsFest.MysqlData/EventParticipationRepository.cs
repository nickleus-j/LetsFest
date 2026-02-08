using LetsFest.Data;
using LetsFest.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsFest.Mysql
{
    public class EventParticipationRepository : Repository<EventParticipation>, IEventParticipationRepository
    {
        public EventParticipationRepository(DbContext context) : base(context)
        {
        }
        public FestContext festContext
        {
            get { return Context as FestContext; }
        }
        public async Task<IList<EventParticipation>> GetEventParticipationOfUserAsync(long eventId)
        {
            return await festContext.EventParticipation.Where(ep => ep.EventId == eventId).ToListAsync();
        }
    }
}
