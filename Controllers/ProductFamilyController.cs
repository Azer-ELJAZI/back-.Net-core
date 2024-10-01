using stage1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stage1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stage1.Data;

namespace stage1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFamilyController : ControllerBase
    {
        private readonly CompanyContext _dbContext;

        public ProductFamilyController(CompanyContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductFamily>>> GetProductFamilies()
        {
            var productFamilies = await _dbContext.ProductFamilies.ToListAsync();
            return productFamilies;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductFamily>> GetProductFamily(int id)
        {
            var productFamily = await _dbContext.ProductFamilies.FindAsync(id);

            if (productFamily == null)
            {
                return NotFound();
            }

            return productFamily;
        }

        [HttpPost]
        public async Task<ActionResult<ProductFamily>> PostProductFamily(ProductFamily productFamily)
        {
            _dbContext.ProductFamilies.Add(productFamily);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductFamily), new { id = productFamily.ID }, productFamily);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductFamily(int id, ProductFamily updatedProductFamily)
        {
            if (id != updatedProductFamily.ID)
            {
                return BadRequest("ProductFamily ID mismatch.");
            }

            _dbContext.Entry(updatedProductFamily).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductFamilyExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductFamily(int id)
        {
            var productFamily = await _dbContext.ProductFamilies.FindAsync(id);
            if (productFamily == null)
            {
                return NotFound();
            }

            _dbContext.ProductFamilies.Remove(productFamily);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductFamilyExists(int id)
        {
            return _dbContext.ProductFamilies.Any(e => e.ID == id);
        }
    }
}