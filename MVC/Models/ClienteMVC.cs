using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class ClienteMVC
    {   
       
        public int Id { get; set; }
        
        public string Nombre;
        
        public string Apellido;
      
        public string Ciudad;
      
        public string Pais;
      
        public string Telefono;
    }
}
