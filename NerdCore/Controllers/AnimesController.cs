using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NerdCore.Models;
using NerdCore.Data;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using System.IO;

namespace NerdCore.Views
{
    public class AnimesController : Controller
    {
        private readonly NerdCoreContext _context;

        public AnimesController(NerdCoreContext context)
        {
            _context = context;
        }
        // GET: Animes
        public async Task<IActionResult> Index()
        {
            ViewBag.Success = TempData["Success"];
            ViewBag.Nerd = Convert.ToInt32(HttpContext.Session.GetString("user_ID"));
            var nerdCoreContext = _context.Anime.Include(a => a.IdEstadoSerieNavigation).Include(a => a.IdGeneroAnimeNavigation);
            return View(await nerdCoreContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _context.Anime
                .Include(a => a.IdEstadoSerieNavigation)
                .Include(a => a.IdGeneroAnimeNavigation)
                .FirstOrDefaultAsync(m => m.IdAnime == id);
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // GET: Animes/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("user_ID") != null)
            {
                ViewBag.Nerd = Convert.ToInt32(HttpContext.Session.GetString("user_ID"));
                ViewData["IdEstadoSerie"] = new SelectList(_context.EstadoSerie, "IdEstadoSerie", "Descripcion");
                ViewData["IdGeneroAnime"] = new SelectList(_context.GeneroAnime, "IdGeneroAnime", "Descripcion");
                return View();
            }
            else
            {
                TempData["CONTROLLER"] = "Animes";
                TempData["ACTION"] = "Create";
                return RedirectToAction("Login", "Home");
            }
        }

        // POST: Animes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAnime,Nombre,Sinopsis,Lanzamiento,Temporadas,CapitulosTotales,Imagen,IdGeneroAnime,OtrosGeneros,IdEstadoSerie,Activo")] Anime anime, IFormFile file)
        {
            bool fileOK = false;
            var fileName = Regex.Replace(anime.Nombre.ToLower(), @"[^0-9a-zA-Z_]+", "");
            string path = Path.Combine("wwwroot/img/anime/");
            string fileExtension = Path.GetExtension(file.FileName);
            string[] allowedExtensions = { ".jpeg", ".jpg", ".JPEG", ".JPG" };
            string defName;
            if (fileName != null)
            {
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                defName = fileName + fileExtension;
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }

                using (var localFile = System.IO.File.OpenWrite(path + fileName + fileExtension))
                using (var uploadedFile = file.OpenReadStream())
                {
                    uploadedFile.CopyTo(localFile);
                }

                if (ModelState.IsValid)
                {
                    anime.Imagen = defName;
                    anime.Activo = true;
                    _context.Add(anime);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Se ha creado con éxito un nuevo anime";
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdEstadoSerie"] = new SelectList(_context.EstadoSerie, "IdEstadoSerie", "Descripcion", anime.IdEstadoSerie);
                ViewData["IdGeneroAnime"] = new SelectList(_context.GeneroAnime, "IdGeneroAnime", "Descripcion", anime.IdGeneroAnime);
                return View(anime);
            }
            ViewData["IdEstadoSerie"] = new SelectList(_context.EstadoSerie, "IdEstadoSerie", "Descripcion", anime.IdEstadoSerie);
            ViewData["IdGeneroAnime"] = new SelectList(_context.GeneroAnime, "IdGeneroAnime", "Descripcion", anime.IdGeneroAnime);
            return View(anime);
        }

        // GET: Animes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("user_ID") != null)
            {
                ViewBag.Nerd = Convert.ToInt32(HttpContext.Session.GetString("user_ID"));
                if (id == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                var anime = await _context.Anime.FindAsync(id);
                if (anime == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdEstadoSerie"] = new SelectList(_context.EstadoSerie, "IdEstadoSerie", "Descripcion", anime.IdEstadoSerie);
                ViewData["IdGeneroAnime"] = new SelectList(_context.GeneroAnime, "IdGeneroAnime", "Descripcion", anime.IdGeneroAnime);
                return View(anime);
            }
            else
            {
                TempData["CONTROLLER"] = "Animes";
                TempData["ACTION"] = "Edit";
                return RedirectToAction("Login", "Home");
            }
        }

        // POST: Animes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAnime,Nombre,Sinopsis,Lanzamiento,Temporadas,CapitulosTotales,Imagen,IdGeneroAnime,OtrosGeneros,IdEstadoSerie,Activo")] Anime anime)
        {
            if (id != anime.IdAnime)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimeExists(anime.IdAnime))
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
            ViewData["IdEstadoSerie"] = new SelectList(_context.EstadoSerie, "IdEstadoSerie", "Descripcion", anime.IdEstadoSerie);
            ViewData["IdGeneroAnime"] = new SelectList(_context.GeneroAnime, "IdGeneroAnime", "Descripcion", anime.IdGeneroAnime);
            return View(anime);
        }

        // GET: Animes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("user_ID") != null)
            {
                ViewBag.Nerd = Convert.ToInt32(HttpContext.Session.GetString("user_ID"));
                if (id == null)
                {
                    return NotFound();
                }

                var anime = await _context.Anime
                    .Include(a => a.IdEstadoSerieNavigation)
                    .Include(a => a.IdGeneroAnimeNavigation)
                    .FirstOrDefaultAsync(m => m.IdAnime == id);
                if (anime == null)
                {
                    return NotFound();
                }

                return View(anime);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anime = await _context.Anime.FindAsync(id);
            _context.Anime.Remove(anime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimeExists(int id)
        {
            return _context.Anime.Any(e => e.IdAnime == id);
        }
    }
}
