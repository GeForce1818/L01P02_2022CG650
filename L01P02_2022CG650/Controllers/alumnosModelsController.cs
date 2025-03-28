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
    public class alumnosModelsController : Controller
    {
        private readonly NotasContext _context;

        public alumnosModelsController(NotasContext context)
        {
            _context = context;
        }

        // GET: alumnosModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.alumnos.ToListAsync());
        }

        // GET: alumnosModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnosModel = await _context.alumnos
                .FirstOrDefaultAsync(m => m.id == id);
            if (alumnosModel == null)
            {
                return NotFound();
            }

            return View(alumnosModel);
        }

        // GET: alumnosModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: alumnosModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,codigo,nombre,apellidos,dui,estado")] alumnosModel alumnosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumnosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alumnosModel);
        }

        // GET: alumnosModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnosModel = await _context.alumnos.FindAsync(id);
            if (alumnosModel == null)
            {
                return NotFound();
            }
            return View(alumnosModel);
        }

        // POST: alumnosModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,codigo,nombre,apellidos,dui,estado")] alumnosModel alumnosModel)
        {
            if (id != alumnosModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!alumnosModelExists(alumnosModel.id))
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
            return View(alumnosModel);
        }

        // GET: alumnosModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnosModel = await _context.alumnos
                .FirstOrDefaultAsync(m => m.id == id);
            if (alumnosModel == null)
            {
                return NotFound();
            }

            return View(alumnosModel);
        }

        // POST: alumnosModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumnosModel = await _context.alumnos.FindAsync(id);
            if (alumnosModel != null)
            {
                _context.alumnos.Remove(alumnosModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool alumnosModelExists(int id)
        {
            return _context.alumnos.Any(e => e.id == id);
        }
    }
}
