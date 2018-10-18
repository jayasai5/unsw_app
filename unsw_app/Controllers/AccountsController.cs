using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using unsw_app.Data;
using unsw_app.Models;
using unsw_app.Models.Entities;

namespace unsw_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        ApplicationDbContext _db;
        public AccountsController(ApplicationDbContext context)
        {
            _db = context;
        }
        [HttpPost("createuser")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUser user)
        {
            var admin = _db.Users.Where(u => u.Username == user.AdminPassword&& u.Password == user.AdminPassword).FirstOrDefault();
            if (admin == null)
            {
                return BadRequest();
            }
            else {
                try
                {
                    await _db.AddAsync<User>(new User() { Username = user.Username, Password = user.Password, Role = "Staff" });
                    await _db.SaveChangesAsync();
                }
                catch (Exception e) {
                    return BadRequest();
                }
                
            }


            return new OkResult();
        }
    }
}