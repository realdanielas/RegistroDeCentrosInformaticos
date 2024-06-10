using RegistroDeCentrosInformaticos.Models;

namespace RegistroDeCentrosInformaticos.Serv
{
    public interface IUserService
    {
        Task<Usuarios> GetCurrentUserAsync();
    }
}
