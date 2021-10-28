using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT_ArduinoDashboard.Models
{
    public class AnaloguePin: Pin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string pinString { get; private set; }

        [ForeignKey("ArduinoId")] 
        public ArduinoModel ArduinoModel { get; private set; }
        public int ArduinoId { get; private set; }
    }
}
