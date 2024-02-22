using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VisaRoom.Models;

namespace VisaRoom.Data.ViewModels
{
    public class CandidateVM
    {
        public int Id { get; set; }

        public string CandidateImage { get; set; }
        [Display(Name = "Candidate Image")]
        public IFormFile CandidateImageFile { get; set; }

        [Display(Name ="Candidate Name")]
        [Required(ErrorMessage = "Candidate Name is required")]
        public string CandidateName { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage = "City Name is required")]
        public string CandidateCity { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country Name is required")]
        public string CandidateCountry { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Candidate Phone Number is required")]
        public int CandidatePhone { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        //Relationship
        [Display(Name = "Select a list of companies")]
        [Required(ErrorMessage = "Company Name is required")]
        public List<int> CompanyIds { get; set; }
        [Display(Name = "Select which country you want to apply")]
        [Required(ErrorMessage = "Preferred country is required")]
        public int ApplyCountryId { get; set; }
        [Display(Name = "Select a Visa Type")]
        [Required(ErrorMessage = "Visa Type is required")]
        public int VisaTypeId { get; set; }

        public string CandidateUserId { get; set; }

        public string Certificate { get; set; }
        [Display(Name = "School Certificate")]
        public IFormFile CertificateImageFile { get; set; }

        public string Certificate2 { get; set; }
        [Display(Name = "College Certificate")]
        public IFormFile Certificate2ImageFile { get; set; }

        public string Certificate3 { get; set; }
        [Display(Name = "Bachelor Certificate")]
        public IFormFile Certificate3ImageFile { get; set; }

        public string Certificate4 { get; set; }
        [Display(Name = "Masters Certificate")]
        public IFormFile Certificate4ImageFile { get; set; }


        public Experience Experience { get; set; }
        public Qualification Qualification { get; set; }


    }
}
