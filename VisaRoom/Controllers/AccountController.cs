using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VisaRoom.Data;
using VisaRoom.Data.Static;
using VisaRoom.Data.ViewModels;
using VisaRoom.Models;

namespace VisaRoom.Controllers
{
    public class AccountController : Controller
    {
   
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,AppDbContext context)
        {
            _userManager = userManager; 
            _signInManager = signInManager;
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            var response = new LoginVM();

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if(user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if(passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("AdminDashboard", "Home");
                      
                    }
                }

                TempData["Error"] = "Wrong Credentials! Try Again!";
                return View(loginVM);

            }
            TempData["Error"] = "Wrong Credentials! Try Again!";
            return View(loginVM);
        }


        public IActionResult CandidateLogin()
        {
            var response = new LoginVM();
            return View(response);
        }
        [HttpPost]
 
        public async Task<IActionResult> CandidateLogin(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("CandidateHome", "Candidate");

                    }
                }

                TempData["Error"] = "Wrong Credentials! Try Again!";
                return View(loginVM);

            }
            TempData["Error"] = "Wrong Credentials! Try Again!";
            return View(loginVM);
        }

 
        public IActionResult EmployerLogin()
        {
            var response = new LoginVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> EmployerLogin(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("EmployerHome", "Employer");

                    }
                }

                TempData["Error"] = "Wrong Credentials! Try Again!";
                return View(loginVM);

            }
            TempData["Error"] = "Wrong Credentials! Try Again!";
            return View(loginVM);
        }

        public IActionResult Register()
        {
            var response = new RegisterVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(!ModelState.IsValid)
            {
                return View(registerVM);
            }

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);

            if (user != null)
            {
                TempData["Error"] = "This E-mail address is already in use!";
                return View(registerVM);
            }

            var createUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress,
                
            };
            if ((int)registerVM.UserType == 0)
            {
                var newUserResponse = await _userManager.CreateAsync(createUser, registerVM.Password);
                if (newUserResponse.Succeeded)
                    await _userManager.AddToRoleAsync(createUser, UserRoles.Employer);
            }

            if ((int)registerVM.UserType == 1)
            {
                var newUserResponse = await _userManager.CreateAsync(createUser, registerVM.Password);
                if (newUserResponse.Succeeded)
                    await _userManager.AddToRoleAsync(createUser, UserRoles.Candidate);
            }
            /*var newUserResponse = await _userManager.CreateAsync(createUser, registerVM.Password);
            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(createUser, UserRoles.Candidate);*/

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
