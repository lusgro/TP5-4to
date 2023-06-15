using Microsoft.AspNetCore.Mvc;
using TP5.Models;

namespace TP5.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Tutorial()
    {
        return View();
    }

    public IActionResult Comenzar()
    {
        return View($"Habitacion{Escape.GetEstadoJuego()}");    
    }

    public IActionResult Creditos()
    {
        return View();
    }

    public IActionResult Victoria()
    {
        ViewBag.Intentos = Escape.intentos;
        ViewBag.PistasUsadas = Escape.pistasUsadas;
        return View();
    }

    [HttpPost]
    public IActionResult Habitacion(int sala, string clave)
    {
        if (Escape.GetEstadoJuego() != sala)
        {
            return RedirectToAction("Comenzar");
        }
        if (Escape.ResolverSala(sala, clave.ToLower()))
        {
            if (Escape.GetEstadoJuego() == 5)
            {
                return RedirectToAction("Victoria");
            }
            else
            {
                return View($"Transicion{sala + 1}");
            }
        }
        else
        {
            ViewBag.Error = "La respuesta es incorrecta.";
            Escape.intentos++;
            return View($"Habitacion{sala}");
        }
    }

    public IActionResult Transicion(int sala)
    {
        return View($"Transicion{sala}");
    }
}
