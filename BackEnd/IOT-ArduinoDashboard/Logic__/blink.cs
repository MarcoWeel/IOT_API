using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_ArduinoDashboard.Services;
using Nancy.Json;

namespace IOT_ArduinoDashboard.Logic__
{
    public class blink
    {
        private RequestSender sender = new RequestSender();
        public bool SendBlink(string ip, string pinName, int pinType, double state)
        {
            string URL = $"http://{ip}/body";
            return sender.SendPinStateRequest(URL, pinName,pinType, state);
        }
    }
}
