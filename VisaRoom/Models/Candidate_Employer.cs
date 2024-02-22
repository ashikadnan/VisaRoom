namespace VisaRoom.Models
{
    public class Candidate_Employer
    {
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}
