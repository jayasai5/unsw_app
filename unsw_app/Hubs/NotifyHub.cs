using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using unsw_app.Hubs.Clients;

namespace unsw_app.Hubs
{
    public class NotifyHub:Hub<ITypedHubClient>
    {

    }
}
