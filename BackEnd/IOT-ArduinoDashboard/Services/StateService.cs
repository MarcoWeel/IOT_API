using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace IOT_ArduinoDashboard.Services
{
    public class StateService : IHostedService
    {
        private Thread thread;
        private bool shouldContinue;
        private int _serviceloopMinutes;
        public async Task Loop()
        {

            //await foreach(SensorData sensorData in _fluxConnection.LoadSensorData())
            //{
            //    _OutlierAlgo.SortData(sensorData);
            //}

            

            shouldContinue = true;
            while (shouldContinue)
            {
                // _OutlierAlgo.SetWeatherApiData(await _weatherApiConnection.GetWeatherApi());
                //_logger.LogWarning("Loop werkt.");
                var sw = Stopwatch.StartNew();
                //foreach (SensorData sensor in mocksensors)
                //{
                //    _outlierLeaves.FillSensorList(sensor);
                //}


                //var list = _outlierLeaves.RunAlgo();
                //if (list != null)
                //{
                //    using (var scope = _scopeFactory.CreateScope())
                //    {
                //        var dbContext = scope.ServiceProvider.GetRequiredService<Isaac_AnomalyServiceContext>();
                //        await dbContext.AddRangeAsync(list);
                //        await dbContext.SaveChangesAsync();
                //        await _errorHub.SendError(list);
                //    }
                //}



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
