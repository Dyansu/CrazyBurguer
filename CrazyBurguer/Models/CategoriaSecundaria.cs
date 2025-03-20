using SQLite;

namespace ComidaApp.Models
{
    [Table("CATEGORIA_SECUNDARIA")]
    public class CategoriaSecundaria
    {
        [PrimaryKey, AutoIncrement]
        public int idCategoriaSecundaria { get; set; }
        public string nombre { get; set; }
    }
}
