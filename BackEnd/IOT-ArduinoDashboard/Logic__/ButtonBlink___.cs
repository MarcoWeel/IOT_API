using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_ArduinoDashboard.Services;

namespace IOT_ArduinoDashboard.Logic__
{
    public class ButtonBlink___
    {
        private RequestSender sender = new RequestSender();
        public bool SendBlinkButton(string ip, double state, string buttonPinName)
        {
            if (buttonPinName == "14")
            {
                string URL = $"http://{ip}/body";
                return sender.SendPinStateRequest(URL, "2", 1, state);
            }
            else
            {
                return true;
            }
        }
    }
}
