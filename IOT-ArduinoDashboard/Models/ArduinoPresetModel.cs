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
        public int Id { get; private set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; private set; }

        public int DigitalPinCount { get; private set; }
        public int AnaloguePinCount { get; private set; }
    }
}
