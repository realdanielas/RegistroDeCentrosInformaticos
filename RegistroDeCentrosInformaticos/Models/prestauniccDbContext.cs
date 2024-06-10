using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace RegistroDeCentrosInformaticos.Models
{
    public class prestauniccDbContext : DbContext
    {
        public prestauniccDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Tipo_usuario> tipoUsuario { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Decanatos> decanatos { get; set; }
        public DbSet<Carreras> carreras { get; set; }
        public DbSet<Alu_datos> alumnoDatos { get; set; }
        public DbSet<Computo> computo { get; set; }
        public DbSet<Estadoscc> estadoscc { get; set; }
        public DbSet<Prestamos> prestamos { get; set; }
    }
}
