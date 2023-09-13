using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLAPP_API.Models
{
    public class PizzaModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? Nome { get; set; }
        
        [Required]
        public string? Desc { get; set; }
        
        [Required]
        public string? Sabor { get; set; }
    }

}