using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NerdCore.Models;
using Microsoft.EntityFrameworkCore;

namespace NerdCore.Data
{
    public class AnimeContext : DbContext
    {
        public AnimeContext(DbContextOptions<AnimeContext> options)
            : base(options)
        {
        }

        public DbSet<Anime> Anime { get; set; }
    }
}
