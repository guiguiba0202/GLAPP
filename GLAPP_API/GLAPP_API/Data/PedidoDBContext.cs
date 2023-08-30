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
        public DbSet<PizzaModel> Pizzas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
