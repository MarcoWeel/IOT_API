using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IOT_ArduinoDashboard.Logic.TimeSender;
using IOT_ArduinoDashboard.Logic__;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IOT_ArduinoDashboard.Services
{
    public class StateService__ : IHostedService
    {
        public RequestSender sender = new RequestSender();
        public StateManager manager = new StateManager();
        private readonly ILogger<StateService__> _logger;
        //INITIALISE CLASSES HERE IF NECESSARY
        private TimeSender__ TimeSender = new TimeSender__();
        private blink blink = new blink();

        ////////////////////////////////////

        //ADD TIMERS IF NECESSARY 
        //HAVE TO BE IN SECONDS AND MORE THAN ONE SECOND
        private int BlinkTimer = 2;

        ////////////////////////////


        /////ADD VARIABLES HERE////
        private int blinkstate = 0;



        /////////////////////////// 

        private int Count;
        private Thread thread;
        private bool shouldContinue;
        private int _serviceloopMinutes;

        public StateService__(ILogger<StateService__> logger)
        {
            Count = 0;
            _logger = logger;
            _serviceloopMinutes = 1;
            _logger.LogWarning("StateService Created");
        }


        public async Task Loop()
        {
            shouldContinue = true;
            while (shouldContinue)
            {
                _logger.LogWarning("Loop Works.");
                var sw = Stopwatch.StartNew();
                foreach (var arduino in manager.Arduinos)
                {
                    //ADD METHODS/CLASSES THAT NEED TO BE RUN CONTINUED HERE. //ADD TIMER IF STATEMENT IF NECESSARY
                    if (arduino.UsedCommands.Contains(0))
                    {
                        TimeSender.SendTime(arduino.Ip);
                    }

                    if (Count == BlinkTimer)
                    {
                        if (arduino.UsedCommands.Contains(2))
                        {
                            if (blinkstate == 0)
                            {
                                blinkstate = 1;
                            }
                            else
                            {
                                blinkstate = 0;
                            }
                            if (!blink.SendBlink(arduino.Ip, "2", 1, blinkstate))
                            {
                                manager.Arduinos.Remove(arduino);
                            }
                        }
                        BlinkTimer = BlinkTimer + 2;
                    }
                    //ADD METHODS/CLASSES THAT NEED TO BE RUN ON STATE CHANGE HERE.
                    if (manager.StateChanged)
                    {
                        //For every method give it a unique command id so not every arduino gets every request.
                        if (arduino.UsedCommands.Contains(1))
                        {
                            //PUT METHOD HERE.
                        }
                        _logger.LogWarning("State Changed");
                        manager.StateChanged = false;
                    }
                }

                ///////////////////////////////////////////////
                if (manager.Arduinos.Count != 0)
                {
                    Count++;
                }
                var time = TimeSpan.FromSeconds(_serviceloopMinutes) - sw.Elapsed;
                if (time < TimeSpan.Zero)
                {
                    time = TimeSpan.Zero;
                }
                Thread.Sleep(time);
            }

        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            thread = new Thread(Start);
            thread.Start();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            shouldContinue = false;
        }

        private async void Start()
        {
            await Loop();
        }
    }
}
