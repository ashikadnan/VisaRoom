using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisaRoom.Models;

namespace VisaRoom.Data.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _context;
        public CompanyService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Company company)
        {
            await _context.Company.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            var result = await _context.Company.ToListAsync();
            return result;
        }

        public async Task<Company> GetById(int id)
        {
            var result = await _context.Company.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Company> UpdateAsync(int id, Company newCompany)
        {
            newCompany.Id = id;
            _context.Company.Update(newCompany);
            await _context.SaveChangesAsync();
            return newCompany;
        }

        public async Task Delete(int id)
        {
            var result = _context.Company.FirstOrDefault(n => n.Id == id);
            _context.Company.Remove(result);
            await _context.SaveChangesAsync();
        
;       }

    }
}
