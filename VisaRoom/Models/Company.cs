using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VisaRoom.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage ="Company Name is required")]

        [Display(Name = "Company Location")]
        public string CompanyLocation { get; set; }
        [Required(ErrorMessage = "Company Location is required")]

        public List<Candidate_Company> Candidate_CompanyObj { get; set; }
    }
}
