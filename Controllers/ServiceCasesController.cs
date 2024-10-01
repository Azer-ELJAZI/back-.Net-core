using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stage1.Models;
using stage1.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stage1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCasesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public ServiceCasesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/ServiceCases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceCase>>> GetServiceCases()
        {
            return await _context.ServiceCases.ToListAsync();
        }

        // GET: api/ServiceCases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceCase>> GetServiceCase(int id)
        {
            var serviceCase = await _context.ServiceCases.FindAsync(id);

            if (serviceCase == null)
            {
                return NotFound();
            }

            return serviceCase;
        }

        // POST: api/ServiceCases
        [HttpPost]
        public async Task<ActionResult<ServiceCase>> PostServiceCase(ServiceCase serviceCase)
        {
            _context.ServiceCases.Add(serviceCase);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServiceCase), new { id = serviceCase.Id }, serviceCase);
        }


        // PUT: api/ServiceCases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceCase(int id, [FromBody] ServiceCase serviceCase)
        {
            if (id != serviceCase.Id)
            {
                return BadRequest(new { message = "ID mismatch" });
            }

            _context.Entry(serviceCase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceCaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                // Log the exception (use your preferred logging framework)
                Console.WriteLine($"Exception: {ex.Message}");
                return BadRequest(new { message = "An error occurred while updating the service case." });
            }

            return NoContent();
        }


        // DELETE: api/ServiceCases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceCase(int id)
        {
            var serviceCase = await _context.ServiceCases.FindAsync(id);
            if (serviceCase == null)
            {
                return NotFound();
            }

            _context.ServiceCases.Remove(serviceCase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceCaseExists(int id)
        {
            return _context.ServiceCases.Any(e => e.Id == id);
        }
    }
}
