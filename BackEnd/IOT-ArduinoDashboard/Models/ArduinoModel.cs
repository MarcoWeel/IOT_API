using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using IOT_ArduinoDashboard.Models;


namespace IOT_ArduinoDashboard
{
    public class ArduinoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArduinoId { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [ForeignKey("PresetId")]
        public ArduinoPresetModel Preset { get; set; }
        public int PresetId { get; set; }
    }
}
