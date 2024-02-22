using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisaRoom.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string DesignationName { get; set; }
        public string YearsExperience { get; set; }
        public string LocationName { get; set; }
        public List<Candidate_Experience> CandidateExperienceObj { get; set; }

    }
}
