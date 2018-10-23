using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using unsw_app.Data;
using unsw_app.Hubs;
using unsw_app.Hubs.Clients;
using unsw_app.Models;

namespace unsw_app.Controllers
{
    [Produces("application/json")]
    [Route("api/Message")]
    public class MessageController : Controller
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;
        private ApplicationDbContext _db;
        public MessageController(IHubContext<NotifyHub, ITypedHubClient> hubContext,ApplicationDbContext dbContext) {
            _hubContext = hubContext;
            _db = dbContext;
        }

        [HttpPost]
        public string Post([FromBody]Message msg)
        {
            string retMessage = string.Empty;

            try
            {
                var patient = _db.Patients.Find(msg.PatientId);
                patient.Occupation = msg.Occupation;
                _db.SaveChanges();
                _hubContext.Clients.All.BroadcastMessage(msg.PatientId, msg.Occupation); 
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }

            return retMessage;
        }
        [HttpGet("patients")]
        [Authorize(Policy = "ApiUser")]
        public IActionResult GetPatients() {
            var patients = _db.Patients.ToList();
            JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
            return new OkObjectResult(new { patients });
        }
        
    }
}