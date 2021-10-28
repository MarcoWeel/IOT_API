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
            ArduinoModel arduinoModel = new ArduinoModel{Name = name};
            _context.ArduinoModel.Add(arduinoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArduinoModel", new { id = arduinoModel.ArduinoId }, arduinoModel);
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
