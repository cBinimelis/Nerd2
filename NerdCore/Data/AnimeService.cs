using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NerdCore.Models;


namespace NerdCore.Data
{
    public class AnimeService
    {
        private readonly NerdCoreContext _db;


        public AnimeService(NerdCoreContext db)
        {
            _db = db;
        }


        //Listar Todos los Animes
        public List<VAnime> GetAnimes()
        {
            var Lista = _db.VAnime.OrderBy(x=>x.Nombre).ToList();
            return Lista;
        }
        //Listar Usuario actual
        public List<AnimeUsuario> GetUser()
        {
            var ListaU = _db.AnimeUsuario.ToList();
            return ListaU;
        }

        //Insertar Animes
        public string Create(Anime anime)
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
        public string ActualizarAnime(VAnime anime)
        {
            _db.VAnime.Update(anime);
            _db.SaveChanges();
            return "Actualización Exitosa";
        }

        //Eliminar Anime
        public string EliminarAni(VAnime anime)
        {
            _db.Remove(anime);
            _db.SaveChanges();
            return "Eliminacion completa";
        }
    }
}
