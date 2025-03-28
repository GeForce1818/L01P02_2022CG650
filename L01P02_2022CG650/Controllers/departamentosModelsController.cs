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
    public class departamentosModelsController : Controller
    {
        private readonly NotasContext _context;

        public departamentosModelsController(NotasContext context)
        {
            _context = context;
        }

        // GET: departamentosModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.departamentos.ToListAsync());
        }

        // GET: departamentosModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentosModel = await _context.departamentos
                .FirstOrDefaultAsync(m => m.id == id);
            if (departamentosModel == null)
            {
                return NotFound();
            }

            return View(departamentosModel);
        }

        // GET: departamentosModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: departamentosModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,departamento")] departamentosModel departamentosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamentosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departamentosModel);
        }

        // GET: departamentosModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentosModel = await _context.departamentos.FindAsync(id);
            if (departamentosModel == null)
            {
                return NotFound();
            }
            return View(departamentosModel);
        }

        // POST: departamentosModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,departamento")] departamentosModel departamentosModel)
        {
            if (id != departamentosModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamentosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!departamentosModelExists(departamentosModel.id))
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
            return View(departamentosModel);
        }

        // GET: departamentosModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentosModel = await _context.departamentos
                .FirstOrDefaultAsync(m => m.id == id);
            if (departamentosModel == null)
            {
                return NotFound();
            }

            return View(departamentosModel);
        }

        // POST: departamentosModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamentosModel = await _context.departamentos.FindAsync(id);
            if (departamentosModel != null)
            {
                _context.departamentos.Remove(departamentosModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool departamentosModelExists(int id)
        {
            return _context.departamentos.Any(e => e.id == id);
        }
    }
}
