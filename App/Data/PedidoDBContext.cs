using GLAPP_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GLAPP_API.Data
{
    public class PedidoDBContext : DbContext
    {
        public PedidoDBContext(DbContextOptions<PedidoDBContext> options)
            : base(options)
        {

        }
        //criando tabela Pizzas
        public DbSet<PizzaModel> tbPizzas { get; set; }
        public DbSet<Pedido> tbPedidos { get; set; }
        public DbSet<NotaPizza> tbNotaPizza { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotaPizza>()
                .HasOne(a => a.Pizza)
                .WithOne()
                .HasForeignKey<NotaPizza>(a => a.PizzaId);

            modelBuilder.Entity<NotaPizza>()
                .HasOne(a => a.Pedido)
                .WithMany(b => b.Pizzas)
                .HasForeignKey(a => a.PedidoId);

        }
    }
}
