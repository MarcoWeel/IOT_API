using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace IOT_ArduinoDashboard
{
    public class ArduinoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArduinoId { get; private set; }

        [Column(TypeName = "varchar(50)")] 
        public string Name { get;  set; }
    }
}
