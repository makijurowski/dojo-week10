using System;
using System.ComponentModel.DataAnnotations;

namespace LoginRegistration.Models
{
    public abstract class BaseEntity {}

    public class RegisterUser : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage="Invalid email.")]
        [Display(Name="Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password confirmation must match.")]
        [Display(Name="Confirm Password")]
        public string Confirm { get; set; }
    }

    public class LoginUser : BaseEntity
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email")]
        [EmailAddress(ErrorMessage="Invalid Email")]
        public string LogEmail { get; set; }

        [Required]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string LogPassword { get; set; }
    }
}