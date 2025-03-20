using SQLite;

namespace ComidaApp.Models
{
    [Table("DETALLE_CARRITO")]
    public class DetalleCarrito
    {
        [PrimaryKey, AutoIncrement]
        public int idDetalleCarrito { get; set; }
        public int idCarrito { get; set; }
        public int idProducto { get; set; }
        public ushort cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal subtotal { get; set; }
    }
}
