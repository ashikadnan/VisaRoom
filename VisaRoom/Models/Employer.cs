using System.Collections.Generic;
using VisaRoom.Data.Base;

namespace VisaRoom.Models
{
    public class Employer: IEntityBase
    {
        public int Id { get; set; }
        public string EmployerImage { get; set; }
        public string EmployerName { get; set; }
        public int EmployerPhone { get; set; }
        public string EmployerCity { get; set; }
        public string EmployerCountry { get; set; }
        public string EmployerCompany { get; set; }

        public List<Candidate_Employer> CandidateEmployerObject { get; set; }
    }
}
