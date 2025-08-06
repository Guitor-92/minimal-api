using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApi.Dominio.Entidades
{
    public class Administrador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!; 
        [Required]
        [MaxLength(255)]        
        public string Email { get; set; } = default!;
        [Required]
        [MaxLength(50)]    
        public string Senha { get; set; } = default!;
        [Required]
        [MaxLength(10)]        
        public string Perfil { get; set; } = default!;
    }
}
