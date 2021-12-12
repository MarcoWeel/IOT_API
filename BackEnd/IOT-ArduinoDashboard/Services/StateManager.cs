using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT_ArduinoDashboard.Services.Objects;

namespace IOT_ArduinoDashboard.Services
{
    public class StateManager
    {
        public List<Arduino> Arduinos;
        public bool StateChanged = false;

        public StateManager()
        {
            Arduinos = new List<Arduino>();
        }

        public bool AddArduino(Arduino arduino)
        {
            int indexId = Arduinos.FindIndex(r => r.Id == arduino.Id);
            int indexIp = Arduinos.FindIndex(r => r.Ip == arduino.Ip);
            if (indexIp >= 0)
            {
                Arduinos.RemoveAt(indexIp);
                Arduinos.Add(arduino);
                StateChanged = true;
                return false;
            }
            else if (indexId >= 0)
            {
                Arduinos.RemoveAt(indexId);
                Arduinos.Add(arduino);
                StateChanged = true;
                return false;
            }
            else
            {
                Arduinos.Add(arduino);
                StateChanged = true;
                return true;
            }
        }

        public void ChangeState(int arduinoIndex, int pinIndex, double state)
        {
            Arduinos[arduinoIndex].Pins[pinIndex].SetState(state);
            StateChanged = true;
        }
    }
}
