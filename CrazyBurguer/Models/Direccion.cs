using SQLite;

namespace ComidaApp.Models
{
    [Table("DIRECCION")]
    public class Direccion
    {
        [PrimaryKey, AutoIncrement]
        public int idDireccion { get; set; }
        public int idUsuario { get; set; }
        public string direccion { get; set; }
        public string tipo_direccion { get; set; } // "casa", "trabajo", "otro"
    }
}

