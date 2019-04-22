using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AfleveringUge8.Models;

namespace AfleveringUge8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationAPIController : ControllerBase
    {
        private readonly CatalogContext _context;

        public TranslationAPIController(CatalogContext context)
        {
            _context = context;
        }

        // GET: api/TranslationAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Translation>>> GetTranslations()
        {
            return await _context.Translations.ToListAsync();
        }

        // GET: api/TranslationAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Translation>> GetTranslation(int id)
        {
            var translation = await _context.Translations.FindAsync(id);

            if (translation == null)
            {
                return NotFound();
            }

            return translation;
        }

        // PUT: api/TranslationAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTranslation(int id, Translation translation)
        {
            if (id != translation.TranslationID)
            {
                return BadRequest();
            }

            _context.Entry(translation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TranslationExists(id))
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

        // POST: api/TranslationAPI
        [HttpPost]
        public async Task<ActionResult<Translation>> PostTranslation(string DanishWord)
        {
            string _danish = DanishWord;
            var t1 = new Translation();
            t1.Danish = _danish; 
            _context.Translations.Add(t1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTranslation", new { id = t1.TranslationID }, t1);
        }
        // POST: api/TranslationAPI
        [HttpPost]
        public async Task<ActionResult<Translation>> PostTranslation(Translation translation)
        {

            _context.Translations.Add(translation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTranslation", new { id = translation.TranslationID }, translation);
        }


        // DELETE: api/TranslationAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Translation>> DeleteTranslation(int id)
        {
            var translation = await _context.Translations.FindAsync(id);
            if (translation == null)
            {
                return NotFound();
            }

            _context.Translations.Remove(translation);
            await _context.SaveChangesAsync();

            return translation;
        }

        private bool TranslationExists(int id)
        {
            return _context.Translations.Any(e => e.TranslationID == id);
        }
    }
}
