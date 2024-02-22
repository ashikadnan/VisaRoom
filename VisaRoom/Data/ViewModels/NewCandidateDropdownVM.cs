using System.Collections.Generic;
using VisaRoom.Models;

namespace VisaRoom.Data.ViewModels
{
    public class NewCandidateDropdownVM
    {
        public NewCandidateDropdownVM()
        {
            ApplyCountries = new List<ApplyCountry>();
            VisaTypes = new List<VisaType>();
            Companies = new List<Company>();
        }
        
        public List <ApplyCountry> ApplyCountries { get; set; }
        public List <VisaType> VisaTypes { get; set; }
        public List <Company> Companies { get; set; }

    }
}
