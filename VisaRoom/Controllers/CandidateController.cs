using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VisaRoom.Data;
using VisaRoom.Data.Services;
using VisaRoom.Data.ViewModels;
using VisaRoom.Models;

namespace VisaRoom.Controllers
{
    
    public class CandidateController : Controller
    {
        private readonly ICandidateService _service;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public CandidateController(ICandidateService service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()


        {
            var data = await _service.GetAllAsync(x => x.ApplyCountryObj, x => x.VisaTypeObj);
            return View(data);
        }

        public async Task<IActionResult> GetByIds(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return View(result);
        }

        
        public IActionResult CandidateHome()
        {
            return View("CandidateHome");
        }
        [HttpGet]
        public async Task <IActionResult> Details(int id)
            
        {
               var result = await _service.GetById(id);
               return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> CDetails()

        {
            string newUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _service.GetByUserId(newUser);
            var candidate = await _service.GetById(result.Id);
            
            return View(candidate);
        }       
        public async Task<IActionResult> Create()
        {
            string exUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _service.GetByUserId(exUser);
            if(result != null)
            {
                return RedirectToAction(nameof(CandidateHome));
            }
            
            var dropDownValues = await _service.GetNewCandidateDropdownValues();
            ViewBag.Companiess = new SelectList(dropDownValues.Companies, "Id", "CompanyName");
            ViewBag.Acountryid = new SelectList(dropDownValues.ApplyCountries, "Id", "ApplyCountryName");
            ViewBag.Vtypeid = new SelectList(dropDownValues.VisaTypes, "Id", "VisaTypeName");

            return View();
        }

        [HttpPost]       
        public async Task<IActionResult> Create(CandidateVM candidateVM)
        {

            if (!ModelState.IsValid)
            {
                var dropDownValues = await _service.GetNewCandidateDropdownValues();
                ViewBag.Companiess = new SelectList(dropDownValues.Companies, "Id", "CompanyName");
                ViewBag.Acountryid = new SelectList(dropDownValues.ApplyCountries, "Id", "ApplyCountryName");
                ViewBag.Vtypeid = new SelectList(dropDownValues.VisaTypes, "Id", "VisaTypeName");
                return View(candidateVM);
            }

            string userNew= User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _service.AddAsync(candidateVM, userNew);
            return RedirectToAction(nameof(CandidateHome));
        }
      
        public async Task<IActionResult> CEdit()
        {

            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var candidateId = await _service.GetByUserId(user);
            var result = await _service.GetById(candidateId.Id);

            var qual = new Qualification();
            var exp = new Experience();
            //var result = await _service.GetById(id);

            if (result == null)
            {
                return View("Empty");
            }

            foreach (var item in result.Candidate_QualificationsObj)
            {
                qual.InstituteName = item.Qualification.InstituteName;
                qual.DegreeName = item.Qualification.DegreeName;
                qual.DurationYear = item.Qualification.DurationYear;
                qual.PassingYear = item.Qualification.PassingYear;
                qual.SchoolResult = item.Qualification.SchoolResult;

                qual.InstituteName2 = item.Qualification.InstituteName2;
                qual.DegreeName2 = item.Qualification.DegreeName2;
                qual.DurationYear2 = item.Qualification.DurationYear2;
                qual.PassingYear2 = item.Qualification.PassingYear2;
                qual.CollegeResult = item.Qualification.CollegeResult;

                qual.InstituteName3 = item.Qualification.InstituteName3;
                qual.DegreeName3 = item.Qualification.DegreeName3;
                qual.DurationYear3 = item.Qualification.DurationYear3;
                qual.PassingYear3 = item.Qualification.PassingYear3;
                qual.BachelorResult = item.Qualification.BachelorResult;

                qual.InstituteName4 = item.Qualification.InstituteName4;
                qual.DegreeName4 = item.Qualification.DegreeName4;
                qual.DurationYear4 = item.Qualification.DurationYear4;
                qual.PassingYear4 = item.Qualification.PassingYear4;
                qual.MasterResult = item.Qualification.MasterResult;
            };

            foreach (var items in result.Candidate_ExperienceObj)
            {
                exp.OrganizationName = items.Experience.OrganizationName;
                exp.DesignationName = items.Experience.DesignationName;
                exp.LocationName = items.Experience.LocationName;
                exp.YearsExperience = items.Experience.YearsExperience;
            };

            var data = new CandidateVM()
            {
                Id = result.Id,
                CandidateUserId = result.CandidateUserId,
                CandidateName = result.CandidateName,
                CandidateCity = result.CandidateCity,
                CandidateCountry = result.CandidateCountry,
                CandidatePhone = result.CandidatePhone,
                Gender = result.Gender,
                ApplyCountryId = result.ApplyCountryId,
                VisaTypeId = result.VisaTypeId,
                CompanyIds = result.Candidate_CompanyObj.Select(x => x.ComapnyId).ToList(),
                CandidateImage = result.CandidateImage,
                Certificate = result.Certificate,
                Certificate2 = result.Certificate2,
                Certificate3 = result.Certificate3,
                Certificate4 = result.Certificate4,
                Experience = exp,
                Qualification = qual,

            };

            var dropDownValues = await _service.GetNewCandidateDropdownValues();
            ViewBag.Companiess = new SelectList(dropDownValues.Companies, "Id", "CompanyName");
            ViewBag.Acountryid = new SelectList(dropDownValues.ApplyCountries, "Id", "ApplyCountryName");
            ViewBag.Vtypeid = new SelectList(dropDownValues.VisaTypes, "Id", "VisaTypeName");

            return View(data);
        }   
        public async Task<IActionResult> Edit(int id)
        {

            var qual =new Qualification();
            var exp = new Experience(); 
            var result = await _service.GetById(id);

            if (result == null)
            {
                return View("Empty");
            }

            foreach(var item in result.Candidate_QualificationsObj)
            {
                qual.InstituteName = item.Qualification.InstituteName;
                qual.DegreeName = item.Qualification.DegreeName;
                qual.DurationYear = item.Qualification.DurationYear;
                qual.PassingYear = item.Qualification.PassingYear;  
                qual.SchoolResult = item.Qualification.SchoolResult;

                qual.InstituteName2 = item.Qualification.InstituteName2;
                qual.DegreeName2 = item.Qualification.DegreeName2;
                qual.DurationYear2 = item.Qualification.DurationYear2;
                qual.PassingYear2 = item.Qualification.PassingYear2;
                qual.CollegeResult = item.Qualification.CollegeResult;

                qual.InstituteName3 = item.Qualification.InstituteName3;
                qual.DegreeName3 = item.Qualification.DegreeName3;
                qual.DurationYear3 = item.Qualification.DurationYear3;
                qual.PassingYear3 = item.Qualification.PassingYear3;
                qual.BachelorResult = item.Qualification.BachelorResult;

                qual.InstituteName4 = item.Qualification.InstituteName4;
                qual.DegreeName4 = item.Qualification.DegreeName4;
                qual.DurationYear4 = item.Qualification.DurationYear4;
                qual.PassingYear4 = item.Qualification.PassingYear4;
                qual.MasterResult = item.Qualification.MasterResult;
            };

            foreach(var items in result.Candidate_ExperienceObj)
            {
                exp.OrganizationName = items.Experience.OrganizationName;
                exp.DesignationName = items.Experience.DesignationName;
                exp.LocationName = items.Experience.LocationName;
                exp.YearsExperience = items.Experience.YearsExperience;
            };

            var data = new CandidateVM()
            {
                Id = result.Id,
                CandidateUserId = result.CandidateUserId,
                CandidateName = result.CandidateName,
                CandidateCity = result.CandidateCity,
                CandidateCountry = result.CandidateCountry,
                CandidatePhone = result.CandidatePhone,
                Gender = result.Gender,
                ApplyCountryId = result.ApplyCountryId,
                VisaTypeId = result.VisaTypeId,
                CompanyIds = result.Candidate_CompanyObj.Select(x => x.ComapnyId).ToList(),
                CandidateImage = result.CandidateImage,
                Certificate = result.Certificate,
                Certificate2 = result.Certificate2,
                Certificate3 = result.Certificate3,
                Certificate4 = result.Certificate4,
                Qualification = qual,
                Experience = exp,
               
            };

            var dropDownValues = await _service.GetNewCandidateDropdownValues();
            ViewBag.Companiess = new SelectList(dropDownValues.Companies, "Id", "CompanyName");
            ViewBag.Acountryid = new SelectList(dropDownValues.ApplyCountries, "Id", "ApplyCountryName");
            ViewBag.Vtypeid = new SelectList(dropDownValues.VisaTypes, "Id", "VisaTypeName");

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CandidateVM candidateVM)
        {

            //var data = await _service.GetByCandidateIdAsync(id, (x => x.Candidate_CompanyObj));

            if (!ModelState.IsValid)
            {
                var dropDownValues = await _service.GetNewCandidateDropdownValues();
                ViewBag.Companiess = new SelectList(dropDownValues.Companies, "Id", "CompanyName");
                ViewBag.Acountryid = new SelectList(dropDownValues.ApplyCountries, "Id", "ApplyCountryName");
                ViewBag.Vtypeid = new SelectList(dropDownValues.VisaTypes, "Id", "VisaTypeName");
                return View(candidateVM);
            }

            await _service.UpdateAsync(candidateVM, id);
            return RedirectToAction(nameof(CandidateHome));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }       
        public async Task<IActionResult> CDelete()
        {
            var newUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _service.GetByUserId(newUser);
            await _service.DeleteAsync(result.Id);
            return RedirectToAction(nameof(CandidateHome));
        }

        public async Task<IActionResult> ApprovedRequestList()
        {
            var allCandidate = await _service.GetAll();
            var approveList = new List<Candidate>();
            foreach (var item in allCandidate)
            {
                foreach(var items in item.Approved_RequestsObj)
                {
                    if(items.CandidateId == item.Id)
                    {
                        approveList.Add(item);
                    }
                }
            }
            return View(approveList);

        }

    }
}
