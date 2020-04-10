using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NerdCore.Models
{
    public partial class NerdCoreContext : DbContext
    {
        public NerdCoreContext()
        {
        }

        public NerdCoreContext(DbContextOptions<NerdCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anime> Anime { get; set; }
        public virtual DbSet<AnimeUsuario> AnimeUsuario { get; set; }
        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<AvanceAnime> AvanceAnime { get; set; }
        public virtual DbSet<AvanceJuego> AvanceJuego { get; set; }
        public virtual DbSet<AvanceLibro> AvanceLibro { get; set; }
        public virtual DbSet<AvanceManga> AvanceManga { get; set; }
        public virtual DbSet<AvancePelicula> AvancePelicula { get; set; }
        public virtual DbSet<AvanceSerie> AvanceSerie { get; set; }
        public virtual DbSet<Desarrollador> Desarrollador { get; set; }
        public virtual DbSet<EstadoJuegos> EstadoJuegos { get; set; }
        public virtual DbSet<EstadoLibro> EstadoLibro { get; set; }
        public virtual DbSet<EstadoManga> EstadoManga { get; set; }
        public virtual DbSet<EstadoMensaje> EstadoMensaje { get; set; }
        public virtual DbSet<EstadoPelicula> EstadoPelicula { get; set; }
        public virtual DbSet<EstadoSerie> EstadoSerie { get; set; }
        public virtual DbSet<EstadoUsuario> EstadoUsuario { get; set; }
        public virtual DbSet<GeneroAnime> GeneroAnime { get; set; }
        public virtual DbSet<GeneroJuegos> GeneroJuegos { get; set; }
        public virtual DbSet<GeneroLibro> GeneroLibro { get; set; }
        public virtual DbSet<GeneroMangas> GeneroMangas { get; set; }
        public virtual DbSet<GeneroPelicula> GeneroPelicula { get; set; }
        public virtual DbSet<GeneroSerie> GeneroSerie { get; set; }
        public virtual DbSet<Juegos> Juegos { get; set; }
        public virtual DbSet<JuegosUsuario> JuegosUsuario { get; set; }
        public virtual DbSet<LibroUsuario> LibroUsuario { get; set; }
        public virtual DbSet<Libros> Libros { get; set; }
        public virtual DbSet<Manga> Manga { get; set; }
        public virtual DbSet<MangaUsuario> MangaUsuario { get; set; }
        public virtual DbSet<Mensajes> Mensajes { get; set; }
        public virtual DbSet<PeliculaUsuario> PeliculaUsuario { get; set; }
        public virtual DbSet<Peliculas> Peliculas { get; set; }
        public virtual DbSet<Pendientes> Pendientes { get; set; }
        public virtual DbSet<SerieUsuario> SerieUsuario { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<TipoPendiente> TipoPendiente { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<VAnime> VAnime { get; set; }
        public virtual DbSet<VJuegos> VJuegos { get; set; }
        public virtual DbSet<VLibros> VLibros { get; set; }
        public virtual DbSet<VManga> VManga { get; set; }
        public virtual DbSet<VPelicula> VPelicula { get; set; }
        public virtual DbSet<VPendientes> VPendientes { get; set; }
        public virtual DbSet<VSeries> VSeries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=bd_biblioteca;Persist Security Info=True;User ID=sa;Password=crislyn;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>(entity =>
            {
                entity.HasKey(e => e.IdAnime);

                entity.Property(e => e.IdAnime).HasColumnName("id_Anime");

                entity.Property(e => e.IdEstadoSerie).HasColumnName("id_EstadoSerie");

                entity.Property(e => e.IdGeneroAnime).HasColumnName("id_GeneroAnime");

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.Lanzamiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.OtrosGeneros)
                    .IsRequired()
                    .HasColumnName("Otros_Generos")
                    .HasColumnType("text");

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.IdEstadoSerieNavigation)
                    .WithMany(p => p.Anime)
                    .HasForeignKey(d => d.IdEstadoSerie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Anime_Estado");

                entity.HasOne(d => d.IdGeneroAnimeNavigation)
                    .WithMany(p => p.Anime)
                    .HasForeignKey(d => d.IdGeneroAnime)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Anime_Genero_Anime");
            });

            modelBuilder.Entity<AnimeUsuario>(entity =>
            {
                entity.HasKey(e => e.IdAnimeUsuario);

                entity.ToTable("Anime_Usuario");

                entity.Property(e => e.IdAnimeUsuario).HasColumnName("id_AnimeUsuario");

                entity.Property(e => e.IdAnime).HasColumnName("id_Anime");

                entity.Property(e => e.IdAvanceAnime).HasColumnName("id_AvanceAnime");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.Nota).IsUnicode(false);

                entity.HasOne(d => d.IdAnimeNavigation)
                    .WithMany(p => p.AnimeUsuario)
                    .HasForeignKey(d => d.IdAnime)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Anime_Usuario_Anime");

                entity.HasOne(d => d.IdAvanceAnimeNavigation)
                    .WithMany(p => p.AnimeUsuario)
                    .HasForeignKey(d => d.IdAvanceAnime)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Anime_Usuario_Estado_Anime_Usuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AnimeUsuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Anime_Usuario_Usuario");
            });

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PK_Sagas");

                entity.Property(e => e.IdAutor).HasColumnName("id_Autor");

                entity.Property(e => e.Detalles)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AvanceAnime>(entity =>
            {
                entity.HasKey(e => e.IdAvanceAnime)
                    .HasName("PK_Estado_Anime_Usuario");

                entity.ToTable("Avance_Anime");

                entity.Property(e => e.IdAvanceAnime).HasColumnName("id_AvanceAnime");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AvanceJuego>(entity =>
            {
                entity.HasKey(e => e.IdAvanceJuego);

                entity.ToTable("Avance_Juego");

                entity.Property(e => e.IdAvanceJuego).HasColumnName("id_AvanceJuego");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AvanceLibro>(entity =>
            {
                entity.HasKey(e => e.IdAvanceLibro);

                entity.ToTable("Avance_Libro");

                entity.Property(e => e.IdAvanceLibro).HasColumnName("id_AvanceLibro");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AvanceManga>(entity =>
            {
                entity.HasKey(e => e.IdAvanceManga);

                entity.ToTable("Avance_Manga");

                entity.Property(e => e.IdAvanceManga).HasColumnName("id_AvanceManga");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AvancePelicula>(entity =>
            {
                entity.HasKey(e => e.IdAvancePelicula);

                entity.ToTable("Avance_Pelicula");

                entity.Property(e => e.IdAvancePelicula).HasColumnName("id_AvancePelicula");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AvanceSerie>(entity =>
            {
                entity.HasKey(e => e.IdAvanceSerie);

                entity.ToTable("Avance_Serie");

                entity.Property(e => e.IdAvanceSerie).HasColumnName("id_AvanceSerie");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Desarrollador>(entity =>
            {
                entity.HasKey(e => e.IdDesarrollador);

                entity.Property(e => e.IdDesarrollador).HasColumnName("id_Desarrollador");

                entity.Property(e => e.Detalles).HasColumnType("text");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoJuegos>(entity =>
            {
                entity.HasKey(e => e.IdEstadoJuegos);

                entity.ToTable("Estado_Juegos");

                entity.Property(e => e.IdEstadoJuegos).HasColumnName("id_EstadoJuegos");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoLibro>(entity =>
            {
                entity.HasKey(e => e.IdEstadoLibro);

                entity.ToTable("Estado_Libro");

                entity.Property(e => e.IdEstadoLibro).HasColumnName("id_EstadoLibro");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoManga>(entity =>
            {
                entity.HasKey(e => e.IdEstadoManga);

                entity.ToTable("Estado_Manga");

                entity.Property(e => e.IdEstadoManga).HasColumnName("id_EstadoManga");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoMensaje>(entity =>
            {
                entity.HasKey(e => e.IdEstadoMensaje);

                entity.ToTable("Estado_Mensaje");

                entity.Property(e => e.IdEstadoMensaje).HasColumnName("id_EstadoMensaje");

                entity.Property(e => e.EstadoMensaje1)
                    .IsRequired()
                    .HasColumnName("EstadoMensaje")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoPelicula>(entity =>
            {
                entity.HasKey(e => e.IdEstadoPelicula);

                entity.ToTable("Estado_Pelicula");

                entity.Property(e => e.IdEstadoPelicula).HasColumnName("id_EstadoPelicula");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoSerie>(entity =>
            {
                entity.HasKey(e => e.IdEstadoSerie)
                    .HasName("PK_Estado");

                entity.ToTable("Estado_Serie");

                entity.Property(e => e.IdEstadoSerie)
                    .HasColumnName("id_EstadoSerie")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdEstadoUsuario);

                entity.ToTable("Estado_Usuario");

                entity.Property(e => e.IdEstadoUsuario).HasColumnName("id_EstadoUsuario");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeneroAnime>(entity =>
            {
                entity.HasKey(e => e.IdGeneroAnime);

                entity.ToTable("Genero_Anime");

                entity.Property(e => e.IdGeneroAnime).HasColumnName("id_GeneroAnime");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeneroJuegos>(entity =>
            {
                entity.HasKey(e => e.IdGeneroJuego)
                    .HasName("PK_Juegos_Genero");

                entity.ToTable("Genero_Juegos");

                entity.Property(e => e.IdGeneroJuego).HasColumnName("id_GeneroJuego");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeneroLibro>(entity =>
            {
                entity.HasKey(e => e.IdGeneroLibro)
                    .HasName("PK_Genero");

                entity.ToTable("Genero_Libro");

                entity.Property(e => e.IdGeneroLibro).HasColumnName("id_GeneroLibro");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeneroMangas>(entity =>
            {
                entity.HasKey(e => e.IdGeneroManga);

                entity.ToTable("Genero_Mangas");

                entity.Property(e => e.IdGeneroManga).HasColumnName("id_GeneroManga");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeneroPelicula>(entity =>
            {
                entity.HasKey(e => e.IdGeneroPelicula);

                entity.ToTable("Genero_Pelicula");

                entity.Property(e => e.IdGeneroPelicula).HasColumnName("id_GeneroPelicula");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeneroSerie>(entity =>
            {
                entity.HasKey(e => e.IdGeneroSerie);

                entity.ToTable("Genero_Serie");

                entity.Property(e => e.IdGeneroSerie).HasColumnName("id_GeneroSerie");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Juegos>(entity =>
            {
                entity.HasKey(e => e.IdJuego);

                entity.Property(e => e.IdJuego).HasColumnName("id_Juego");

                entity.Property(e => e.IdDesarrollador).HasColumnName("id_Desarrollador");

                entity.Property(e => e.IdEstadoJuego).HasColumnName("id_EstadoJuego");

                entity.Property(e => e.IdGeneroJuego).HasColumnName("id_GeneroJuego");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Lanzamiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtrosGeneros)
                    .IsRequired()
                    .HasColumnName("Otros_Generos")
                    .IsUnicode(false);

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.IdDesarrolladorNavigation)
                    .WithMany(p => p.Juegos)
                    .HasForeignKey(d => d.IdDesarrollador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Juegos_Desarrollador");

                entity.HasOne(d => d.IdEstadoJuegoNavigation)
                    .WithMany(p => p.Juegos)
                    .HasForeignKey(d => d.IdEstadoJuego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Juegos_Estado_Juegos");

                entity.HasOne(d => d.IdGeneroJuegoNavigation)
                    .WithMany(p => p.Juegos)
                    .HasForeignKey(d => d.IdGeneroJuego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Juegos_Juegos_Genero");
            });

            modelBuilder.Entity<JuegosUsuario>(entity =>
            {
                entity.HasKey(e => e.IdJuegoUsuario);

                entity.ToTable("Juegos_Usuario");

                entity.Property(e => e.IdJuegoUsuario).HasColumnName("id_JuegoUsuario");

                entity.Property(e => e.IdAvanceJuego).HasColumnName("id_AvanceJuego");

                entity.Property(e => e.IdJuego).HasColumnName("id_Juego");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAvanceJuegoNavigation)
                    .WithMany(p => p.JuegosUsuario)
                    .HasForeignKey(d => d.IdAvanceJuego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Juegos_Usuario_Avance_Juego");

                entity.HasOne(d => d.IdJuegoNavigation)
                    .WithMany(p => p.JuegosUsuario)
                    .HasForeignKey(d => d.IdJuego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Juegos_Usuario_Juegos");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.JuegosUsuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Juegos_Usuario_Usuario");
            });

            modelBuilder.Entity<LibroUsuario>(entity =>
            {
                entity.HasKey(e => e.IdLibroUsuario);

                entity.ToTable("Libro_Usuario");

                entity.Property(e => e.IdLibroUsuario).HasColumnName("id_LibroUsuario");

                entity.Property(e => e.IdAvanceLibro).HasColumnName("id_AvanceLibro");

                entity.Property(e => e.IdLibro).HasColumnName("id_Libro");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAvanceLibroNavigation)
                    .WithMany(p => p.LibroUsuario)
                    .HasForeignKey(d => d.IdAvanceLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Libro_Usuario_Avance_Libro");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.LibroUsuario)
                    .HasForeignKey(d => d.IdLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Libro_Usuario_Libros");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.LibroUsuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Libro_Usuario_Usuario");
            });

            modelBuilder.Entity<Libros>(entity =>
            {
                entity.HasKey(e => e.IdLibro);

                entity.Property(e => e.IdLibro).HasColumnName("id_Libro");

                entity.Property(e => e.IdAutor).HasColumnName("id_Autor");

                entity.Property(e => e.IdEstadoLibro).HasColumnName("id_EstadoLibro");

                entity.Property(e => e.IdGeneroLibro).HasColumnName("id_GeneroLibro");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Lanzamiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OtrosGeneros)
                    .HasColumnName("Otros_Generos")
                    .IsUnicode(false);

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Libros_Autor");

                entity.HasOne(d => d.IdEstadoLibroNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdEstadoLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Libros_Estado_Libro");

                entity.HasOne(d => d.IdEstadoLibro1)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdEstadoLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Libros_Genero");
            });

            modelBuilder.Entity<Manga>(entity =>
            {
                entity.HasKey(e => e.IdManga);

                entity.Property(e => e.IdManga).HasColumnName("id_Manga");

                entity.Property(e => e.IdEstadoManga).HasColumnName("id_EstadoManga");

                entity.Property(e => e.IdGeneroManga).HasColumnName("id_GeneroManga");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Lanzamiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OtrosGeneros)
                    .IsRequired()
                    .HasColumnName("Otros_Generos")
                    .HasColumnType("text");

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.IdEstadoMangaNavigation)
                    .WithMany(p => p.Manga)
                    .HasForeignKey(d => d.IdEstadoManga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manga_Estado_Manga");

                entity.HasOne(d => d.IdGeneroMangaNavigation)
                    .WithMany(p => p.Manga)
                    .HasForeignKey(d => d.IdGeneroManga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manga_Genero_Mangas");
            });

            modelBuilder.Entity<MangaUsuario>(entity =>
            {
                entity.HasKey(e => e.IdMangaUsuario);

                entity.ToTable("Manga_Usuario");

                entity.Property(e => e.IdMangaUsuario).HasColumnName("id_MangaUsuario");

                entity.Property(e => e.IdAvanceManga).HasColumnName("id_AvanceManga");

                entity.Property(e => e.IdManga).HasColumnName("id_Manga");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAvanceMangaNavigation)
                    .WithMany(p => p.MangaUsuario)
                    .HasForeignKey(d => d.IdAvanceManga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manga_Usuario_Avance_Manga");

                entity.HasOne(d => d.IdMangaNavigation)
                    .WithMany(p => p.MangaUsuario)
                    .HasForeignKey(d => d.IdManga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manga_Usuario_Manga");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.MangaUsuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manga_Usuario_Usuario");
            });

            modelBuilder.Entity<Mensajes>(entity =>
            {
                entity.HasKey(e => e.IdMensaje)
                    .HasName("PK_Notas");

                entity.Property(e => e.IdMensaje).HasColumnName("id_Mensaje");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoMensaje).HasColumnName("id_EstadoMensaje");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.HasOne(d => d.IdEstadoMensajeNavigation)
                    .WithMany(p => p.Mensajes)
                    .HasForeignKey(d => d.IdEstadoMensaje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mensajes_Estado_Mensaje");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Mensajes)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notas_Usuario");
            });

            modelBuilder.Entity<PeliculaUsuario>(entity =>
            {
                entity.HasKey(e => e.IdPeliculaUsuario);

                entity.ToTable("Pelicula_Usuario");

                entity.Property(e => e.IdPeliculaUsuario).HasColumnName("id_PeliculaUsuario");

                entity.Property(e => e.IdAvancePelicula).HasColumnName("id_AvancePelicula");

                entity.Property(e => e.IdPelicula).HasColumnName("id_Pelicula");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.IdAvancePeliculaNavigation)
                    .WithMany(p => p.PeliculaUsuario)
                    .HasForeignKey(d => d.IdAvancePelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pelicula_Usuario_Avance_Pelicula");

                entity.HasOne(d => d.IdPeliculaNavigation)
                    .WithMany(p => p.PeliculaUsuario)
                    .HasForeignKey(d => d.IdPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pelicula_Usuario_Peliculas");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.PeliculaUsuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pelicula_Usuario_Usuario");
            });

            modelBuilder.Entity<Peliculas>(entity =>
            {
                entity.HasKey(e => e.IdPelicula);

                entity.Property(e => e.IdPelicula).HasColumnName("id_Pelicula");

                entity.Property(e => e.Duracion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdEstadoPelicula).HasColumnName("id_EstadoPelicula");

                entity.Property(e => e.IdGeneroPelicula).HasColumnName("id_GeneroPelicula");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lanzamiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.OtrosGeneros)
                    .IsRequired()
                    .HasColumnName("Otros_Generos")
                    .IsUnicode(false);

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.IdEstadoPeliculaNavigation)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.IdEstadoPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Peliculas_Estado_Pelicula1");

                entity.HasOne(d => d.IdGeneroPeliculaNavigation)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.IdGeneroPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Peliculas_Genero_Pelicula");
            });

            modelBuilder.Entity<Pendientes>(entity =>
            {
                entity.HasKey(e => e.IdPendiente);

                entity.Property(e => e.IdPendiente).HasColumnName("id_Pendiente");

                entity.Property(e => e.IdTipoPendiente).HasColumnName("id_TipoPendiente");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoPendienteNavigation)
                    .WithMany(p => p.Pendientes)
                    .HasForeignKey(d => d.IdTipoPendiente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pendientes_Tipo_Pendiente");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pendientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pendientes_Usuario");
            });

            modelBuilder.Entity<SerieUsuario>(entity =>
            {
                entity.HasKey(e => e.IdSerieUsuario);

                entity.ToTable("Serie_Usuario");

                entity.Property(e => e.IdSerieUsuario).HasColumnName("id_SerieUsuario");

                entity.Property(e => e.IdAvanceSerie).HasColumnName("id_AvanceSerie");

                entity.Property(e => e.IdSerie).HasColumnName("id_Serie");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAvanceSerieNavigation)
                    .WithMany(p => p.SerieUsuario)
                    .HasForeignKey(d => d.IdAvanceSerie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Serie_Usuario_Avance_Serie");

                entity.HasOne(d => d.IdSerieNavigation)
                    .WithMany(p => p.SerieUsuario)
                    .HasForeignKey(d => d.IdSerie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Serie_Usuario_Series");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.SerieUsuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Serie_Usuario_Usuario");
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.HasKey(e => e.IdSerie);

                entity.Property(e => e.IdSerie).HasColumnName("id_Serie");

                entity.Property(e => e.IdEstadoSerie).HasColumnName("id_EstadoSerie");

                entity.Property(e => e.IdGeneroSerie).HasColumnName("id_GeneroSerie");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Lanzamiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.OtrosGeneros)
                    .IsRequired()
                    .HasColumnName("Otros_Generos")
                    .IsUnicode(false);

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.IdEstadoSerieNavigation)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.IdEstadoSerie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Series_Estado");

                entity.HasOne(d => d.IdGeneroSerieNavigation)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.IdGeneroSerie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Series_Genero_Serie");
            });

            modelBuilder.Entity<TipoPendiente>(entity =>
            {
                entity.HasKey(e => e.IdTipoPendiente);

                entity.ToTable("Tipo_Pendiente");

                entity.Property(e => e.IdTipoPendiente).HasColumnName("id_TipoPendiente");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.ToTable("Tipo_Usuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_TipoUsuario");

                entity.Property(e => e.Descripción)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_Usuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fondo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdEstadoUsuario).HasColumnName("id_EstadoUsuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_TipoUsuario");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nick)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdEstadoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Estado_Usuario");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Tipo_Usuario");
            });

            modelBuilder.Entity<VAnime>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vAnime");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdAnime).HasColumnName("id_Anime");

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.Lanzamiento)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.OtrosGeneros)
                    .IsRequired()
                    .HasColumnName("Otros Generos")
                    .HasColumnType("text");

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<VJuegos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vJuegos");

                entity.Property(e => e.Desarrollador)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdDesarrollador).HasColumnName("id_Desarrollador");

                entity.Property(e => e.IdJuego).HasColumnName("id_Juego");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Lanzamiento)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtrosGeneros)
                    .IsRequired()
                    .HasColumnName("Otros_Generos")
                    .IsUnicode(false);

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<VLibros>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vLibros");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdAutor).HasColumnName("id_Autor");

                entity.Property(e => e.IdLibro).HasColumnName("id_Libro");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Lanzamiento)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.OtrosGeneros)
                    .HasColumnName("Otros_Generos")
                    .IsUnicode(false);

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<VManga>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vManga");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdManga).HasColumnName("id_Manga");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Lanzamiento)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.OtrosGeneros)
                    .IsRequired()
                    .HasColumnName("Otros_Generos")
                    .HasColumnType("text");

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<VPelicula>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vPelicula");

                entity.Property(e => e.Duracion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdPelicula).HasColumnName("id_Pelicula");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lanzamiento)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtrosGeneros)
                    .IsRequired()
                    .HasColumnName("Otros_Generos")
                    .IsUnicode(false);

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<VPendientes>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vPendientes");

                entity.Property(e => e.IdPendiente).HasColumnName("id_Pendiente");

                entity.Property(e => e.IdTipoPendiente).HasColumnName("id_TipoPendiente");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VSeries>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vSeries");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdSerie).HasColumnName("id_Serie");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Lanzamiento)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtrosGeneros)
                    .IsRequired()
                    .HasColumnName("Otros Generos")
                    .IsUnicode(false);

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
