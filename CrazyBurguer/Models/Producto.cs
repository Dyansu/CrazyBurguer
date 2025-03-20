using SQLite;

namespace ComidaApp.Models
{
    [Table("PRODUCTO")]
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public byte[] imagen { get; set; }  // Almacena la imagen como BLOB o usa rutas/URLs
        public int idCategoriaSecundaria { get; set; }
    }
}

