using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clusterRestaurante.Shared.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required] //Esto significa que será un campo requerido, o sea, obligatorio
        [MaxLength(100, ErrorMessage = "El campo{0} debe tener máximo {1} caracteres ")]
        //Nota: El required y MaxLenght solo afecta a la propiedad siguiente, o sea, Flavour
        [Display(Name = "Tienda")]
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int Telephone { get; set; }
    }
}
