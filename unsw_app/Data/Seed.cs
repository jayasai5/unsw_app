using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using unsw_app.Models.Entities;

namespace unsw_app.Data
{
    public static class Seed
    {
        
        public static async Task CreateAdminUser(IServiceProvider serviceProvider, IConfiguration Configuration) {
            var db = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var admin = new User
            {
                Username = Configuration.GetSection("AppSettings")["UserEmail"],
                Password = Configuration.GetSection("AppSettings")["UserPassword"],
                Role = "Admin"
            };
            //var user = db.Users.FirstOrDefault(u => u.Username == Configuration.GetSection("AppSettings")["UserEmail"]);
        }
    }
}
