using LetsFest.Data;
using LetsFest.Data.Entity;
using Microsoft.AspNetCore.Identity;
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

        public async Task ChooseEventParticipant(string userName, long eventId, short RoleId)
        {
            IdentityUser user = await festContext.Users.Where(u => u.UserName == userName).FirstAsync();
            if (user != null)
            {
                ParticipateInEvent(eventId, user.Id, RoleId);
            }
        }
        public async Task<IList<EventParticipation>> GetEventParticipationOfUserAsync(long eventId)
        {
            return await festContext.EventParticipation.Where(ep => ep.EventId == eventId).ToListAsync();
        }

        public async Task ParticipateInEvent(long eventId, string userId, short RoleId)
        {
            var ep=new EventParticipation { EventId=eventId, UserId=userId, RoleId=RoleId,CreatedOn=DateTime.UtcNow };
            Add(ep);
            await festContext.SaveChangesAsync();
        }
    }
}
