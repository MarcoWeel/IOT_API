using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT_ArduinoDashboard.Models
{
    public abstract class Pin
    {
        public Mode pinMode { get; set; }
        public enum Mode
        {
            Input,
            Output
        }
    }
}
