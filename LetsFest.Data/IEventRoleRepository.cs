using System;
using System.Collections.Generic;
using LetsFest.Data.Dto;

namespace LetsFest.Data
{
    public interface IEventRoleRepository : IRepository<EventRole>
    {
        IList<EventRole> GetStaffRoles();
    }
}
