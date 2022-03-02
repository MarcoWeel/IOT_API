using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using IOT_ArduinoDashboard.Data;
using IOT_ArduinoDashboard.Services;
using IOT_ArduinoDashboard.Services.Objects;
using IOT_ArduinoDashboard.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pin = IOT_ArduinoDashboard.Services.Objects.Pin;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IOT_ArduinoDashboard.Controllers
{
    [Route("/State")]
    [ApiController]
    public class PinStateController : ControllerBase
    {
        private readonly StateService__ _StateService;
        private readonly IOT_DataContext _context;
        private RequestReceiver receiver;

        public PinStateController(StateService__ stateService, IOT_DataContext context)
        {
            _StateService = stateService;
            _context = context;
            receiver = new RequestReceiver(stateService.manager);
        }

        RequestSender sender = new RequestSender();
        // GET: api/<PinStateController>
        [HttpGet("{id}")]
        public IEnumerable<Pin> Get([FromRoute] int id)
        {
            return _StateService.manager.Arduinos.Find(r=> r.Id == id).Pins;
        }


        [HttpPost("{pin}/{val}/{id}")]
        public void StateReceiver([FromRoute]string pin, double val, int id)
        {
            receiver.ProcessRequest(pin, val, id);
            //sender.SendPostRequest("http://172.16.222.200/body", "12",1, 1);
        }

        [HttpPost("{id}/{ip}")]
        public async Task<IActionResult> ArduinoSignUp([FromRoute] int id, string ip,[FromBody] List<int> usedCommands)
        {
            receiver.SignUpArduino(id, ip, usedCommands);
            var Analogue = await _context.AnaloguePin.Where(r => r.ArduinoId == id).ToListAsync();
            var Digital = await _context.DigitalPin.Where(r => r.ArduinoId == id).ToListAsync();
            List<PinRequestModel> Pins = new List<PinRequestModel>();
            foreach (var pin in Analogue)
            {
                Pins.Add(new PinRequestModel
                {
                    ArduinoId = pin.ArduinoId,
                    Id = pin.Id,
                    pinMode = pin.pinMode,
                    pinNameString = pin.pinString,
                    pinType = PinRequestModel.Type.analogue,
                    ArduinoModel = pin.ArduinoModel
                });
            }

            foreach (var pin in Digital)
            {
                Pins.Add(new PinRequestModel
                {
                    ArduinoId = pin.ArduinoId,
                    Id = pin.Id,
                    pinMode = pin.pinMode,
                    pinNameString = pin.pinNumber.ToString(),
                    pinType = PinRequestModel.Type.analogue,
                    ArduinoModel = pin.ArduinoModel
                });
            }
            foreach (var pin in Pins)
            {
                receiver.SignUpPin(new IOT_ArduinoDashboard.Services.Objects.Pin { PinName = pin.pinNameString, State = 0 }, id);
            }
            //sender.SendPostRequest("http://172.16.222.200/body", "12",1, 1);
            return NoContent();
        }
    }
}
