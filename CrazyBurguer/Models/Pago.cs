using SQLite;
using System;

namespace ComidaApp.Models
{
    [Table("PAGO")]
    public class Pago
    {
        [PrimaryKey, AutoIncrement]
        public int idPago { get; set; }
        public int idPedido { get; set; }
        public decimal monto { get; set; }
        public DateTime fecha_pago { get; set; }
        public string metodo_pago { get; set; }  // "tarjeta_credito", "efectivo", "paypal"
        public string estado { get; set; }         // "confirmado", "pendiente", "fallido"
        public string id_transaccion { get; set; }
    }
}
