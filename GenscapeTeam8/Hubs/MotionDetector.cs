using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace GenscapeTeam8
{
    public class MotionDetector : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}