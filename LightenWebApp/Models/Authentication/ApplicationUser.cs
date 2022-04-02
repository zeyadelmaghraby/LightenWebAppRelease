using Microsoft.AspNetCore.Identity;

namespace LightenWebApp.Models.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public string FullAddress { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
