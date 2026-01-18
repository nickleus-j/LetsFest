using System;
using System.Collections.Generic;
using System.Text;
using LetsFest.Mysql.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LetsFest.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Customize schema if needed
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRole> EventRoles { get; set; }
        public DbSet<EventParticipation> Participations { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
