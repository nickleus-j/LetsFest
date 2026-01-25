using LetsFest.Data;
using LetsFest.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsFest.Mysql
{
    public class EventRepository : Repository<Event>,IEventRepository
    {
        public EventRepository(DbContext context) : base(context)
        {
        }

        public FestContext webContext
        {
            get { return Context as FestContext; }
        }
        public async Task<IList<Event>> GetEventsOfFutureLocationAsync(int locationId)
        {
            Location locations = await webContext.Location.Include(l=>l.Events).SingleAsync(l=>l.Id== locationId);
            return locations.Events.ToList();
        }

        public async Task<IList<Event>> GetEventsOfUserAsync(string userId)
        {
            return await webContext.Event.Where(e => e.InitiatorId == userId).ToListAsync();
        }
    }
}
