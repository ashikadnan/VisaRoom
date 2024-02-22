using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace VisaRoom.Models
{
    public class Candidate_Company
    {
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public int ComapnyId { get; set; }
        public Company Company { get; set; }
        
    }
}
