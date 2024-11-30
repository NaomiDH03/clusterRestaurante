using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace clusterRestaurante.Shared.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        [Required] //Esto significa que será un campo requerido, o sea, obligatorio
        [MaxLength(100, ErrorMessage = "El campo{0} debe tener máximo {1} caracteres ")]
        //Nota: El required y MaxLenght solo afecta a la propiedad siguiente, o sea, Flavour
        [Display(Name = "Tienda")]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public Employee Employee { get; set; } = null!;
    }
}
