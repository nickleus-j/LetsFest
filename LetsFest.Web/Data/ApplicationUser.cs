using Microsoft.AspNetCore.Identity;

namespace LetsFest.Web.Data
{
    public class ApplicationUser : IdentityUser
    { // Extend with custom fields if needed
      public string DisplayName { get; set; } 
    }
}
