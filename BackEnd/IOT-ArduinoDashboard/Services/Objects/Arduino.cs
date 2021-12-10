using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT_ArduinoDashboard.Services.Objects
{
    public class Arduino
    {
        public int Id { get; set; }
        public List<Pin> Pins { get; set; }
        public string Ip { get; set; }
        public List<int> UsedCommands { get; set; }
    }
}
