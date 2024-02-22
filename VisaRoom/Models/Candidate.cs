using VisaRoom.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using VisaRoom.Data.Base;

namespace VisaRoom.Models
{
    public class Candidate : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string CandidateImage { get; set; }
        public string CandidateName { get; set; }
        public string CandidateCity { get; set; }
        public string CandidateCountry { get; set; }

        public int CandidatePhone { get; set; }


        public Gender Gender { get; set; }

        
        //public Experience Experience { get; set; }
        //public Qualification Qualification { get; set; }

        //Relationship

        public string CandidateUserId { get; set; }
        [ForeignKey(nameof(CandidateUserId))]  
        public ApplicationUser userCandidate { get; set; }

        public int ApplyCountryId { get; set; }
        [ForeignKey("ApplyCountryId")]
        public ApplyCountry ApplyCountryObj { get; set; }

        public int VisaTypeId { get; set; }
        [ForeignKey("VisaTypeId")]
        public VisaType VisaTypeObj { get; set; }

        public string Certificate { get; set; }
        public string Certificate2 { get; set; }
        public string Certificate3 { get; set; }
        public string Certificate4 { get; set; }
       

        public List<Candidate_Company> Candidate_CompanyObj { get; set; }
        public List<Candidate_Qualification> Candidate_QualificationsObj { get; set; }

        public List<Candidate_Experience> Candidate_ExperienceObj { get; set; }

        public List<Candidate_Employer> Candidate_EmployerObj { get; set; }

        public List<Employer_Request> Employer_RequestObj { get; set; }

        public List<Approved_Requests> Approved_RequestsObj { get; set; }








    }
}
