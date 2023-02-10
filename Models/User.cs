using Microsoft.AspNetCore.Identity;
namespace Ben_Technical_Test.Models
{
    public class User : IdentityUser
    {
        //inherited not needed to be declaired
        //Note: Called "Username" in given logindata.csv test file
        //public string? UserName { get; set; }

        public string? Password { get; set; }

        //inheritied not needed to be declaired
        //public int? Id { get; set; }

        public string? Name { get; set; }
    }
}
