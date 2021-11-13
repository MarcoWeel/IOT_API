using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT_ArduinoDashboard.Models
{
    public class PinRequestModel
    {
        public int Id { get; set; }
        public ArduinoModel ArduinoModel { get; set; }
        public string pinNameString { get; set; }
        public Pin.Mode pinMode { get; set; }
        public Type pinType { get; set; }
        public int ArduinoId { get; set; }

        public enum Type
        {
            analogue,
            digital
        }
    }
}
