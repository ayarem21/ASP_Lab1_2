using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace ArtsNamespace.Models
{
    public class ArtDbContext : DbContext
    {
        public ArtDbContext(DbContextOptions<ArtDbContext> options) : base(options)
        {
        }

        public DbSet<Art> Art { get; set; }
        public DbSet<Album> Album { get; set; }
    }
}