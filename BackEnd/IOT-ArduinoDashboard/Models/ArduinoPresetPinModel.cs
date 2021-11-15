using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IOT_ArduinoDashboard.Models
{
    public class ArduinoPresetPinModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public Type PinType { get; set; }

        [ForeignKey("PresetId")]
        public ArduinoPresetModel ArduinoPresetModel { get; set; }

        public int PresetId { get; set; }

        public enum Type
        {
            analogue,
            digital
        }
    }
}
