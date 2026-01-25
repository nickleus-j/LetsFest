using System;
using System.Collections.Generic;
using LetsFest.Data.Entity;

namespace LetsFest.Data
{
    public interface IEventRoleRepository : IRepository<EventRole>
    {
        IList<EventRole> GetStaffRoles();
    }
}
