namespace VisaRoom.Models
{
    public class Approved_Requests
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
