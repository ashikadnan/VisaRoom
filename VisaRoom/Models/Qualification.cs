using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisaRoom.Models
{
    public class Qualification
    {
        [Key]
        public int Id { get; set; }
        public string InstituteName { get; set; }
        public string DegreeName { get; set; }
        public string PassingYear { get; set; }
        public string DurationYear { get; set; }
        public string SchoolResult { get; set; }

        public string InstituteName2 { get; set; }
        public string DegreeName2 { get; set; }
        public string PassingYear2 { get; set; }
        public string DurationYear2 { get; set; }       
        public string CollegeResult { get; set; }

        public string InstituteName3 { get; set; }
        public string DegreeName3 { get; set; }
        public string PassingYear3 { get; set; }
        public string DurationYear3 { get; set; }       
        public string BachelorResult { get; set; }


        public string InstituteName4 { get; set; }
        public string DegreeName4 { get; set; }
        public string PassingYear4 { get; set; }
        public string DurationYear4 { get; set; }
        public string MasterResult { get; set; }



        public List<Candidate_Qualification> CandidateQualificationsObj { get; set; }
    }
}
