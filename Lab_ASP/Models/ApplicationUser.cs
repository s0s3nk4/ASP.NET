using Microsoft.AspNetCore.Identity;

namespace Lab_ASP.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public UserType UserType { get; set; } 
        public ApplicationUser()
        {
            UserType = UserType.Bronze;
        }

        public decimal Discount
        {
            get
            {
                return UserType switch
                {
                    UserType.Bronze => 0,
                    UserType.Silver => 5.0m,
                    UserType.Gold => 10.0m,
                    _ => 0
                };
            }
        }
    }

    

    public enum UserType
    {
        Bronze = 0,
        Silver = 1,
        Gold = 2
    }
}
