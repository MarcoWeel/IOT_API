using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT_ArduinoDashboard.Services.Objects;

namespace IOT_ArduinoDashboard.Services
{
    public class RequestReceiver
    {
        private StateManager Manager;
        public RequestReceiver(StateManager manager)
        {
            Manager = manager;
        }

        
        public void ProcessRequest(string PinName, double State, int id)
        {
            int arduinoIndex = Manager.Arduinos.FindIndex(r => r.Id == id);
            if (arduinoIndex >= 0)
            {
                int pinIndex = Manager.Arduinos[arduinoIndex].Pins.FindIndex(r => r.PinName == PinName);
                if (pinIndex >= 0)
                {
                    Manager.ChangeState(arduinoIndex, pinIndex, State);
                }
            }
        }

        public void SignUpArduino(int id, string ip, List<int> usedCommands)
        {
            Manager.AddArduino(new Arduino{Id = id, Ip = ip, Pins = new List<Pin>(), UsedCommands = usedCommands});
        }

        public void SignUpPin(Pin pin, int id)
        {
            int index = Manager.Arduinos.FindIndex(r => r.Id == id);
            if (index >= 0)
            {
                Manager.Arduinos[index].Pins.Add(pin);
            }
        }
    }
}
