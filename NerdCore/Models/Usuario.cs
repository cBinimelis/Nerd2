using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class Usuario 
    {
        public Usuario()
        {
            AnimeUsuario = new HashSet<AnimeUsuario>();
            JuegosUsuario = new HashSet<JuegosUsuario>();
            LibroUsuario = new HashSet<LibroUsuario>();
            MangaUsuario = new HashSet<MangaUsuario>();
            Mensajes = new HashSet<Mensajes>();
            PeliculaUsuario = new HashSet<PeliculaUsuario>();
            Pendientes = new HashSet<Pendientes>();
            SerieUsuario = new HashSet<SerieUsuario>();
        }

        public int IdUsuario { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public int IdEstadoUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Imagen { get; set; }
        public string Fondo { get; set; }

        public virtual EstadoUsuario IdEstadoUsuarioNavigation { get; set; }
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<AnimeUsuario> AnimeUsuario { get; set; }
        public virtual ICollection<JuegosUsuario> JuegosUsuario { get; set; }
        public virtual ICollection<LibroUsuario> LibroUsuario { get; set; }
        public virtual ICollection<MangaUsuario> MangaUsuario { get; set; }
        public virtual ICollection<Mensajes> Mensajes { get; set; }
        public virtual ICollection<PeliculaUsuario> PeliculaUsuario { get; set; }
        public virtual ICollection<Pendientes> Pendientes { get; set; }
        public virtual ICollection<SerieUsuario> SerieUsuario { get; set; }
    }
}
