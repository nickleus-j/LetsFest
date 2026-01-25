using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LetsFest.Data.Dto
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public long EventID { get; set; }
        [Required]
        [StringLength(75)]
        public string Title { get; set; }
        public string Description { get; set; }
        [StringLength(40)]
        public string InitiatorId { get; set; }
        [DefaultValue(true)]
        public Nullable<bool> inUse { get; set; }
        [DefaultValue(true)]
        public Nullable<bool> isPublic { get; set; }

        public Nullable<System.DateTime> ProposedStartDateTime { get; set; } = DateTime.UtcNow.AddDays(1);
        public Nullable<System.DateTime> ProposedEndDateTime { get; set; } = DateTime.UtcNow.AddDays(1).AddHours(1);
        public Nullable<System.DateTime> CreatedOn { get; set; } = DateTime.UtcNow;

    }
}
