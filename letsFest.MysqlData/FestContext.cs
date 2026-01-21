using LetsFest.Data;
using LetsFest.Data.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LetsFest.Mysql
{
    public class FestContext: IdentityDbContext, IFestContext
    {
        public FestContext()
        {
        }

        public FestContext(DbContextOptions<FestContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventRole> EventRole { get; set; }
    }
}
