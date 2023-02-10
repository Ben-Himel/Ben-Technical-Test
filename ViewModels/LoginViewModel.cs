using System.ComponentModel.DataAnnotations;

namespace Ben_Technical_Test.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="User name cannot be blank.")]
        public string? UserName { get; set; }
        
        [Required(ErrorMessage ="Password can not be blank.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        
        public bool RememberMe { get; set; } 
    }
}
