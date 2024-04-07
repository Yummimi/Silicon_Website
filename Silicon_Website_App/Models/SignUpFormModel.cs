using Silicon_Website_App.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Silicon_Website_App.Models
{
    public class SignUpFormModel
    {
        [Display(Name = "First name", Prompt = "Enter your first name", Order = 0)]
        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; } = null!;


        [Display(Name = "Last name", Prompt = "Enter your last name", Order = 1)]
        [Required(ErrorMessage = "Lastname is required")]
        public string LastName { get; set; } = null!;


        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Invalid email address")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;


        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$",
        ErrorMessage = "Invalid password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;


        [DataType(DataType.Password)]
        [Display(Name = "Confirm password", Prompt = "Confirm your password", Order = 4)]
        [Compare(nameof(Password), ErrorMessage = "Password does not match")]
        [Required(ErrorMessage = "You have to confirm your password")]
        public string ConfirmPassword { get; set; } = null!;


        [Display(Name = "I agree to the Terms & Conditions", Order = 5)]
        [CheckBoxRequired(ErrorMessage = "Terms & Conditions must be checked")]
        public bool TermsAndConditions { get; set; } = false;

    }
}
