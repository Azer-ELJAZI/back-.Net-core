using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stage1.Data;
using stage1.Models;

namespace stage1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly CompanyContext _context;

        public ArticleController(CompanyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await _context.Articles
                .Include(a => a.ProductFamily) // Include related ProductFamily if needed
                .FirstOrDefaultAsync(a => a.ID == id);

            if (article == null)
            {
                return NotFound();
            }

            return article;
        }

        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle(Article article)
        {
            try
            {
                // Validate the model
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Check if the provided ProductFamilyID exists
                var existingProductFamily = await _context.ProductFamilies.FindAsync(article.ProductFamilyID);
                if (existingProductFamily == null)
                {
                    return BadRequest(new { message = "Invalid ProductFamilyID." });
                }

                // Assign the ProductFamily navigation property
                article.ProductFamily = existingProductFamily;

                // Add and save the new article
                _context.Articles.Add(article);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetArticle), new { id = article.ID }, article);
            }
            catch (DbUpdateException ex)
            {
                // Log the exception (if logging is set up)
                // Logger.LogError(ex, "An error occurred while creating the article.");

                return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(int id, Article updatedArticle)
        {
            if (id != updatedArticle.ID)
            {
                return BadRequest("Article ID mismatch.");
            }

            var existingArticle = await _context.Articles.FindAsync(id);
            if (existingArticle == null)
            {
                return NotFound();
            }

            // Check if the provided ProductFamilyID exists
            var existingProductFamily = await _context.ProductFamilies.FindAsync(updatedArticle.ProductFamilyID);
            if (existingProductFamily == null)
            {
                return BadRequest("Invalid ProductFamilyID.");
            }

            // Update the article with the new data
            existingArticle.ItemType = updatedArticle.ItemType;
            existingArticle.ItemNumber = updatedArticle.ItemNumber;
            existingArticle.Description = updatedArticle.Description;
            existingArticle.Manufacturer = updatedArticle.Manufacturer;
            existingArticle.Barcode = updatedArticle.Barcode;
            existingArticle.ValidFrom = updatedArticle.ValidFrom;
            existingArticle.ValidTo = updatedArticle.ValidTo;
            existingArticle.Quantity = updatedArticle.Quantity;
            existingArticle.ProductFamily = existingProductFamily; // Update ProductFamily navigation property
            existingArticle.Qtystep = updatedArticle.Qtystep;
            existingArticle.ArticleGroup1 = updatedArticle.ArticleGroup1;
            existingArticle.ArticleGroup2 = updatedArticle.ArticleGroup2;
            existingArticle.ArticleGroup3 = updatedArticle.ArticleGroup3;
            existingArticle.ArticleGroup4 = updatedArticle.ArticleGroup4;
            existingArticle.ArticleGroup5 = updatedArticle.ArticleGroup5;
            existingArticle.Warranty = updatedArticle.Warranty;
            existingArticle.Guarantee = updatedArticle.Guarantee;
            existingArticle.Vat = updatedArticle.Vat;
            existingArticle.Price = updatedArticle.Price;
            existingArticle.PurchasePrice = updatedArticle.PurchasePrice;
            existingArticle.Currency = updatedArticle.Currency;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
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
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ID == id);
        }
    }
}
