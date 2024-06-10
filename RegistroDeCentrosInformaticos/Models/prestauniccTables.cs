using System.ComponentModel.DataAnnotations;

namespace RegistroDeCentrosInformaticos.Models
{
    public class prestauniccTables
    {
    }
    public class Tipo_usuario
    {
        [Key]
        public int tipo_usua { get; set; }
        public string? nom_usuari { get; set; }
    }

    public class Usuarios
    {
        [Key]
        public string? carnet { get; set; }
        public string? apellidos { get; set; }
        public string? nombres { get; set; }
        public int tipo_usua { get; set; }
        public string? correo { get; set; }
        public string? passve { get; set; }
    }

    public class Decanatos
    {
        [Key]
        public int cod_deca { get; set; }
        public string? nom_deca { get; set; }
    }

    public class Carreras
    {
        [Key]
        public int cod_carr { get; set; }
        public string? nom_carr { get; set; }
        public int cod_deca { get; set; }
        public int tipo_usua { get; set; }
        public string? correo { get; set; }
        public string? passve { get; set; }
    }

    public class Alu_datos
    {
        [Key]
        public string? carnet { get; set; }
        public int cod_carr { get; set; }
        public int cod_deca { get; set; }
        public string? correo { get; set; }
        public string? passve { get; set; }
    }

    public class Computo
    {
        [Key]
        public int idcomputo { get; set; }
        public string? descripcion { get; set; }
    }

    public class Estadoscc
    {
        [Key]
        public int idestado { get; set; }
        public string? descripcion_estados { get; set; }
    }

    public class Prestamos
    {
        [Key]
        public int idprestamo { get; set; }
        public string? carnet { get; set; }
        public int idcomputo { get; set; }
        public int idestado { get; set; }
        public DateTime hora_entrada { get; set; }
        public DateTime hora_salida { get; set; }
        public string? comentario { get; set; }

    }
}
