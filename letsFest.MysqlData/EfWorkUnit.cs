using LetsFest.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsFest.Mysql
{
    public class EfWorkUnit : IDataWorkUnit
    {
        private readonly FestContext _context;
        public IEventRoleRepository EventRoles { get; private set; }

        public IEventRepository EventRepository { get; private set; }
        public IEventParticipationRepository EventParticipationRepository { get; private set; }
        public IUserProfileRepository UserProfileRepository { get; private set; }

        public EfWorkUnit(FestContext context)
        {
            _context = context;
            EventRoles = new EventRoleRepository(_context);
            UserProfileRepository = new UserProfileRepository(_context);
            EventRepository = new EventRepository(_context);
            EventParticipationRepository=new EventParticipationRepository(_context);
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
