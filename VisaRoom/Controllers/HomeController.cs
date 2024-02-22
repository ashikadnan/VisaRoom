using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VisaRoom.Data.Services;
using VisaRoom.Models;

namespace VisaRoom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICandidateService _candidate;

        public HomeController(ILogger<HomeController> logger, ICandidateService candidate)
        {
            _logger = logger;
            _candidate = candidate;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }

        public async Task<IActionResult> MyRequests()
        {
            var requestList = new List<Candidate>();
            var result = await _candidate.GetAll();
            foreach (var item in result)
            {
                foreach (var items in item.Employer_RequestObj)
                {
                    if (items!=null)
                    {
                        requestList.Add(item);
                    }
                }
            }
            return View(requestList);
        }

        public async Task<IActionResult> ApprovedRequest(int id, string user)
        {
          
            await _candidate.ApprovedRequest(id, user);
            return RedirectToAction("AdminDashboard");   

            

        }

        public IActionResult Privacy()
        {
            return View();

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
