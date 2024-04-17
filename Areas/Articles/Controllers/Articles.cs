using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogMVC.Models;

namespace BlogMVC.Areas.Articles.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly BlogDbContext _context;

        public ArticlesController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            var blogDbContext = _context.articles.Include(a => a.AuthorID).Include(a => a.CategoryID);
            return View(await blogDbContext.ToListAsync());
        }

        // GET: Articles/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articlesModel = await _context.articles
                .Include(a => a.AuthorID)
                .Include(a => a.CategoryID)
                .FirstOrDefaultAsync(m => m.ArticleID == id);
            if (articlesModel == null)
            {
                return NotFound();
            }

            return View(articlesModel);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            ViewData["AuID"] = new SelectList(_context.authors, "AuthorID", "AuthorName");
            ViewData["CateID"] = new SelectList(_context.categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Articles/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleID,Title,Content,Created,CategoryID,AuthorID")] ArticlesModel articlesModel)
        {

            if (ModelState.IsValid)
            {
                _context.Add(articlesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuID"] = new SelectList(_context.authors, "AuthorID", "AuthorName", articlesModel.AuthorID);
            ViewData["CateID"] = new SelectList(_context.categories, "CategoryID", "CategoryName", articlesModel.CategoryID);
            return View(articlesModel);
        }

        // GET: Articles/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articlesModel = await _context.articles.FindAsync(id);
            if (articlesModel == null)
            {
                return NotFound();
            }
            ViewData["AuID"] = new SelectList(_context.authors, "AuthorID", "AuthorName", articlesModel.AuthorID);
            ViewData["CateID"] = new SelectList(_context.categories, "CategoryID", "CategoryName", articlesModel.CategoryID);
            return View(articlesModel);
        }

        // POST: Articles/Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleID,Title,Content,Created,CateID,AuID")] ArticlesModel articlesModel)
        {
            if (id != articlesModel.ArticleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articlesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticlesModelExists(articlesModel.ArticleID))
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
            ViewData["AuID"] = new SelectList(_context.authors, "AuthorID", "AuthorName", articlesModel.AuthorID);
            ViewData["CateID"] = new SelectList(_context.categories, "CategoryID", "CategoryName", articlesModel.CategoryID);
            return View(articlesModel);
        }

        // GET: Articles/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articlesModel = await _context.articles
                .Include(a => a.AuthorID)
                .Include(a => a.CategoryID)
                .FirstOrDefaultAsync(m => m.ArticleID == id);
            if (articlesModel == null)
            {
                return NotFound();
            }

            return View(articlesModel);
        }

        // POST: Articles/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articlesModel = await _context.articles.FindAsync(id);
            if (articlesModel != null)
            {
                _context.articles.Remove(articlesModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticlesModelExists(int id)
        {
            return _context.articles.Any(e => e.ArticleID == id);
        }
    }
}
