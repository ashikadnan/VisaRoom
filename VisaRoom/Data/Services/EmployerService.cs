using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using VisaRoom.Data.Base;
using VisaRoom.Data.ViewModels;
using VisaRoom.Models;

namespace VisaRoom.Data.Services
{
    public class EmployerService : EntityBaseRepository<Employer>, IEmployerService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployerService(AppDbContext context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task AddAsync(EmployerVM employer, string user)
        {
            string uniqueFileName = UploadedFile(employer);
            var data = new Employer()
            {

                EmployerImage = uniqueFileName,
                EmployerName = employer.EmployerName,
                EmployerPhone = employer.EmployerPhone,
                EmployerCity = employer.EmployerCity,
                EmployerCountry = employer.EmployerCountry,
                EmployerCompany = employer.EmployerCompany,

            };
            data.UserId = user; 
            await _context.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        private string UploadedFile(EmployerVM model)
        {
            string uniqueFileName = null;

            if (model.EmployerImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.EmployerImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.EmployerImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        public async Task UpdateAsync(EmployerVM employer)
        {
            string uniqueFileName = UploadedFiles(employer);
            var employers = await _context.Employer.FirstOrDefaultAsync(x=>x.Id == employer.Id);

            if (employers != null)
            {
                employers.Id = employer.Id;
                employers.EmployerImage = employer.EmployerImage;
                employers.EmployerName = employer.EmployerName;
                employers.EmployerPhone = employer.EmployerPhone;
                employers.EmployerCity = employer.EmployerCity;
                employers.EmployerCountry = employer.EmployerCountry;
                employers.EmployerCompany = employer.EmployerCompany;
            }

            if (uniqueFileName != null)
            {
                employers.EmployerImage = uniqueFileName;
            }

            _context.Update(employers);
            await _context.SaveChangesAsync();


        }

        private string UploadedFiles(EmployerVM model)
        {
            string uniqueFileName = null;

            if (model.EmployerImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.EmployerImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.EmployerImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public async Task<Employer> GetAll(int id)
        {
            var result = await _context.Employer.FirstOrDefaultAsync(x=>x.Id == id);
            return result;
        }

        public async Task<Employer> GetByUserId(string userId)
        {
            var employer = await _context.Employer.FirstOrDefaultAsync(x => x.UserId == userId);
            return employer;
        }

        public async Task<Employer> GetById(int id)
        {
            var employer = await _context.Employer.FirstOrDefaultAsync(x=>x.Id == id);
            return employer;
        }
    }
    
}
