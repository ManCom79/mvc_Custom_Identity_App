using Microsoft.AspNetCore.Identity;
using mvc_Identity.Enums;

namespace mvc_Identity.Models
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string? Card { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? IsSubscriptionExpired { get; set; }
        public SubscriptionTypeEnum SubscriptionType { get; set; }
    }
}
