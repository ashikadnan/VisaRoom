using System.ComponentModel.DataAnnotations;
using VisaRoom.Data.Enums;

namespace VisaRoom.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage ="Full Name is required")]  
        public string FullName { get; set; }

        [Display(Name="Email Address")]
        [Required(ErrorMessage ="Email Address is required")]
        public string EmailAddress { get; set; }

        [Display(Name ="Password")]
        [Required(ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
        [Display (Name = "Confirm Password")]
        [Required (ErrorMessage = "Confirm password is required")]
        public string ConfirmPassword { get; set; }

        [Display(Name ="Are you a Candidate or an Employer")]
        [Required(ErrorMessage ="This field is required")]
        public UserType UserType { get; set; }
    }
}
