namespace VisaRoom.Models
{
    public class Candidate_Experience
    {
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public int ExperienceId { get; set; }
        public Experience Experience { get; set; }
    }
}
