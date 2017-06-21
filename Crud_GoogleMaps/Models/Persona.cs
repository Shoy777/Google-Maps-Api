using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Crud_GoogleMaps.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Ingrese Nombre de Persona")]
        [StringLength(30, ErrorMessage = "Parece que el Nombre es muy largo")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "Ingrese Apellido de Persona")]
        [StringLength(30, ErrorMessage = "Parece que el Apellido es muy largo")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Seleccion Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Seleccion una Ubicación")]
        [StringLength(100)]
        public string CX { get; set; }

        [Required(ErrorMessage = "Seleccion una Ubicación")]
        [StringLength(100)]
        public string CY { get; set; }
    }
}