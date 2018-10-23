using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using unsw_app.Models.Entities;

namespace unsw_app.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Patient>().HasData(new Patient {PatientId=1,PatientName = "patient_1",Occupation = "kitchen"});
            builder.Entity<Patient>().HasData(new Patient { PatientId = 2, PatientName = "patient_2", Occupation = "living room" });
            builder.Entity<Patient>().HasData(new Patient { PatientId = 3, PatientName = "patient_3", Occupation = "bath room" });
            builder.Entity<Patient>().HasData(new Patient { PatientId = 4, PatientName = "patient_4", Occupation = "kitchen" });
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<MedicalUser> MedicalUsers { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
