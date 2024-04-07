using Silicon_Website_App.Models;

namespace Silicon_Website_App.ViewModels
{
    public class SignUpViewModel
    {
        public string Title { get; set; } = "Sign up";
        public SignUpFormModel Form { get; set; } = new SignUpFormModel();
    }
}
