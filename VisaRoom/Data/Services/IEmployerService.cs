using System.Collections.Generic;
using System.Threading.Tasks;
using VisaRoom.Data.Base;
using VisaRoom.Data.ViewModels;
using VisaRoom.Models;

namespace VisaRoom.Data.Services
{
    public interface IEmployerService: IEntityBaseRepository<Employer>
    {
        //Task <IEnumerable<Employer>> GetAll();
        Task AddAsync(EmployerVM employer);   
        Task UpdateAsync(EmployerVM employer, Employer data);

    }
}
