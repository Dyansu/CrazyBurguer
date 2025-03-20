using SQLite;

namespace ComidaApp.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string numero_telefono { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
    }
}

