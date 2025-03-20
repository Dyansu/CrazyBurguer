using SQLite;

namespace ComidaApp.Models
{
    [Table("DETALLE_PEDIDO")]
    public class DetallePedido
    {
        [PrimaryKey, AutoIncrement]
        public int idDetallePedido { get; set; }
        public int idPedido { get; set; }
        public int idProducto { get; set; }
        public ushort cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal subtotal { get; set; }
    }
}
