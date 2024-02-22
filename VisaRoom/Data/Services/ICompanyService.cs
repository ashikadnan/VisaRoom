using System.Collections.Generic;
using System.Threading.Tasks;
using VisaRoom.Models;

namespace VisaRoom.Data.Services
{
    public interface ICompanyService
    {
        Task <IEnumerable<Company>> GetAll();
        Task <Company> GetById(int id);
        Task AddAsync(Company company);
        Task<Company> UpdateAsync(int id, Company newCompany);    
        Task Delete(int id);
    }
}
