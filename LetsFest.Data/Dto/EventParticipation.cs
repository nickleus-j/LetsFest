using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LetsFest.Data.Dto
{
    public class EventParticipation
    {
        [Key]
        public long Id { get; set; }
        [StringLength(40)]
        public string UserId { get; set; }
        public long EventId { get; set; }
        public short RoleId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
