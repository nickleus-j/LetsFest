using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LetsFest.Data.Dto
{
    public class EventCreateEditDto
    {
        public long EventID { get; set; }
        [Required]
        [StringLength(75)]
        public string Title { get; set; }
        public string Description { get; set; }
        [StringLength(40)]
        [DisplayName("InitiatorId")]
        public string InitiatorId { get; set; }
        [DefaultValue(true)]
        [DisplayName("In Use")]
        public bool inUse { get; set; }
        [DefaultValue(true)]
        [DisplayName("Is Public")]
        public bool isPublic { get; set; }
        [DisplayName("Proposed Start Time")]
        public Nullable<System.DateTime> ProposedStartDateTime { get; set; } = DateTime.UtcNow.AddDays(1);
        [DisplayName("Proposed End Time")]
        public Nullable<System.DateTime> ProposedEndDateTime { get; set; } = DateTime.UtcNow.AddDays(1).AddHours(1);
        [DisplayName("Created On")]
        public Nullable<System.DateTime> CreatedOn { get; set; } = DateTime.UtcNow;
        [DisplayName("Initiator")]
        public string InitiatorName { get; set; }
    }
}
