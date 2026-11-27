
using Microsoft.AspNetCore.Mvc;
using ParqueChingazaMVC.Models;

namespace ParqueChingazaMVC.Controllers
{
    public class ReservasController : Controller
    {
        private static readonly List<Reserva> reservas = new();
        private static readonly object bloqueo = new();
        private static int siguienteId = 1;

        [HttpGet]
        public IActionResult Index()
        {
            lock (bloqueo)
            {
                return View(reservas.ToList());
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Reserva());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reserva reserva)
        {
            string[] actividades =
            {
                "Senderismo",
                "Ciclismo",
                "Observacion de aves",
                "Educacion ambiental"
            };

            if (!actividades.Contains(reserva.Actividad))
            {
                ModelState.AddModelError(
                    "Actividad",
                    "Seleccione una actividad valida");
            }

            if (ModelState.IsValid)
            {
                reserva.Total =
                    reserva.CantidadPersonas * 15000m;

                lock (bloqueo)
                {
                    reserva.Id = siguienteId++;
                    reservas.Add(reserva);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(reserva);
        }
    }
}