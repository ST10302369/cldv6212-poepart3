using Microsoft.AspNetCore.Identity;

namespace CloudPart3.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

}
