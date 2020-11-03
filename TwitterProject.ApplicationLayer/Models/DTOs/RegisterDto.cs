using System.ComponentModel.DataAnnotations;

namespace TwitterProject.ApplicationLayer.Models.DTOs
{
    public class RegisterDto
    {
        public int Id { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ImagePath { get => "/images/users/default.jpg"; }
        
    }
}
