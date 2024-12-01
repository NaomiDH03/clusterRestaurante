using clusterRestaurante.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clusterRestaurante.Shared.DTOs
{
    public class UserDTO:User
    {
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "La {0} debe tener entre {2} y {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Coonfirmación de contraseña")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "La {0} debe tener entre {2} y {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
