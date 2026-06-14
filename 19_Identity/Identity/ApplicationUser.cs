using Microsoft.AspNetCore.Identity;

namespace _19_Identity.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }

        public override string? UserName { get; set; }
    }
}
