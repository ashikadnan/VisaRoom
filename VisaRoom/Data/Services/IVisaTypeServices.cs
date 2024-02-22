using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using VisaRoom.Models;

namespace VisaRoom.Data.Services
{
    public interface IVisaTypeServices
    {
        Task <IEnumerable<VisaType>> GetAll();
        Task <VisaType> GetById(int id);
        Task <VisaType> UpdateAsync(int id, VisaType newVisaType);
        Task AddAsync(VisaType visaType); 
        Task DeleteAsync(int id);   

        
    }
}
