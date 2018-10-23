using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using unsw_app.Data;
using unsw_app.Models.Entities;
using unsw_app.ViewModels;

namespace unsw_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminUser")]
    public class AdminController : ControllerBase
    {
        private ApplicationDbContext _db;
        public AdminController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        [HttpGet("medicalusers")]
        public IActionResult GetUsers() {
            var users = _db.MedicalUsers.Join(_db.AppUsers, m => m.IdentityId, u => u.Id, (m, u) => new { firstname = u.FirstName, lastname = u.LastName, username = u.UserName, activated = m.Activated }).ToList();
            var json = JsonConvert.SerializeObject(new { users });
            return new OkObjectResult(json);
        }
        [HttpPost("editusers")]
        public IActionResult EditUsers([FromBody] List<MedicalUserViewModel> medicalUsers)
        {
            foreach (MedicalUserViewModel mu in medicalUsers) {
                var user = _db.AppUsers.FirstOrDefault(x => x.UserName == mu.Username);
                var medicalUser = _db.MedicalUsers.FirstOrDefault(x => x.IdentityId == user.Id);
                medicalUser.Activated = mu.Activated;
            }
            _db.SaveChanges();
            var users = _db.MedicalUsers.Join(_db.AppUsers, m => m.IdentityId, u => u.Id, (m, u) => new { firstname = u.FirstName, lastname = u.LastName, username = u.UserName, activated = m.Activated }).ToList();
            var json = JsonConvert.SerializeObject(new { users });
            return new OkObjectResult(json);
        }
    }
}