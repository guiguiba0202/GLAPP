using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLAPP_API.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        public string? Desc { get; set; }

        [Required]
        public string? Status { get; set; }

        public ICollection<NotaPizza> Pizzas { get; set; } = default!;
    }
}
