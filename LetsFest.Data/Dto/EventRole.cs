using System;
using System.Collections.Generic;
using System.Text;

namespace LetsFest.Data.Dto
{
    public class EventRole
    {
        public short Id { get; set; }
        public string RoleName { get; set; }
        public Nullable<bool> inUse { get; set; }
    }
}
