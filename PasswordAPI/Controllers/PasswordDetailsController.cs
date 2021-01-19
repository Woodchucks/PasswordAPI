using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasswordAPI.Models;

namespace PasswordAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordDetailsController : ControllerBase
    {
        private readonly PasswordDetailsContext _context;

        public PasswordDetailsController(PasswordDetailsContext context)
        {
            _context = context;
        }

        // GET: api/PasswordDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PasswordDetails>>> GetPasswordDetailss()
        {
            return await _context.PasswordsDetails.ToListAsync();
        }

        // GET: api/PasswordDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PasswordDetails>> GetPasswordDetails(int id)
        {
            var PasswordDetails = await _context.PasswordsDetails.FindAsync(id);

            if (PasswordDetails == null) 
            {
                return NotFound();
            }

            return PasswordDetails;
        }

        // PUT: api/PasswordDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPasswordDetails(int id, PasswordDetails PasswordDetails)
        {
            if (id != PasswordDetails.PasswordDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(PasswordDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasswordDetailsExists(id))
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

        // POST: api/PasswordDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PasswordDetails>> PostPasswordDetails(PasswordDetails PasswordDetails)
        {
            _context.PasswordsDetails.Add(PasswordDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPasswordDetails", new { id = PasswordDetails.PasswordDetailsId }, PasswordDetails);
        }

        // DELETE: api/PasswordDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePasswordDetails(int id)
        {
            var PasswordDetails = await _context.PasswordsDetails.FindAsync(id);
            if (PasswordDetails == null)
            {
                return NotFound();
            }

            _context.PasswordsDetails.Remove(PasswordDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PasswordDetailsExists(int id)
        {
            return _context.PasswordsDetails.Any(e => e.PasswordDetailsId == id);
        }
    }
}