using KV.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace KV.Data.Context
{
    public class KvContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public KvContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }
    }
}