using SQLite;
using System;

namespace ComidaApp.Models
{
    [Table("CARRITO")]
    public class Carrito
    {
        [PrimaryKey, AutoIncrement]
        public int idCarrito { get; set; }
        public int idUsuario { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_actualizacion { get; set; }
        public string estado { get; set; }  // "activo" o "cerrado"
    }
}
