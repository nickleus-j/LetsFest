using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LetsFest.Data.Dto
{
    public class UserProfileDto
    {
        public string ProfilePicUrl { get; set; }
        public string UserName { get; set; }
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
        public bool inUse { get; set; }
        [DisplayName("Biography Description")]
        public string Bio { get; set; }
        [DisplayName("User Id")]
        public string UserId { get; set; }
    }
}
