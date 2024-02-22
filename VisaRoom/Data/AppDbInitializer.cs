using VisaRoom.Data.Static;
using VisaRoom.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisaRoom.Data
{
    public class AppDbInitializer
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.Employer))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Employer));

                if (!await roleManager.RoleExistsAsync(UserRoles.Candidate))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Candidate));

                //User

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string adminUserEmail = "admin@visaroom.com";
                var adminUser = await userManager.FindByEmailAsync("admin@visaroom.com");
                if(adminUser == null)
                {
                    var newadminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newadminUser, "Admin@123?");
                    await userManager.AddToRoleAsync(newadminUser, UserRoles.Admin);
                }

                string candidateUserEmail = "candidate@visaroom.com";
                var appUser = await userManager.FindByEmailAsync(candidateUserEmail);
                if (adminUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Candidate User",
                        UserName = "candidate-user",
                        Email = candidateUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Candidate@123?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.Candidate);
                }

                string EmpUserEmail = "employer@visaroom.com";
                var empUser = await userManager.FindByEmailAsync(EmpUserEmail);
                if (adminUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Employer User",
                        UserName = "employer-user",
                        Email = EmpUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Employer@123?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.Employer);
                }

            }
        }
     }
 }
    

