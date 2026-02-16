using LetsFest.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsFest.Data
{
    public interface IEventParticipationRepository : IRepository<EventParticipation>
    {
        Task<IList<EventParticipation>> GetEventParticipationOfUserAsync(long eventId);
        Task ParticipateInEvent(long eventId, string userId, short RoleId);
        Task ChooseEventParticipant(string userName, long eventId, short RoleId);
    }
}
