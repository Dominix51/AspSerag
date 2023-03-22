using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspSerag.Data;
using AspSerag.Models;

namespace AspSerag.Controllers
{
    public class Pojisteni2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Pojisteni2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pojisteni2
        public async Task<IActionResult> Index()
        {
              return _context.Pojisteni2 != null ? 
                          View(await _context.Pojisteni2.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Pojisteni2'  is null.");
        }

        // GET: Pojisteni2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pojisteni2 == null)
            {
                return NotFound();
            }

            var pojisteni2 = await _context.Pojisteni2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pojisteni2 == null)
            {
                return NotFound();
            }

            return View(pojisteni2);
        }

        // GET: Pojisteni2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pojisteni2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Jméno,Příjmení,Popis")] Pojisteni2 pojisteni2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pojisteni2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Ulozit));
            }
            return View(pojisteni2);
        }

        // GET: Pojisteni2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pojisteni2 == null)
            {
                return NotFound();
            }

            var pojisteni2 = await _context.Pojisteni2.FindAsync(id);
            if (pojisteni2 == null)
            {
                return NotFound();
            }
            return View(pojisteni2);
        }

        // POST: Pojisteni2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Jméno,Příjmení,Popis")] Pojisteni2 pojisteni2)
        {
            if (id != pojisteni2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pojisteni2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Pojisteni2Exists(pojisteni2.Id))
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
            return View(pojisteni2);
        }

        // GET: Pojisteni2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pojisteni2 == null)
            {
                return NotFound();
            }

            var pojisteni2 = await _context.Pojisteni2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pojisteni2 == null)
            {
                return NotFound();
            }

            return View(pojisteni2);
        }

        // POST: Pojisteni2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pojisteni2 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pojisteni2'  is null.");
            }
            var pojisteni2 = await _context.Pojisteni2.FindAsync(id);
            if (pojisteni2 != null)
            {
                _context.Pojisteni2.Remove(pojisteni2);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Pojisteni2Exists(int id)
        {
          return (_context.Pojisteni2?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        // Get Search
        public async Task<IActionResult> Vyhledat(string SearchString)
        {
            //if (_context.Pojisteni2 == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Pojisteni2'  is null.");
            //}
            ViewData["Vyhledat"] = SearchString;
            var pojisteni2 = from m in _context.Pojisteni2
                           select m;

            if (!String.IsNullOrEmpty(SearchString))
            {
                pojisteni2 = pojisteni2.Where(s => s.Příjmení!.Contains(SearchString));
            }

            return View(await pojisteni2.ToListAsync());
        }
        public IActionResult Ulozit()
        {
            return View();
        }
    }
}
