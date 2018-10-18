using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace unsw_app.Hubs.Clients
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(int patientId, string occupation);
    }
}
