using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NerdCore.Models;

namespace NerdCore.Views
{
    public class MangasController : Controller
    {
        private readonly NerdCoreContext _context;

        public MangasController(NerdCoreContext context)
        {
            _context = context;
        }

        // GET: Mangas
        public async Task<IActionResult> Index()
        {
            var nerdCoreContext = _context.Manga.Include(m => m.IdEstadoMangaNavigation).Include(m => m.IdGeneroMangaNavigation);
            return View(await nerdCoreContext.ToListAsync());
        }

        // GET: Mangas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manga = await _context.Manga
                .Include(m => m.IdEstadoMangaNavigation)
                .Include(m => m.IdGeneroMangaNavigation)
                .FirstOrDefaultAsync(m => m.IdManga == id);
            if (manga == null)
            {
                return NotFound();
            }

            return View(manga);
        }

        // GET: Mangas/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoManga"] = new SelectList(_context.EstadoManga, "IdEstadoManga", "Descripcion");
            ViewData["IdGeneroManga"] = new SelectList(_context.GeneroMangas, "IdGeneroManga", "Descripcion");
            return View();
        }

        // POST: Mangas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdManga,Nombre,Sinopsis,Lanzamiento,Tomos,Imagen,IdGeneroManga,OtrosGeneros,IdEstadoManga,Activo")] Manga manga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoManga"] = new SelectList(_context.EstadoManga, "IdEstadoManga", "Descripcion", manga.IdEstadoManga);
            ViewData["IdGeneroManga"] = new SelectList(_context.GeneroMangas, "IdGeneroManga", "Descripcion", manga.IdGeneroManga);
            return View(manga);
        }

        // GET: Mangas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manga = await _context.Manga.FindAsync(id);
            if (manga == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoManga"] = new SelectList(_context.EstadoManga, "IdEstadoManga", "Descripcion", manga.IdEstadoManga);
            ViewData["IdGeneroManga"] = new SelectList(_context.GeneroMangas, "IdGeneroManga", "Descripcion", manga.IdGeneroManga);
            return View(manga);
        }

        // POST: Mangas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdManga,Nombre,Sinopsis,Lanzamiento,Tomos,Imagen,IdGeneroManga,OtrosGeneros,IdEstadoManga,Activo")] Manga manga)
        {
            if (id != manga.IdManga)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MangaExists(manga.IdManga))
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
            ViewData["IdEstadoManga"] = new SelectList(_context.EstadoManga, "IdEstadoManga", "Descripcion", manga.IdEstadoManga);
            ViewData["IdGeneroManga"] = new SelectList(_context.GeneroMangas, "IdGeneroManga", "Descripcion", manga.IdGeneroManga);
            return View(manga);
        }

        // GET: Mangas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manga = await _context.Manga
                .Include(m => m.IdEstadoMangaNavigation)
                .Include(m => m.IdGeneroMangaNavigation)
                .FirstOrDefaultAsync(m => m.IdManga == id);
            if (manga == null)
            {
                return NotFound();
            }

            return View(manga);
        }

        // POST: Mangas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manga = await _context.Manga.FindAsync(id);
            _context.Manga.Remove(manga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MangaExists(int id)
        {
            return _context.Manga.Any(e => e.IdManga == id);
        }
    }
}
