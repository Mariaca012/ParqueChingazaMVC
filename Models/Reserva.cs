
using System.ComponentModel.DataAnnotations;

namespace ParqueChingazaMVC.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese su nombre")]
        [StringLength(100)]
        public string NombreVisitante { get; set; } = "";

        [Required(ErrorMessage = "Seleccione una actividad")]
        public string Actividad { get; set; } = "";

        [Range(1, 100)]
        public int CantidadPersonas { get; set; } = 1;

        public decimal Total { get; set; }
    }
}