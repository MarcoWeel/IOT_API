using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT_ArduinoDashboard.Models
{
    public class DigitalPin : Pin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public int pinNumber { get; set; }
        [ForeignKey("ArduinoId")]
        public ArduinoModel ArduinoModel { get; set; }

        public int ArduinoId { get; set; }
    }
}
