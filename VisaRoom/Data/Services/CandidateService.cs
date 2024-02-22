using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VisaRoom.Data.Base;
using VisaRoom.Data.ViewModels;
using VisaRoom.Models;

namespace VisaRoom.Data.Services
{
    public class CandidateService : EntityBaseRepository<Candidate>, ICandidateService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CandidateService(AppDbContext context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        /*public async Task<IEnumerable<Candidate>> GetAllAsync()
        {
            var result = await _context.Candidate.
                Include(x => x.ApplyCountryObj).Include(x => x.VisaTypeObj).
                Include(x => x.Candidate_CompanyObj).ThenInclude(x => x.Company).ToListAsync();
            
            return result;  
        }*/

        public async Task<Candidate> GetById(int id)

        {
            var result = await _context.Candidate.Include(x => x.ApplyCountryObj).Include(x => x.VisaTypeObj).Include(x => x.Candidate_CompanyObj).ThenInclude(x => x.Company)
                .Include(ac => ac.ApplyCountryObj).Include(vt => vt.VisaTypeObj).Include(x => x.Candidate_ExperienceObj).ThenInclude(x => x.Experience).Include(x=>x.Candidate_QualificationsObj).
                ThenInclude(x=>x.Qualification).Include(x => x.Employer_RequestObj).ThenInclude(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            return result;  
            
        }

        



        public async Task AddAsync(CandidateVM newCandidateVM, string user)
        {

            string uniqueFileName = UploadedFile(newCandidateVM);
            string schoolCertificate = certificateFile(newCandidateVM);
            string collegeCertificate = certificate2File(newCandidateVM);
            string bachelorCertificate = certificate3File(newCandidateVM);
            string mastersCertificate = certificate4File(newCandidateVM);
            var newCandidate = new Candidate()
            {
                CandidateImage = uniqueFileName,
                CandidateUserId = user,
                CandidateName = newCandidateVM.CandidateName,
                CandidateCity = newCandidateVM.CandidateCity,
                CandidateCountry = newCandidateVM.CandidateCountry,
                CandidatePhone = newCandidateVM.CandidatePhone,
                Gender = newCandidateVM.Gender,
                ApplyCountryId = newCandidateVM.ApplyCountryId,
                VisaTypeId = newCandidateVM.VisaTypeId,
                Certificate = schoolCertificate,
                Certificate2 = collegeCertificate,  
                Certificate3 = bachelorCertificate, 
                Certificate4 = mastersCertificate,  

            };

            await _context.AddAsync(newCandidate);
            await _context.SaveChangesAsync();

            var experienceDb = new Experience()
            {
                OrganizationName = newCandidateVM.Experience.OrganizationName,
                DesignationName = newCandidateVM.Experience.DesignationName,
                YearsExperience = newCandidateVM.Experience.YearsExperience,
                LocationName = newCandidateVM.Experience.LocationName,

            };


            await _context.Experiences.AddAsync(experienceDb);
            await _context.SaveChangesAsync();

            var CandidatExperience = new Candidate_Experience()
            {
                CandidateId = newCandidate.Id,
                ExperienceId = experienceDb.Id

            };
            await _context.Candidates_Experiences.AddAsync(CandidatExperience);
            await _context.SaveChangesAsync();

            var qualificationDb = new Qualification()
            {
                InstituteName = newCandidateVM.Qualification.InstituteName,
                DegreeName = newCandidateVM.Qualification.DegreeName,
                DurationYear = newCandidateVM.Qualification.DurationYear,
                PassingYear = newCandidateVM.Qualification.DurationYear,
                SchoolResult = newCandidateVM.Qualification.SchoolResult,

                InstituteName2 = newCandidateVM.Qualification.InstituteName2,
                DegreeName2 = newCandidateVM.Qualification.DegreeName2,
                DurationYear2 = newCandidateVM.Qualification.DurationYear2,
                PassingYear2 = newCandidateVM.Qualification.DurationYear2,
                CollegeResult = newCandidateVM.Qualification.CollegeResult,

                InstituteName3 = newCandidateVM.Qualification.InstituteName3,
                DegreeName3 = newCandidateVM.Qualification.DegreeName,
                DurationYear3 = newCandidateVM.Qualification.DurationYear,
                PassingYear3 = newCandidateVM.Qualification.DurationYear,
                BachelorResult = newCandidateVM.Qualification.BachelorResult,

                InstituteName4 = newCandidateVM.Qualification.InstituteName,
                DegreeName4 = newCandidateVM.Qualification.DegreeName,
                DurationYear4 = newCandidateVM.Qualification.DurationYear,
                PassingYear4 = newCandidateVM.Qualification.DurationYear,
                MasterResult = newCandidateVM.Qualification.MasterResult,

            };
            await _context.Qualifications.AddAsync(qualificationDb);
            await _context.SaveChangesAsync();

            var CandidateQualification = new Candidate_Qualification()
            {
                CandidateId = newCandidate.Id,
                QualificationId = qualificationDb.Id,
            };
            await _context.Candidates_Qualifications.AddAsync(CandidateQualification);
            await _context.SaveChangesAsync();


            foreach (var companyId in newCandidateVM.CompanyIds)
            {
                var CandidateMovie = new Candidate_Company()
                {
                    CandidateId = newCandidate.Id,
                    ComapnyId = companyId
                };
                await _context.Candidates_Companies.AddAsync(CandidateMovie);

            }
            await _context.SaveChangesAsync();
        }

        private string UploadedFile(CandidateVM model)
        {
            string uniqueFileName = null;

            if (model.CandidateImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CandidateImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CandidateImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        private string certificateFile(CandidateVM model)
        {
            string schoolCertificate = null;

            if (model.CertificateImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                schoolCertificate = Guid.NewGuid().ToString() + "_" + model.CertificateImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, schoolCertificate);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CertificateImageFile.CopyTo(fileStream);
                }
            }
            return schoolCertificate;
        }

        private string certificate2File(CandidateVM model)
        {
            string collegeCertificate = null;

            if (model.Certificate2ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                collegeCertificate = Guid.NewGuid().ToString() + "_" + model.Certificate2ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, collegeCertificate);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Certificate2ImageFile.CopyTo(fileStream);
                }
            }
            return collegeCertificate;
        }

