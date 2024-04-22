using Microsoft.EntityFrameworkCore;
using PruebaTecnicaDaCodes.Models;

namespace PruebaTecnicaDaCodes.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<School> Schools { get; set; }
    }
}
