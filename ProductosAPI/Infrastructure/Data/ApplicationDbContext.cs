using Microsoft.EntityFrameworkCore;
using ProductosAPI.Domain.Entities;

namespace ProductosAPI.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Maquina> Maquinas { get; set; }
    }
}
