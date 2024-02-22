using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VisaRoom.Models
{
    public class VisaType
    {
        [Key]
        public int Id { get; set; }

        public string VisaTypeName { get; set; }

        //Relationship
        public List<Candidate> Candidates { get; set; }
    }
}
