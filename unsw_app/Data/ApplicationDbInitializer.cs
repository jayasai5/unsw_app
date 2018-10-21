using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using unsw_app.Models.Entities;

namespace unsw_app.Data
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<AppUser> userManager, ApplicationDbContext dbContext)
        {
            if (userManager.FindByEmailAsync("admin@admin.com").Result == null)
            {
                AppUser user = new AppUser
                {
                    FirstName = "admin",
                    LastName = "admin",
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PhoneNumber = "0404081397"
                };

                IdentityResult result = userManager.CreateAsync(user, "admin1234").Result;

                if (result.Succeeded)
                {
                    dbContext.AdminUsers.AddAsync(new AdminUser { IdentityId = user.Id }).Wait();
                    dbContext.SaveChangesAsync().Wait();
                }
            }
        }
    }
}
