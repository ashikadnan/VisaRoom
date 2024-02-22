using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VisaRoom.Models;

namespace VisaRoom.Data.Services
{
    public class VisaTypeService : IVisaTypeServices
    {
        private readonly AppDbContext _context;
        public VisaTypeService(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(VisaType visaType)
        {
            await _context.VisaType.AddAsync(visaType);
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.VisaType.FirstOrDefaultAsync(n=> n.Id == id);
            _context.VisaType.Remove(data);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<VisaType>> GetAll()
        {
            var data = await _context.VisaType.ToListAsync();
            return data;
        }

        public async Task<VisaType> GetById(int id)
        {
            var result = await _context.VisaType.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<VisaType> UpdateAsync(int id, VisaType newVisaType)
        {
            newVisaType.Id = id;
            _context.VisaType.Update(newVisaType);
            await _context.SaveChangesAsync();
            return newVisaType;
        }
    }
}
