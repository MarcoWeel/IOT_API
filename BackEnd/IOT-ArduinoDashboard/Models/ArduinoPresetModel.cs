using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IOT_ArduinoDashboard.Models
{
    public class ArduinoPresetModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PresetId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public int DigitalPinCount { get; set; }
        public int AnaloguePinCount { get; set; }
    }
}
