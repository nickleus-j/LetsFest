using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LetsFest.Data.Dto
{
    public class EventParticipationDto
    {
        public long Id { get; set; }
        [DisplayName("User ID")]
        public string UserId { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        public long EventId { get; set; }
        public short RoleId { get; set; }
        [DisplayName("Role Title")]
        public string RoleTitle { get; set; }
        [DisplayName("Created On")]
        public Nullable<System.DateTime> CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
