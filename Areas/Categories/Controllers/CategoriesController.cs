using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogMVC.Models;

namespace BlogMVC.Areas.Categories.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly BlogDbContext _context;

        public CategoriesController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.categories.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriesModel = await _context.categories
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (categoriesModel == null)
            {
                return NotFound();
            }

            return View(categoriesModel);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryID,CategoryName,Descriptions")] CategoriesModel categoriesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriesModel);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriesModel = await _context.categories.FindAsync(id);
            if (categoriesModel == null)
            {
                return NotFound();
            }
            return View(categoriesModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryID,CategoryName,Descriptions")] CategoriesModel categoriesModel)
        {
            if (id != categoriesModel.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriesModelExists(categoriesModel.CategoryID))
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
            return View(categoriesModel);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriesModel = await _context.categories
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (categoriesModel == null)
            {
                return NotFound();
            }

            return View(categoriesModel);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriesModel = await _context.categories.FindAsync(id);
            if (categoriesModel != null)
            {
                _context.categories.Remove(categoriesModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriesModelExists(int id)
        {
            return _context.categories.Any(e => e.CategoryID == id);
        }
    }
}
