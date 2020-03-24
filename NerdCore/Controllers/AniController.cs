using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NerdCore.Models;

namespace NerdCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AniController : ControllerBase
    {
        private readonly NerdCoreContext _context;

        public AniController(NerdCoreContext context)
        {
            _context = context;
        }

        // GET: api/Ani
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anime>>> GetAnime()
        {
            return await _context.Anime.ToListAsync();
        }

        // GET: api/Ani/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anime>> GetAnime(int id)
        {
            var anime = await _context.Anime.FindAsync(id);

            if (anime == null)
            {
                return NotFound();
            }

            return anime;
        }

        // PUT: api/Ani/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnime(int id, Anime anime)
        {
            if (id != anime.IdAnime)
            {
                return BadRequest();
            }

            _context.Entry(anime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ani
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Anime>> PostAnime(Anime anime)
        {
            _context.Anime.Add(anime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnime", new { id = anime.IdAnime }, anime);
        }

        // DELETE: api/Ani/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Anime>> DeleteAnime(int id)
        {
            var anime = await _context.Anime.FindAsync(id);
            if (anime == null)
            {
                return NotFound();
            }

            _context.Anime.Remove(anime);
            await _context.SaveChangesAsync();

            return anime;
        }

        private bool AnimeExists(int id)
        {
            return _context.Anime.Any(e => e.IdAnime == id);
        }
    }
}
