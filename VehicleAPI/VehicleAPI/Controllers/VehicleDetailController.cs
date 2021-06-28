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
    public class VehicleDetailController : ControllerBase
    {
        private readonly VehicleDBContext _context;

        public VehicleDetailController(VehicleDBContext context)
        {
            _context = context;
        }

        // GET: api/VehicleDetail
        [HttpGet]
        public IEnumerable<VehicleDetail> GetVehicleDetails()
        {
            return _context.VehicleDetails;
        }

        // GET: api/VehicleDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleDetail([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicleDetail = await _context.VehicleDetails.FindAsync(id);

            if (vehicleDetail == null)
            {
                return NotFound();
            }

            return Ok(vehicleDetail);
        }

        // PUT: api/VehicleDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleDetail([FromRoute] string id, [FromBody] VehicleDetail vehicleDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleDetail.VIN)
            {
                return BadRequest();
            }

            _context.Entry(vehicleDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleDetailExists(id))
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

        // POST: api/VehicleDetail
        [HttpPost]
        public async Task<IActionResult> PostVehicleDetail([FromBody] VehicleDetail vehicleDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.VehicleDetails.Add(vehicleDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleDetail", new { id = vehicleDetail.VIN }, vehicleDetail);
        }

        // DELETE: api/VehicleDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleDetail([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicleDetail = await _context.VehicleDetails.FindAsync(id);
            if (vehicleDetail == null)
            {
                return NotFound();
            }

            _context.VehicleDetails.Remove(vehicleDetail);
            await _context.SaveChangesAsync();

            return Ok(vehicleDetail);
        }

        [HttpGet("testapi")]
        public async Task<IActionResult> GetTestApi()
        {
            //return new string[] { "value1", "value2" };
            string StoredProc = "exec TestSPApi '1231'";

            //return await _context.output.ToListAsync();  
            var vehicleDetail =  await _context.VehicleDetails.FromSql(StoredProc).ToListAsync();
            if (vehicleDetail == null)
            {
                return NotFound();
            }

            return Ok(vehicleDetail);
        }

        private bool VehicleDetailExists(string id)
        {
            return _context.VehicleDetails.Any(e => e.VIN == id);
        }
    }
}