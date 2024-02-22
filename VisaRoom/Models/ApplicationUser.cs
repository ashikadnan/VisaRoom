using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VisaRoom.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public List<Employer_Request> Employer_RequestObject { get; set; }
        public List<Approved_Requests> Approved_RequestsObject { get; set; }


    }
}
