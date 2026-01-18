using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetsFest.Mysql.Data
{
    [Table("AppUser")]
    public class AppUser
    {
        [Key]
        [StringLength(45)]
        public string UserGuid { get; set; }
        public int Type { get; set; } = 1;
        [StringLength(100)]
        public string Username { get; set; }
        [StringLength(300)]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; } = false;

        [StringLength(int.MaxValue)]
        public string HasedPassword { get; set; }
        [StringLength(int.MaxValue)]
        public string Salt { get; set; }
        public Boolean OnLockout { get; set; } = false;
        public Nullable<DateTime> LockOutEnd { get; set; }
        public short AccessFailedCount { get; set; } = 0;
        public Nullable<DateTime> RegisteredOn { get; set; }
        public bool Active { get; set; } = true;
    }
}
