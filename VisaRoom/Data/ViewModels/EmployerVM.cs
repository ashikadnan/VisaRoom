using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace VisaRoom.Data.ViewModels
{
    public class EmployerVM
    {
        public int Id { get; set; }
        [Display(Name="Employer Image")]
        public string EmployerName { get; set; }
        [Display(Name = "Employer Phone Number")]
        public int EmployerPhone { get; set; }
        [Display(Name = "Employer City")]
        public string EmployerCity { get; set; }
        [Display(Name = "Employer Country")]
        public string EmployerCountry { get; set; }
        [Display(Name = "Employer Company Name")]
        public string EmployerCompany { get; set; }
        public string EmployerImage { get; set; }
        [Display(Name = "Employer Name")]
        public IFormFile EmployerImageFile { get; set; }
    }
}
