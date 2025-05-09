using System.ComponentModel.DataAnnotations;

namespace TechXpress.Web.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password")]
        [Display(Name = "Confirm Password")]
        public required string ConfirmPassword { get; set; }

        public string? Address { get; set; }
    }
}
