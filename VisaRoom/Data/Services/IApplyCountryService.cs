using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using VisaRoom.Models;

namespace VisaRoom.Data.Services
{
    public interface IApplyCountryService
    {

        Task <IEnumerable<ApplyCountry>> GetAllAsync();
        Task <ApplyCountry> UpdateAsync(int id, ApplyCountry newApplyCountry);
        Task DeleteAsync(int id);
        Task AddAsync(ApplyCountry applyCountry);
        Task <ApplyCountry> GetById(int id);
    }
}
