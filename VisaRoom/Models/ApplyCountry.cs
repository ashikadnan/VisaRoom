using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VisaRoom.Models
{
    public class ApplyCountry
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Country Name")]
        public string ApplyCountryName { get; set; }

        //Relationship
        public List<Candidate> Candidates { get; set; }
  
    }
}
