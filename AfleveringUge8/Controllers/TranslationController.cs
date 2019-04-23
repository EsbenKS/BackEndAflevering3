using AfleveringUge8.Models;
using AfleveringUge8.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AfleveringUge8.Controllers
{
    public class TranslationController : Controller
    {
        private readonly CatalogContext _context;

        public TranslationController(CatalogContext context)
        {
            _context = context;
        }

        // GET: Translation
        [Authorize]
        public async Task<IActionResult> Index()
        {   
            // Sorteret på den danske oversættelse
            return View(await _context.Translations.OrderBy(s => s.Danish).ToListAsync());
        }
        [Authorize]


        public async Task<IActionResult> Index2()
        {
            var Index = await _context.Translations.Where(s => s.English == null).ToListAsync();
            return View(Index);
        }

        // GET: Translation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translation = await _context.Translations
                .FirstOrDefaultAsync(m => m.TranslationID == id);
            if (translation == null)
            {
                return NotFound();
            }

            return View(translation);
        }

        // GET: Translation/Create
        public IActionResult Create()
        {
            return View();
        }
   
        // POST: Translation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TranslationID,Danish,Swedish,Norwegian,English,German,Spanish,Italian,Croatian")] Translation translation)
        {
           

            var googleTranslate = new GoogleTranslate();
         
            if (String.IsNullOrEmpty(translation.Swedish))
            {
                translation.Swedish = googleTranslate.TranslateText(translation.Danish, "sv");
            }
            if (String.IsNullOrEmpty(translation.Norwegian))
            {
                translation.Norwegian = googleTranslate.TranslateText(translation.Danish, "no");
            }
            if (String.IsNullOrEmpty(translation.German))
            {
                translation.German = googleTranslate.TranslateText(translation.Danish, "de");
            }
            if (String.IsNullOrEmpty(translation.Spanish))
            {
                translation.Spanish = googleTranslate.TranslateText(translation.Danish, "es");
            }
            if (String.IsNullOrEmpty(translation.Italian))
            {
                translation.Italian = googleTranslate.TranslateText(translation.Danish, "it");
            }
            if (String.IsNullOrEmpty(translation.Croatian))
            {
                translation.Croatian = googleTranslate.TranslateText(translation.Danish, "hr");
            }
            if (String.IsNullOrEmpty(translation.English))
            {
                translation.English = googleTranslate.TranslateText(translation.Danish, "en");
            }



            if (ModelState.IsValid)
            {
                _context.Add(translation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(translation);
        }



        // GET: Translation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translation = await _context.Translations.FindAsync(id);
            if (translation == null)
            {
                return NotFound();
            }
            return View(translation);
        }

        // POST: Translation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TranslationID,Danish,Swedish,Norwegian,English,German,Spanish,Italian,Croatian")] Translation translation)
        {
            if (id != translation.TranslationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(translation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TranslationExists(translation.TranslationID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(translation);
        }

        // GET: Translation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translation = await _context.Translations
                .FirstOrDefaultAsync(m => m.TranslationID == id);
            if (translation == null)
            {
                return NotFound();
            }

            return View(translation);
        }

        // POST: Translation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var translation = await _context.Translations.FindAsync(id);
            _context.Translations.Remove(translation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TranslationExists(int id)
        {
            return _context.Translations.Any(e => e.TranslationID == id);
        }
    }
}
