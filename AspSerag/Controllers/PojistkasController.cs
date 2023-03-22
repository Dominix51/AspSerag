using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspSerag.Data;
using AspSerag.Models;

namespace AspSerag.Controllers
{
    public class PojistkasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PojistkasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pojistkas
        public async Task<IActionResult> Index()
        {
              return _context.Pojistka != null ? 
                          View(await _context.Pojistka.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Pojistka'  is null.");
        }

        // GET: Pojistkas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pojistka == null)
            {
                return NotFound();
            }

            var pojistka = await _context.Pojistka
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pojistka == null)
            {
                return NotFound();
            }

            return View(pojistka);
        }

        // GET: Pojistkas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pojistkas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PojistenyId,Majetek,Osoby,Zivot,Uraz,Predmet,Od,Do")] Pojistka pojistka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pojistka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Ulozit));
            }
            return View(pojistka);
        }

        // GET: Pojistkas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pojistka == null)
            {
                return NotFound();
            }

            var pojistka = await _context.Pojistka.FindAsync(id);
            if (pojistka == null)
            {
                return NotFound();
            }
            return View(pojistka);
        }

        // POST: Pojistkas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PojistenyId,Majetek,Osoby,Zivot,Uraz,Predmet,Od,Do")] Pojistka pojistka)
        {
            if (id != pojistka.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pojistka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PojistkaExists(pojistka.Id))
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
            return View(pojistka);
        }

        // GET: Pojistkas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pojistka == null)
            {
                return NotFound();
            }

            var pojistka = await _context.Pojistka
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pojistka == null)
            {
                return NotFound();
            }

            return View(pojistka);
        }

        // POST: Pojistkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pojistka == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pojistka'  is null.");
            }
            var pojistka = await _context.Pojistka.FindAsync(id);
            if (pojistka != null)
            {
                _context.Pojistka.Remove(pojistka);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PojistkaExists(int id)
        {
          return (_context.Pojistka?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Vyhledat(string SearchString)
        {
            //if (_context.Pojistkas == null)
            // {
            //     return Problem("Entity set 'ApplicationDbContext.Article1'  is null.");
            //}
            ViewData["Vyhledat"] = SearchString;
            var pojistka = from m in _context.Pojistka
                           select m;

            if (!String.IsNullOrEmpty(SearchString))
            {
                pojistka = pojistka.Where(s => s.Predmet!.Contains(SearchString));
            }

            return View(await pojistka.ToListAsync());
        }
        public IActionResult Ulozit()
        {
            return View();
        }
    }
}
