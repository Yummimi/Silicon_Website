using System.ComponentModel.DataAnnotations;

namespace Silicon_Website_App.ViewModels
{
    public class AccountViewModel
    {
        public string Title { get; set; } = "Account Details";
        public AccountBasicInfo? BasicInfo { get; set; }
        public AccountAddressInfo? AddressInfo { get; set; }
    }

    public class AccountBasicInfo
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

        [Display(Name = "Phone", Prompt = "Enter your phone", Order = 3)]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Bio", Prompt = "Add a short bio...", Order = 4)]
        public string? Bio { get; set; }


    }

    public class AccountAddressInfo
    {

        [Display(Name = "Address line 1", Prompt = "Enter your address line", Order = 0)]
        [Required(ErrorMessage = "Address is required")]
        public string AddressLine_1 { get; set; } = null!;

        [Display(Name = "Address line 2", Prompt = "Enter your second address line", Order = 1)]
        public string? AddressLine_2 { get; set; }

        [Display(Name = "Postal code", Prompt = "Enter your postal code", Order = 2)]
        [Required(ErrorMessage = "Postal code is required")]
        public string PostalCode { get; set; } = null!;

        [Display(Name = "City", Prompt = "Enter your city", Order = 3)]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; } = null!;
    }
}
