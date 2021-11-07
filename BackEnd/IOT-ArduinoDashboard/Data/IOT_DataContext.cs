using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IOT_ArduinoDashboard;
using IOT_ArduinoDashboard.Models;

namespace IOT_ArduinoDashboard.Data
{
    public class IOT_DataContext : DbContext
    {
        public IOT_DataContext (DbContextOptions<IOT_DataContext> options)
            : base(options)
        {
        }

        public DbSet<ArduinoModel> ArduinoModel { get; set; }
        public DbSet<ArduinoPresetModel> ArduinoPresetModel { get; set; }
        public DbSet<AnaloguePin> AnaloguePin { get; set; }
        public DbSet<DigitalPin> DigitalPin { get; set; }
    }
}
