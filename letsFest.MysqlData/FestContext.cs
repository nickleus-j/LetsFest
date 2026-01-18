using LetsFest.Data;
using LetsFest.Data.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsFest.Mysql
{
    public class FestContext: DbContext,IFestContext
    {
        public FestContext()
        {
        }

        public FestContext(DbContextOptions<FestContext> options)
            : base(options)
        {
        }
        public virtual DbSet<EventRole> EventRole { get; set; }
    }
}
