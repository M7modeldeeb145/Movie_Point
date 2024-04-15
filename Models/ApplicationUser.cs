using Microsoft.AspNetCore.Identity;

namespace Movie_Point.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } =null!;
        public string LastName { get; set; } = null!;
    }
}
