using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_ArduinoDashboard.Services;

namespace IOT_ArduinoDashboard.Logic__
{
    public class TafelBoorVoorbeeld__
    {
        private string RelayPin1;
        private string RelayPin2;
        public string ButtonPin1;
        public string ButtonPin2;

        private double relayValue1 = 0;
        private double relayValue2 = 0;

        private RequestSender sender = new RequestSender();

        /// <summary>
        /// All pins have to be digital and correspond to pins on the arduino that uses this command
        /// </summary>
        /// <param name="relayPin1"></param>
        /// <param name="relayPin2"></param>
        /// <param name="buttonPin1"></param>
        /// <param name="buttonPin2"></param>
        public TafelBoorVoorbeeld__(string relayPin1, string relayPin2, string buttonPin1, string buttonPin2)
        {
            RelayPin1 = relayPin1;
            RelayPin2 = relayPin2;
            ButtonPin1 = buttonPin1;
            ButtonPin2 = buttonPin2;
        }

        public void ChangeState(string pinName, double state, string ip)
        {
            if (state != 0 && state != 1)
            {
                return;
            }

            if (pinName == ButtonPin1)
            {
                relayValue1 = state;
                if (relayValue1 == 1 && relayValue2 == 1)
                {
                    relayValue2 = 0;
                }
            }
            else if (pinName == ButtonPin2)
            {
                relayValue2 = state;
                if (relayValue1 == 1 && relayValue2 == 1)
                {
                    relayValue1 = 0;
                }
            }
            SendRelayValue(ip, RelayPin1, relayValue1);
            SendRelayValue(ip, RelayPin2, relayValue2);
        }
        private bool SendRelayValue(string ip, string pinName, double state)
        {
            string URL = $"http://{ip}/body";
            return sender.SendPinStateRequest(URL, pinName, 1, state);
        }
    }
}
