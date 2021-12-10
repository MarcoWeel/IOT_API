using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_ArduinoDashboard.Services;
using Nancy.Json;

namespace IOT_ArduinoDashboard.Logic.TimeSender
{
    public class TimeSender
    {
        private RequestSender sender = new RequestSender();
        public void SendTime(string ip)
        {
            string URL = $"http://{ip}/time";
            string json = new JavaScriptSerializer().Serialize(new
            {
                time = DateTime.Now
            });
            sender.SendGenericRequest(URL, json);
        }
    }
}
