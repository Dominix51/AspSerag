using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspSerag.Data;
using AspSerag.Models;

namespace AspSerag.Controllers
{
    public class Pojisteni1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Pojisteni1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pojisteni1
        public async Task<IActionResult> Index()
        {
              return _context.Pojisteni1 != null ? 
                          View(await _context.Pojisteni1.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Pojisteni1'  is null.");
        }

        // GET: Pojisteni1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pojisteni1 == null)
            {
                return NotFound();
            }

            var pojisteni1 = await _context.Pojisteni1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pojisteni1 == null)
            {
                return NotFound();
            }

            return View(pojisteni1);
        }

        // GET: Pojisteni1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pojisteni1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Jméno,Příjmení,Věk,Bydliště,Obec,PSČ,Telefon,Email")] Pojisteni1 pojisteni1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pojisteni1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pojisteni1);
        }

        // GET: Pojisteni1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pojisteni1 == null)
            {
                return NotFound();
            }

            var pojisteni1 = await _context.Pojisteni1.FindAsync(id);
            if (pojisteni1 == null)
            {
                return NotFound();
            }
            return View(pojisteni1);
        }

        // POST: Pojisteni1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Jméno,Příjmení,Věk,Bydliště,Obec,PSČ,Telefon,Email")] Pojisteni1 pojisteni1)
        {
            if (id != pojisteni1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pojisteni1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Pojisteni1Exists(pojisteni1.Id))
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
            return View(pojisteni1);
        }

        // GET: Pojisteni1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pojisteni1 == null)
            {
                return NotFound();
            }

            var pojisteni1 = await _context.Pojisteni1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pojisteni1 == null)
            {
                return NotFound();
            }

            return View(pojisteni1);
        }

        // POST: Pojisteni1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pojisteni1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pojisteni1'  is null.");
            }
            var pojisteni1 = await _context.Pojisteni1.FindAsync(id);
            if (pojisteni1 != null)
            {
                _context.Pojisteni1.Remove(pojisteni1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Pojisteni1Exists(int id)
        {
          return (_context.Pojisteni1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
