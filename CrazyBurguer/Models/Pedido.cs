using SQLite;
using System;

namespace ComidaApp.Models
{
    [Table("PEDIDO")]
    public class Pedido
    {
        [PrimaryKey, AutoIncrement]
        public int idPedido { get; set; }
        public int idUsuario { get; set; }
        public DateTime fecha_pedido { get; set; }
        public decimal total { get; set; }
        public string estado { get; set; }  // "pendiente", "pagado", "cancelado"
        public int idDireccion { get; set; }
    }
}
