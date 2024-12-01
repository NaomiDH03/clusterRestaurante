using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clusterRestaurante.Shared.Entities
{
    public class User: IdentityUser
    {
        [Required]
        [MaxLength(100, ErrorMessage = "El campo{0} debe tener máximo {1} caracteres ")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(100, ErrorMessage = "El campo{0} debe tener máximo {1} caracteres ")]
        [Display(Name = "Apellido/s")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Foto")]
        public string? Photo { get; set; }

        [Display(Name = "Tipo de usuario")]
        public UserType? UserType { get; set; }

        public Employee? Employee { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debes selecionar {0}")]
        public int EmployeeId { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
