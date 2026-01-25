using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LetsFest.Data.Entity
{
    public class UserProfile
    {
        public int Id { get; set; }
        [DisplayName("Given Name")]
        public string? GivenName { get; set; }
        [DisplayName("Surname")]
        public string? Surname { get; set; }
        [DisplayName("Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }
        public string? Occupation { get; set; }
        [DefaultValue(true)]
        [DisplayName("In Use")]
        public Nullable<bool> inUse { get; set; }
        [DisplayName("User Id")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public Aspnetusers User { get; set; } = new Aspnetusers();
    }
}
