using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IOT_ArduinoDashboard;
using IOT_ArduinoDashboard.Data;
using ArduinoIOT_Library;
using IOT_ArduinoDashboard.Models;

namespace IOT_ArduinoDashboard.Controllers
{
    [Route("/Arduino")]
    [ApiController]
    public class ArduinoController : ControllerBase
    {
        private readonly IOT_DataContext _context;
        private RequestSender sender = new RequestSender();

        public ArduinoController(IOT_DataContext context)
        {
            _context = context;
        }

        // GET: api/Arduino
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArduinoModel>>> GetArduinoModel()
        {
            sender.SendPostRequest("http://172.16.222.67/body", "TestName", "TestPassword");
            return await _context.ArduinoModel.ToListAsync();
        }

        // GET: api/Arduino/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArduinoModel>> GetArduinoModel(int id)
        {
            var arduinoModel = await _context.ArduinoModel.FindAsync(id);

            if (arduinoModel == null)
            {
                return NotFound();
            }

            return arduinoModel;
        }

        [HttpGet]
        [Route("/pins")]
        public async Task<ActionResult<IEnumerable<PinRequestModel>>> GetPins(int id)
        {
            var digitalPins = await _context.DigitalPin.ToListAsync();
            var AnaloguePins = await _context.AnaloguePin.ToListAsync();
            List<PinRequestModel> pinRequestModels = new List<PinRequestModel>();
            foreach (var pin in digitalPins)
            {
                PinRequestModel pinModel = new PinRequestModel
                {
                    ArduinoId = pin.ArduinoId,
                    pinMode = pin.pinMode,
                    pinNameString = pin.pinNumber.ToString(),
                    pinType = PinRequestModel.Type.digital,
                    ArduinoModel = await _context.ArduinoModel.FindAsync(pin.ArduinoId)
                };
                pinRequestModels.Add(pinModel);
            }

            foreach (var pin in AnaloguePins)
            {
                PinRequestModel pinModel = new PinRequestModel
                {
                    ArduinoId = pin.ArduinoId,
                    pinMode = pin.pinMode,
                    pinNameString = pin.pinString,
                    pinType = PinRequestModel.Type.analogue,
                    ArduinoModel = await _context.ArduinoModel.FindAsync(pin.ArduinoId)
                };
                pinRequestModels.Add(pinModel);
            }


            if (pinRequestModels == null)
            {
                return NotFound();
            }

            return pinRequestModels;
        }

        // PUT: api/Arduino/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArduinoModel(int id, ArduinoModel arduinoModel)
        {
            if (id != arduinoModel.ArduinoId)
            {
                return BadRequest();
            }

            _context.Entry(arduinoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArduinoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // POST: api/Arduino
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{name}")]
        public async Task<ActionResult<ArduinoModel>> PostArduinoModel([FromRoute] string name)
        {
            ArduinoModel arduinoModel = new ArduinoModel { Name = name };
            _context.ArduinoModel.Add(arduinoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArduinoModel", new { id = arduinoModel.ArduinoId }, arduinoModel);
        }

        [HttpPost]
        [Route("/Pins")]
        public async Task<ActionResult<IEnumerable<PinRequestModel>>> PostPins([FromBody] List<PinRequestModel> model)
        {
             foreach (var pin in model)
            {
                if (pin.pinType == PinRequestModel.Type.digital)
                {
                    DigitalPin digitalPin = new DigitalPin
                    {
                        ArduinoId = pin.ArduinoId,
                        ArduinoModel = await _context.ArduinoModel.FindAsync(pin.ArduinoId),
                        pinNumber = Int32.Parse(pin.pinNameString)
                    };
                    _context.DigitalPin.Add(digitalPin);
                    await _context.SaveChangesAsync();
                }
                else if (pin.pinType == PinRequestModel.Type.analogue)
                {
                    AnaloguePin AnaloguePin = new AnaloguePin
                    {
                        ArduinoId = pin.ArduinoId,
                        ArduinoModel = await _context.ArduinoModel.FindAsync(pin.ArduinoId),
                        pinString = pin.pinNameString,
                    };
                    _context.AnaloguePin.Add(AnaloguePin);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest();
                }
            }
            return Ok();
        }

        // DELETE: api/Arduino/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArduinoModel(int id)
        {
            var arduinoModel = await _context.ArduinoModel.FindAsync(id);
            if (arduinoModel == null)
            {
                return NotFound();
            }

            _context.ArduinoModel.Remove(arduinoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArduinoModelExists(int id)
        {
            return _context.ArduinoModel.Any(e => e.ArduinoId == id);
        }
    }
}
