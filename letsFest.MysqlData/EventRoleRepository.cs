using System;
using System.Collections.Generic;
using System.Text;
using LetsFest.Data;
using LetsFest.Data.Dto;
using Microsoft.EntityFrameworkCore;
namespace LetsFest.Mysql
{
    public class EventRoleRepository: Repository<EventRole>,IEventRoleRepository{


        public EventRoleRepository(DbContext context) : base(context)
        {
        }
        
        public FestContext webContext
        {
            get { return Context as FestContext; }
        }
        public IList<EventRole> GetStaffRoles()
        {
            return webContext.EventRole.Where(er => er.inUse == true&&er.RoleName!= "Attendee").ToList();
        }
    }
}
