using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArduinoIOT_Library;
using ArduinoIOT_Library.Objects;
using IOT_ArduinoDashboard.Models;
using Nancy.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IOT_ArduinoDashboard.Controllers
{
    [Route("State")]
    [ApiController]
    public class PinStateController : ControllerBase
    {
        //CHANGE THE STATEMANAGER.
        RequestReceiver receiver = new RequestReceiver(new StateManager());

        //RequestSender sender = new RequestSender();
        // GET: api/<PinStateController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpPost("{pin}/{val}/{id}")]
        public void StateReceiver([FromRoute]string pin, double val, int id)
        {
            receiver.ProcessRequest(pin, val, id);
            //sender.SendPostRequest("http://172.16.222.200/body", "12",1, 1);
        }

        [HttpPost("{id}/{ip}")]
        public void ArduinoSignUp([FromRoute] int id, string ip, [FromBody] List<PinRequestModel> Pins)
        {
            receiver.SignUpArduino(id, ip);
            foreach (var pin in Pins)
            {
                receiver.SignUpPin(new ArduinoIOT_Library.Objects.Pin{PinName = pin.pinNameString, State = 0}, id);
            }
            //sender.SendPostRequest("http://172.16.222.200/body", "12",1, 1);
        }
    }
}
