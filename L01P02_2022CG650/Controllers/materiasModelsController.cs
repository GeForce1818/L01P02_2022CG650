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
    public class materiasModelsController : Controller
    {
        private readonly NotasContext _context;

        public materiasModelsController(NotasContext context)
        {
            _context = context;
        }

        // GET: materiasModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.materias.ToListAsync());
        }

        // GET: materiasModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiasModel = await _context.materias
                .FirstOrDefaultAsync(m => m.id == id);
            if (materiasModel == null)
            {
                return NotFound();
            }

            return View(materiasModel);
        }

        // GET: materiasModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: materiasModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,materia,unidades_valorativas,estado")] materiasModel materiasModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materiasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materiasModel);
        }

        // GET: materiasModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiasModel = await _context.materias.FindAsync(id);
            if (materiasModel == null)
            {
                return NotFound();
            }
            return View(materiasModel);
        }

        // POST: materiasModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,materia,unidades_valorativas,estado")] materiasModel materiasModel)
        {
            if (id != materiasModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!materiasModelExists(materiasModel.id))
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
            return View(materiasModel);
        }

        // GET: materiasModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiasModel = await _context.materias
                .FirstOrDefaultAsync(m => m.id == id);
            if (materiasModel == null)
            {
                return NotFound();
            }

            return View(materiasModel);
        }

        // POST: materiasModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materiasModel = await _context.materias.FindAsync(id);
            if (materiasModel != null)
            {
                _context.materias.Remove(materiasModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool materiasModelExists(int id)
        {
            return _context.materias.Any(e => e.id == id);
        }
    }
}
