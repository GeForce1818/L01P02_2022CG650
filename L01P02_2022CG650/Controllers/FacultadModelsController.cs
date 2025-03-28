using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L01P02_2022CG650.Models;

namespace L01P02_2022CG650.Controllers
{
    public class FacultadModelsController : Controller
    {
        private readonly NotasContext _context;

        public FacultadModelsController(NotasContext context)
        {
            _context = context;
        }

        // GET: FacultadModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.facultad.ToListAsync());
        }

        // GET: FacultadModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultadModel = await _context.facultad
                .FirstOrDefaultAsync(m => m.id == id);
            if (facultadModel == null)
            {
                return NotFound();
            }

            return View(facultadModel);
        }

        // GET: FacultadModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FacultadModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,facultad")] FacultadModel facultadModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facultadModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facultadModel);
        }

        // GET: FacultadModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultadModel = await _context.facultad.FindAsync(id);
            if (facultadModel == null)
            {
                return NotFound();
            }
            return View(facultadModel);
        }

        // POST: FacultadModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,facultad")] FacultadModel facultadModel)
        {
            if (id != facultadModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facultadModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultadModelExists(facultadModel.id))
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
            return View(facultadModel);
        }

        // GET: FacultadModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultadModel = await _context.facultad
                .FirstOrDefaultAsync(m => m.id == id);
            if (facultadModel == null)
            {
                return NotFound();
            }

            return View(facultadModel);
        }

        // POST: FacultadModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facultadModel = await _context.facultad.FindAsync(id);
            if (facultadModel != null)
            {
                _context.facultad.Remove(facultadModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultadModelExists(int id)
        {
            return _context.facultad.Any(e => e.id == id);
        }
    }
}
