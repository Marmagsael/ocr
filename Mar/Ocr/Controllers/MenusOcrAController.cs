using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoginLibraryA.Models.Menus;
using UI.Data;

namespace UI.Controllers
{
    public class MenusOcrAController : Controller
    {
        private readonly UIContext _context;

        public MenusOcrAController(UIContext context)
        {
            _context = context;
        }

        // GET: MenusOcrA
        public async Task<IActionResult> Index()
        {
              return View(await _context.MenusOcrModel.ToListAsync());
        }

        // GET: MenusOcrA/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MenusOcrModel == null)
            {
                return NotFound();
            }

            var menusOcrModel = await _context.MenusOcrModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menusOcrModel == null)
            {
                return NotFound();
            }

            return View(menusOcrModel);
        }

        // GET: MenusOcrA/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MenusOcrA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdParent,Indent,Type,Code,Icon1,Icon2,DispText,IsWithChild,Controller,Action")] MenusOcrModel menusOcrModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menusOcrModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menusOcrModel);
        }

        // GET: MenusOcrA/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MenusOcrModel == null)
            {
                return NotFound();
            }

            var menusOcrModel = await _context.MenusOcrModel.FindAsync(id);
            if (menusOcrModel == null)
            {
                return NotFound();
            }
            return View(menusOcrModel);
        }

        // POST: MenusOcrA/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdParent,Indent,Type,Code,Icon1,Icon2,DispText,IsWithChild,Controller,Action")] MenusOcrModel menusOcrModel)
        {
            if (id != menusOcrModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menusOcrModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenusOcrModelExists(menusOcrModel.Id))
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
            return View(menusOcrModel);
        }

        // GET: MenusOcrA/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MenusOcrModel == null)
            {
                return NotFound();
            }

            var menusOcrModel = await _context.MenusOcrModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menusOcrModel == null)
            {
                return NotFound();
            }

            return View(menusOcrModel);
        }

        // POST: MenusOcrA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MenusOcrModel == null)
            {
                return Problem("Entity set 'UIContext.MenusOcrModel'  is null.");
            }
            var menusOcrModel = await _context.MenusOcrModel.FindAsync(id);
            if (menusOcrModel != null)
            {
                _context.MenusOcrModel.Remove(menusOcrModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenusOcrModelExists(int id)
        {
          return _context.MenusOcrModel.Any(e => e.Id == id);
        }
    }
}
