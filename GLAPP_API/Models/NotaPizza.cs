using System.ComponentModel.DataAnnotations;

namespace GLAPP_API.Models
{
    public class NotaPizza
    {
        public int Id { get; set; }
        public string? Obs {get; set; }
        
        [Required]
        public int PedidoId { get; set; }

        public PizzaModel? Pizza { get; set; }

        [Required]
        public int PizzaId { get; set; }

        public Pedido? Pedido { get; set; }
    }
}
