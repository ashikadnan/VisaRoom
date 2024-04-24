using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using VisaRoom.Data.Base;
using VisaRoom.Data.ViewModels;
using VisaRoom.Models;

namespace VisaRoom.Data.Services
{
    public interface ICandidateService: IEntityBaseRepository<Candidate>
    {
       //Task<IEnumerable<Candidate>> GetAllAsync();
        Task <Candidate> GetById(int id);
        Task<Candidate> GetByUserId(string user);
        Task <IEnumerable<Candidate>> GetAll();

        Task AddAsync(CandidateVM newCandidateVM, string user);
        Task UpdateAsync(CandidateVM newCandidateVM, int id);
        //Task DeleteAsync(int id);

        Task<NewCandidateDropdownVM> GetNewCandidateDropdownValues();

        Task EmployerRequest (int id, string user);

        Task ApprovedRequest(int id, string user);

    }
}
