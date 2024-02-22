using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VisaRoom.Models;

namespace VisaRoom.Data.Services
{
    public class ApplyCountryService : IApplyCountryService
    {
       private readonly AppDbContext _context;
        public ApplyCountryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ApplyCountry applyCountry)
        {
           await _context.ApplyCountry.AddAsync(applyCountry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.ApplyCountry.FirstOrDefaultAsync(x => x.Id == id);
            _context.ApplyCountry.Remove(result);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<ApplyCountry>> GetAllAsync()
        {
            var data = await _context.ApplyCountry.ToListAsync();
            return data;
        }

        public async Task <ApplyCountry> GetById(int id)
        {
            var result = await _context.ApplyCountry.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task <ApplyCountry> UpdateAsync(int id, ApplyCountry newApplyCountry)
        {
            newApplyCountry.Id = id;
            _context.ApplyCountry.Update(newApplyCountry);
            await _context.SaveChangesAsync();
            return newApplyCountry;
        }
    }
}
