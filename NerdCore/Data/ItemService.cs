using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NerdCore.Models;


namespace NerdCore.Data
{
    public class ItemService
    {
        private readonly NerdCoreContext _db;


        public ItemService(NerdCoreContext db)
        {
            _db = db;
        }


        //-----------------------ANIMES-----------------------------


        //Listar Todos los Animes
        public List<VAnime> GetAnimes()
        {
            var Lista = _db.VAnime.OrderBy(x => x.Nombre).ToList();
            return Lista;
        }

        //Insertar Animes
        public string CreateAnime(Anime anime)
        {
            _db.Anime.Add(anime);
            _db.SaveChanges();
            return "Guardado Exitoso";
        }

        //Identificar Anime Segun ID
        public VAnime GetAnime(int ID)
        {
            VAnime anime = _db.VAnime.FirstOrDefault(s => s.IdAnime == ID);
            return anime;
        }

        //Actualizar Anime
        public string UpdateAnime(VAnime anime)
        {
            _db.VAnime.Update(anime);
            _db.SaveChanges();
            return "Actualización Exitosa";
        }

        //Eliminar Anime
        public string DeleteAnime(VAnime anime)
        {
            _db.Remove(anime);
            _db.SaveChanges();
            return "Eliminacion completa";
        }

        //Listar Usuario actual
        public List<AnimeUsuario> GetAniUser()
        {
            var ListaU = _db.AnimeUsuario.ToList();
            return ListaU;
        }

        //CrearAnimeUsuario
        public bool CreateAU(AnimeUsuario animeU)
        {
            _db.AnimeUsuario.Add(animeU);
            _db.SaveChanges();
            return true;
        }


        //-----------------------JUEGOS-----------------------------
        public List<VJuegos> GetJuegos()
        {
            var Lista = _db.VJuegos.OrderBy(x => x.Nombre).ToList();
            return Lista;
        }

        //-----------------------MANGAS-----------------------------
        public List<VManga> GetMangas()
        {
            var Lista = _db.VManga.OrderBy(x => x.Nombre).ToList();
            return Lista;
        }

        //Insertar Animes
        public string CreateManga(Anime anime)
        {
            _db.Anime.Add(anime);
            _db.SaveChanges();
            return "Guardado Exitoso";
        }

        //Identificar Anime Segun ID
        public VAnime GetManga(int ID)
        {
            VAnime anime = _db.VAnime.FirstOrDefault(s => s.IdAnime == ID);
            return anime;
        }

        //Actualizar Anime
        public string UpdateManga(VAnime anime)
        {
            _db.VAnime.Update(anime);
            _db.SaveChanges();
            return "Actualización Exitosa";
        }

        //Eliminar Anime
        public string DeleteManga(VAnime anime)
        {
            _db.Remove(anime);
            _db.SaveChanges();
            return "Eliminacion completa";
        }
        //Listar Usuario actual
        public List<MangaUsuario> GetManUser()
        {
            var ListaU = _db.MangaUsuario.ToList();
            return ListaU;
        }

        //CrearAnimeUsuario
        public bool CreateMU(MangaUsuario mangaU)
        {
            _db.MangaUsuario.Add(mangaU);
            _db.SaveChanges();
            return true;
        }



        //-----------------------SERIES -----------------------------
        public List<VSeries> GetSeries()
        {
            var Lista = _db.VSeries.OrderBy(x => x.Nombre).ToList();
            return Lista;
        }

        public List<VPelicula> GetPeliculas()
        {
            var Lista = _db.VPelicula.OrderBy(x => x.Nombre).ToList();
            return Lista;
        }

        public List<VLibros> GetLibros()
        {
            var Lista = _db.VLibros.OrderBy(x => x.Nombre).ToList();
            return Lista;
        }
    }
}
