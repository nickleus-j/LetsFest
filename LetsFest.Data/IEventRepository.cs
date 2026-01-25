using LetsFest.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsFest.Data
{
    public interface IEventRepository
    {
        Task<IList<Event>> GetEventsOfUserAsync(string userId);
        Task<IList<Event>> GetEventsOfFutureLocationAsync(int locationId);
    }
}
