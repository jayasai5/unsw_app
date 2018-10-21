using Microsoft.AspNetCore.Identity;

namespace unsw_app.Models.Entities
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}