        private string certificate3File(CandidateVM model)
        {
            string bachelorCertificate = null;

            if (model.Certificate3ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                bachelorCertificate = Guid.NewGuid().ToString() + "_" + model.Certificate3ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, bachelorCertificate);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Certificate3ImageFile.CopyTo(fileStream);
                }
            }
            return bachelorCertificate;
        }

        private string certificate4File(CandidateVM model)
        {
            string mastersCertificate = null;

            if (model.Certificate4ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                mastersCertificate = Guid.NewGuid().ToString() + "_" + model.Certificate4ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, mastersCertificate);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Certificate4ImageFile.CopyTo(fileStream);
                }
            }
            return mastersCertificate;
        }

        public async Task UpdateAsync(CandidateVM newCandidateVM, Candidate data)
        {
            //var data = await _context.Candidate.FirstOrDefaultAsync(x=> x.Id == newCandidateVM.Id);

            string uniqueFileName = UploadedFiles(newCandidateVM);
            if (data != null)
            {
                data.CandidateImage = newCandidateVM.CandidateImage;
                data.CandidateName = newCandidateVM.CandidateName;
                data.CandidateCity = newCandidateVM.CandidateCity;
                data.CandidateCountry = newCandidateVM.CandidateCountry;
                data.CandidatePhone = newCandidateVM.CandidatePhone;
                data.Gender = newCandidateVM.Gender;
                data.ApplyCountryId = newCandidateVM.ApplyCountryId;
                data.VisaTypeId = newCandidateVM.VisaTypeId;
                data.CandidateImage = newCandidateVM.CandidateImage;

            }



            _context.Update(data);
            await _context.SaveChangesAsync();

            var existingCompanyDb = _context.Candidates_Companies.Where(n => n.CandidateId == data.Id).ToList();
            _context.Candidates_Companies.RemoveRange(existingCompanyDb);
            await _context.SaveChangesAsync();

            //Add Actors

            foreach (var companyid in newCandidateVM.CompanyIds)
            {
                var newActorMovie = new Candidate_Company()
                {
                    CandidateId = newCandidateVM.Id,
                    ComapnyId = companyid
                };
                await _context.Candidates_Companies.AddAsync(newActorMovie);

            }
            await _context.SaveChangesAsync();
        }

        private string UploadedFiles(CandidateVM model)
        {
            string uniqueFileName = null;

            if (model.CandidateImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CandidateImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CandidateImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        /*public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }*/

        public async Task<NewCandidateDropdownVM> GetNewCandidateDropdownValues()
        {
            var result = new NewCandidateDropdownVM()
            {
                Companies = await _context.Company.OrderBy(x => x.CompanyName).ToListAsync(),
                ApplyCountries = await _context.ApplyCountry.OrderBy(x => x.ApplyCountryName).ToListAsync(),
                VisaTypes = await _context.VisaType.OrderBy(x => x.VisaTypeName).ToListAsync()
            };

            return result;

        }

        public async Task EmployerRequest(int id, string userId)
        {
            var emp = new Employer_Request()
            {
                CandidateId = id,   
                UserId = userId
            };

            await _context.Employer_Requests.AddAsync(emp);
            await _context.SaveChangesAsync();
            
            
        }

        public async Task ApprovedRequest(int id, string user)
        {
            var approveRequests = new Approved_Requests()
            {
                CandidateId = id,
                UserId = user,
            };
            

            await _context.Approved_Requests.AddAsync(approveRequests);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Candidate>> GetAll()
        {
            var allCandidates = await _context.Candidate.Include(x => x.ApplyCountryObj).Include(x => x.VisaTypeObj).Include(x => x.Candidate_CompanyObj).ThenInclude(x => x.Company)
                .Include(ac => ac.ApplyCountryObj).Include(vt => vt.VisaTypeObj).Include(x => x.Candidate_ExperienceObj).
                ThenInclude(x => x.Experience).Include(x => x.Candidate_QualificationsObj).
                ThenInclude(x => x.Qualification).Include(x => x.Employer_RequestObj).ThenInclude(x => x.User).ToListAsync();
            return allCandidates;
            
        }

        public async Task<Candidate> GetByUserId(string user)

        {
            var result = await _context.Candidate.FirstOrDefaultAsync(x => x.CandidateUserId == user);
            return result;

        }

     

    }




}

