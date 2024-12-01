using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clusterRestaurante.Shared.DTOs
{
    public class LoginDTO
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "La {0} debe tener entre {2} y {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Contaseña")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "La {0} debe tener mínimo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Password { get; set; } = null!;
    }
}
