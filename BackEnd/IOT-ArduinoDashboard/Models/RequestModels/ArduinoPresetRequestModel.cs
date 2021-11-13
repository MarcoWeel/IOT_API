using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IOT_ArduinoDashboard.Models
{
    public class ArduinoPresetRequestModel
    {
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        public List<DigitalPin> DigitalPinCount { get; set; }
        public List<AnaloguePin> AnaloguePinCount { get; set; }
    }
}
