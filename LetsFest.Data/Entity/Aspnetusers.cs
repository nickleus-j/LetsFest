using System;
using System.Collections.Generic;
using System.Text;

namespace LetsFest.Data.Entity
{
    public class Aspnetusers
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public byte EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public byte PhoneNumberConfirmed { get; set; }
        public byte TwoFactorEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public byte LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
    }
}
