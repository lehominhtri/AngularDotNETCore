using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleAPI.Models;

namespace VehicleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakerController : ControllerBase
    {
        private readonly VehicleDBContext _context;

        public VehicleMakerController(VehicleDBContext context)
        {
            _context = context;
        }

        // GET: api/VehicleMaker
        [HttpGet]
        public IEnumerable<VehicleMaker> GetVehicleMakers()
        {
            return _context.VehicleMakers;
        }

        // GET: api/VehicleMaker/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleMaker([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicleMaker = await _context.VehicleMakers.FindAsync(id);

            if (vehicleMaker == null)
            {
                return NotFound();
            }

            return Ok(vehicleMaker);
        }

        // PUT: api/VehicleMaker/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleMaker([FromRoute] string id, [FromBody] VehicleMaker vehicleMaker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleMaker.Maker_ID)
            {
                return BadRequest();
            }

            _context.Entry(vehicleMaker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleMakerExists(id))
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

        // POST: api/VehicleMaker
        [HttpPost]
        public async Task<IActionResult> PostVehicleMaker([FromBody] VehicleMaker vehicleMaker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.VehicleMakers.Add(vehicleMaker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleMaker", new { id = vehicleMaker.Maker_ID }, vehicleMaker);
        }

        // DELETE: api/VehicleMaker/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleMaker([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicleMaker = await _context.VehicleMakers.FindAsync(id);
            if (vehicleMaker == null)
            {
                return NotFound();
            }

            _context.VehicleMakers.Remove(vehicleMaker);
            await _context.SaveChangesAsync();

            return Ok(vehicleMaker);
        }

        private bool VehicleMakerExists(string id)
        {
            return _context.VehicleMakers.Any(e => e.Maker_ID == id);
        }
    }
}