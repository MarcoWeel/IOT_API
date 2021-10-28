using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT_ArduinoDashboard.Models
{
    public class ArduinoRequestModel
    {
        public ArduinoModel ArduinoModel { get; private set; }
        public List<DigitalPin> DigitalPins { get; private set; }
        public List<AnaloguePin> AnaloguePins { get; private set; }
    }
}
