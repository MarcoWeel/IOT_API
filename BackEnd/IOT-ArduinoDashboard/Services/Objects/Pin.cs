﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT_ArduinoDashboard.Services.Objects
{
    public class Pin
    {
        public string PinName { get; set; }
        public double State { get; set; }

        public void SetState(double state)
        {
            State = state;  
        }
    }
}
