using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class ClienteMVC
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre;
        [Required]
        public string Apellido;
        [Required]
        public string Ciudad;
        [Required]
        public string Pais;
        [Required]
        public string Telefono;
    }
}
