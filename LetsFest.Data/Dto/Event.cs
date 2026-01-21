using System;
using System.Collections.Generic;
using System.Text;

namespace LetsFest.Data.Dto
{
    public class Event
    {
        public long EventID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InitiatorId { get; set; }
        public Nullable<bool> inUse { get; set; }
        public Nullable<bool> isPublic { get; set; }

        public Nullable<System.DateTime> ProposedStartDateTime { get; set; } = DateTime.UtcNow.AddDays(1);
        public Nullable<System.DateTime> ProposedEndDateTime { get; set; } = DateTime.UtcNow.AddDays(1).AddHours(1);
        public Nullable<System.DateTime> CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
