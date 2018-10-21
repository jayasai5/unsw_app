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
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<MedicalUser> MedicalUsers { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
    }
}
