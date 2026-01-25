using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LetsFest.Data.Entity
{
    [Table("EventRole")]
    public class EventRole
    {
        [Key]
        public short Id { get;set;}
        [StringLength(300)]
        [DisplayName("Role Name")]
        public string RoleName { get; set; }
        [DefaultValue(true)]
        [DisplayName("In Use")]
        public Nullable<bool> inUse { get; set; }
    }
}
