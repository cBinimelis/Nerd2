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
    public class PeliculasController : Controller
    {
        private readonly NerdCoreContext _context;

        public PeliculasController(NerdCoreContext context)
        {
            _context = context;
        }

        // GET: Peliculas
        public async Task<IActionResult> Index()
        {
            var nerdCoreContext = _context.Peliculas.Include(p => p.IdEstadoPeliculaNavigation).Include(p => p.IdGeneroPeliculaNavigation);
            return View(await nerdCoreContext.ToListAsync());
        }

        // GET: Peliculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculas = await _context.Peliculas
                .Include(p => p.IdEstadoPeliculaNavigation)
                .Include(p => p.IdGeneroPeliculaNavigation)
                .FirstOrDefaultAsync(m => m.IdPelicula == id);
            if (peliculas == null)
            {
                return NotFound();
            }

            return View(peliculas);
        }

        // GET: Peliculas/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoPelicula"] = new SelectList(_context.EstadoPelicula, "IdEstadoPelicula", "Descripcion");
            ViewData["IdGeneroPelicula"] = new SelectList(_context.GeneroPelicula, "IdGeneroPelicula", "Descripcion");
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPelicula,Nombre,Sinopsis,Duracion,Lanzamiento,Imagen,IdGeneroPelicula,OtrosGeneros,IdEstadoPelicula,Activo")] Peliculas peliculas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peliculas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoPelicula"] = new SelectList(_context.EstadoPelicula, "IdEstadoPelicula", "Descripcion", peliculas.IdEstadoPelicula);
            ViewData["IdGeneroPelicula"] = new SelectList(_context.GeneroPelicula, "IdGeneroPelicula", "Descripcion", peliculas.IdGeneroPelicula);
            return View(peliculas);
        }

        // GET: Peliculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculas = await _context.Peliculas.FindAsync(id);
            if (peliculas == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoPelicula"] = new SelectList(_context.EstadoPelicula, "IdEstadoPelicula", "Descripcion", peliculas.IdEstadoPelicula);
            ViewData["IdGeneroPelicula"] = new SelectList(_context.GeneroPelicula, "IdGeneroPelicula", "Descripcion", peliculas.IdGeneroPelicula);
            return View(peliculas);
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPelicula,Nombre,Sinopsis,Duracion,Lanzamiento,Imagen,IdGeneroPelicula,OtrosGeneros,IdEstadoPelicula,Activo")] Peliculas peliculas)
        {
            if (id != peliculas.IdPelicula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peliculas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculasExists(peliculas.IdPelicula))
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
            ViewData["IdEstadoPelicula"] = new SelectList(_context.EstadoPelicula, "IdEstadoPelicula", "Descripcion", peliculas.IdEstadoPelicula);
            ViewData["IdGeneroPelicula"] = new SelectList(_context.GeneroPelicula, "IdGeneroPelicula", "Descripcion", peliculas.IdGeneroPelicula);
            return View(peliculas);
        }

        // GET: Peliculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculas = await _context.Peliculas
                .Include(p => p.IdEstadoPeliculaNavigation)
                .Include(p => p.IdGeneroPeliculaNavigation)
                .FirstOrDefaultAsync(m => m.IdPelicula == id);
            if (peliculas == null)
            {
                return NotFound();
            }

            return View(peliculas);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peliculas = await _context.Peliculas.FindAsync(id);
            _context.Peliculas.Remove(peliculas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeliculasExists(int id)
        {
            return _context.Peliculas.Any(e => e.IdPelicula == id);
        }
    }
}
