using VisaRoom.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisaRoom.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Candidate_Company>().HasKey(am => new
            {
                am.CandidateId,
                am.ComapnyId
            });

            modelBuilder.Entity<Candidate_Company>().HasOne(c => c.Candidate).WithMany(am => am.Candidate_CompanyObj).HasForeignKey(c => c.CandidateId);
            modelBuilder.Entity<Candidate_Company>().HasOne(cm => cm.Company).WithMany(am => am.Candidate_CompanyObj).HasForeignKey(cm => cm.ComapnyId);

            modelBuilder.Entity<Candidate_Qualification>().HasKey(am => new
            {
                am.CandidateId,
                am.QualificationId
            });
            modelBuilder.Entity<Candidate_Qualification>().HasOne(x => x.Candidate).WithMany(am => am.Candidate_QualificationsObj).HasForeignKey(x => x.CandidateId);
            modelBuilder.Entity<Candidate_Qualification>().HasOne(y => y.Qualification).WithMany(am => am.CandidateQualificationsObj).HasForeignKey(y => y.QualificationId);

            modelBuilder.Entity<Candidate_Experience>().HasKey(am => new
            {
                am.CandidateId,
                am.ExperienceId
            });
            modelBuilder.Entity<Candidate_Experience>().HasOne(x => x.Candidate).WithMany(am => am.Candidate_ExperienceObj).HasForeignKey(x => x.CandidateId);
            modelBuilder.Entity<Candidate_Experience>().HasOne(y => y.Experience).WithMany(am => am.CandidateExperienceObj).HasForeignKey(y => y.ExperienceId);

            modelBuilder.Entity<Candidate_Employer>().HasKey(am => new
            {
                
                am.EmployerId,
                am.CandidateId
            });

            modelBuilder.Entity<Candidate_Employer>().HasOne(y => y.Employer).WithMany(am => am.CandidateEmployerObject).HasForeignKey(y => y.EmployerId);
            modelBuilder.Entity<Candidate_Employer>().HasOne(x => x.Candidate).WithMany(am => am.Candidate_EmployerObj).HasForeignKey(x => x.CandidateId);

            modelBuilder.Entity<Employer_Request>().HasKey(am => new
            {
                am.UserId,
                am.CandidateId
            });

            modelBuilder.Entity<Employer_Request>().HasOne(y => y.User).WithMany(am => am.Employer_RequestObject).HasForeignKey(y => y.UserId);
            modelBuilder.Entity<Employer_Request>().HasOne(x=>x.Candidate).WithMany(am=>am.Employer_RequestObj).HasForeignKey(x=>x.CandidateId);

            modelBuilder.Entity<Approved_Requests>().HasKey(am => new
            {
                am.UserId,
                am.CandidateId
            });

            modelBuilder.Entity<Approved_Requests>().HasOne(y => y.User).WithMany(am => am.Approved_RequestsObject).HasForeignKey(y => y.UserId);
            modelBuilder.Entity<Approved_Requests>().HasOne(x => x.Candidate).WithMany(am => am.Approved_RequestsObj).HasForeignKey(x => x.CandidateId);
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Employer> Employer { get; set; }
        public DbSet<ApplyCountry> ApplyCountry { get; set; }
        public DbSet<VisaType> VisaType { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet <Experience> Experiences { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }    
        public DbSet<Candidate_Company> Candidates_Companies { get; set; }
        public DbSet<Candidate_Qualification> Candidates_Qualifications { get; set; }
        public DbSet<Candidate_Experience> Candidates_Experiences { get; set; }
        public DbSet<Candidate_Employer> Candidate_Employer { get; set; }
        public DbSet<Employer_Request> Employer_Requests { get; set; }  
        public DbSet<Approved_Requests> Approved_Requests { get; set; }
    }
}
