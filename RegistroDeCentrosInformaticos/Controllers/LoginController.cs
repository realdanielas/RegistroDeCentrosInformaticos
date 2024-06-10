using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegistroDeCentrosInformaticos.Models;
using System.Text.Json;

namespace RegistroDeCentrosInformaticos.Controllers
{
    public class LoginController : Controller
    {
        //Necesario para llamar el contexto
        private readonly prestauniccDbContext _prestauniccDbContext;

        public LoginController(prestauniccDbContext prestauniccDbContext)
        {
            _prestauniccDbContext = prestauniccDbContext;
        }

        public IActionResult Login()
        {
            var listaUsuarios = (from u in _prestauniccDbContext.usuarios
                                select u).ToList();
            ViewData["listaUsuarios"] = new SelectList(listaUsuarios, "correo", "passve");

            //Aqui recuperamos los datos de la variable de session hacia el objeto "datosUsuario"
            if (HttpContext.Session.GetString("user") != null)
            {
                var datosUsuario = JsonSerializer.Deserialize<Usuarios>(HttpContext.Session.GetString("user"));
                ViewBag.NombreUsuario = datosUsuario.correo;
            }
            return View();
        }

        //Creo que aquí se debería poner el IF dependiendo que qué tipo de usuario se está validando
        public IActionResult ValidarUsuario(Credenciales credenciales)
        {

            Usuarios? usuario = (from user in _prestauniccDbContext.usuarios
                                 where user.correo == credenciales.correo
                                 && user.passve == credenciales.passve
                                 select user).FirstOrDefault();

            //Si las credenciales no son correctas, saltara el mensaje de error
            if (usuario == null)
            {
                ViewBag.MensajeError = "Credenciales incorrectas, por favor revisar los datos ingresados.";
                return View("Login");
            }
            
            //Si no da error, saltara a estas lineas de codigo
            string datoUsuario = JsonSerializer.Serialize(usuario);
            HttpContext.Session.SetString("user", datoUsuario);
            return RedirectToAction("Index", "Home");

            /*Comprobación de tipo de usuario al autenticar...
            if (usuario.id_rol == 1)
            {
                HttpContext.Session.SetString("user", datoUsuario);
                return RedirectToAction("HomeCliente", "Cliente");
            }
            if (usuario.id_rol == 2)
            {
                HttpContext.Session.SetString("user", datoUsuario);
                return RedirectToAction("HomeAdmin", "Admin");
            }
            else
            {
                //Para los empleados (cuando tengan su propia vista...)
                HttpContext.Session.SetString("user", datoUsuario);
                return RedirectToAction("HomeEmpleado", "Empleado");
            }*/
        }
    }
}
