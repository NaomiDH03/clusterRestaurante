using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace clusterRestaurante.Shared.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required] //Esto significa que será un campo requerido, o sea, obligatorio
        [MaxLength(100, ErrorMessage = "El campo{0} debe tener máximo {1} caracteres ")]
        //Nota: El required y MaxLenght solo afecta a la propiedad siguiente, o sea, Flavour
        [Display(Name = "Empleado")]
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public int Telephone { get; set; }

        public string Email { get; set; } = null!;

        public Restaurant Restaurant { get; set; } = null!;
    }
}
