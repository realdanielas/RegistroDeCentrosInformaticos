using RegistroDeCentrosInformaticos.Models;
using System.Text.Json;

namespace RegistroDeCentrosInformaticos.Serv
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly prestauniccDbContext _context;

        public UserService(IHttpContextAccessor httpContextAccessor, prestauniccDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<Usuarios> GetCurrentUserAsync()
        {
            var userJson = _httpContextAccessor.HttpContext.Session.GetString("user");
            if (string.IsNullOrEmpty(userJson))
            {
                return null;
            }

            var usuarioSesion = JsonSerializer.Deserialize<Usuarios>(userJson);
            return await _context.usuarios.FindAsync(usuarioSesion.correo);
        }
    }
}
