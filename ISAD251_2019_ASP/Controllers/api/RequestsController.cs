using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISAD251_2019_ASP.Models;

namespace ISAD251_2019_ASP.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly ISAD251_SAtkinsonContext _context;

        public RequestsController(ISAD251_SAtkinsonContext context)
        {
            _context = context;
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShRequest>>> GetShRequest()
        {
            return await _context.ShRequest.ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShRequest>> GetShRequest(int id)
        {
            var shRequest = await _context.ShRequest.FindAsync(id);

            if (shRequest == null)
            {
                return NotFound();
            }

            return shRequest;
        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShRequest(int id, ShRequest shRequest)
        {
            if (id != shRequest.RequestId)
            {
                return BadRequest();
            }

            _context.Entry(shRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShRequestExists(id))
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

        // POST: api/Requests
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ShRequest>> PostShRequest(ShRequest shRequest)
        {
            _context.ShRequest.Add(shRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShRequest", new { id = shRequest.RequestId }, shRequest);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShRequest>> DeleteShRequest(int id)
        {
            var shRequest = await _context.ShRequest.FindAsync(id);
            if (shRequest == null)
            {
                return NotFound();
            }

            _context.ShRequest.Remove(shRequest);
            await _context.SaveChangesAsync();

            return shRequest;
        }

        private bool ShRequestExists(int id)
        {
            return _context.ShRequest.Any(e => e.RequestId == id);
        }
    }
}
