using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegistroDeCentrosInformaticos.Models;
using System.Diagnostics;
using System.Text.Json;

namespace RegistroDeCentrosInformaticos.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        private readonly prestauniccDbContext _prestauniccDbContext;

        public HomeController(prestauniccDbContext prestauniccDbContext)
        {
            _prestauniccDbContext = prestauniccDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Agendar()
        {
            var Agendar = (from u in _prestauniccDbContext.usuarios
                                   join p in _prestauniccDbContext.prestamos on u.carnet equals p.carnet
                                  select new
                                  {
                                    u.nombres,
                                    u.apellidos,
                                    u.carnet,
                                    p.idcomputo,
                                    p.idestado,
                                    p.hora_entrada,
                                    p.hora_salida,
                                    p.comentario
                                  }).ToList();

            //var listaDeEstado = (from e in _prestauniccDbContext.estadoscc
            //                     select e).ToList();
            //ViewData["listaDeEstado"] = new SelectList(listaDeEstado, "descripcion");

            ViewBag.usuarios = Agendar;
            return View();
        }
        
        public IActionResult AjustesPerfil()
        {
            var datosUsuario = JsonSerializer.Deserialize<Usuarios>(HttpContext.Session.GetString("user"));
            ViewBag.NombreUsuario = datosUsuario.nombres;
            ViewBag.ApellidoUsuario = datosUsuario.apellidos;
            ViewBag.CarnetUsuario = datosUsuario.carnet;
            ViewBag.CorreoUsuario = datosUsuario.correo;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
