using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT_ArduinoDashboard.Models
{
    public class PinRequestModel
    {
        //public List<DigitalPin> DigitalPins { get; private set; }
        //public List<AnaloguePin> AnaloguePins { get; private set; }
        public ArduinoModel ArduinoModel;
        public string pinNameString;
        public Pin.Mode pinMode;
        public Type pinType;
        public int ArduinoId;

        public enum Type
        {
            analogue,
            digital
        }
    }
}
