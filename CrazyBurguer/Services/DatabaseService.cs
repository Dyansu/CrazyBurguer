using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using ComidaApp.Models;
using Xamarin.Forms;

namespace ComidaApp.Services
{
    public class DatabaseService
    {
        static SQLiteAsyncConnection db;

        public static async Task InitializeAsync()
        {
            if (db != null)
                return;

            var databasePath = System.IO.Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData),
                "comida_app_db.db3");
            db = new SQLiteAsyncConnection(databasePath);

            // Crear las tablas en la base de datos
            await db.CreateTableAsync<Usuario>();
            await db.CreateTableAsync<Direccion>();
            await db.CreateTableAsync<CategoriaSecundaria>();
            await db.CreateTableAsync<Producto>();
            await db.CreateTableAsync<Carrito>();
            await db.CreateTableAsync<DetalleCarrito>();
            await db.CreateTableAsync<Pedido>();
            await db.CreateTableAsync<DetallePedido>();
            await db.CreateTableAsync<Pago>();

            // Sembrar datos de ejemplo si no existen
            await SeedDataAsync();
        }

        // Método para obtener todos los productos de la base de datos
        public static async Task<List<Producto>> GetProductosAsync()
        {
            // Asegurarse de que la base de datos esté inicializada
            if (db == null)
                await InitializeAsync();
            return await db.Table<Producto>().ToListAsync();
        }

        public static async Task SeedDataAsync()
        {
            // Verifica si ya existen categorías
            var existingCategories = await db.Table<CategoriaSecundaria>().ToListAsync();
            if (existingCategories.Count > 0)
                return; // Ya hay datos, no se vuelven a insertar

            // Crear las categorías
            var hamburguesasCat = new CategoriaSecundaria { nombre = "Hamburguesas" };
            var bebidasCat = new CategoriaSecundaria { nombre = "Bebidas" };
            var complementosCat = new CategoriaSecundaria { nombre = "Complementos" };

            await db.InsertAsync(hamburguesasCat);
            await db.InsertAsync(bebidasCat);
            await db.InsertAsync(complementosCat);

            // Lista de productos para Hamburguesas (10 productos)
            var hamburguesasProducts = new List<Producto>
            {
                new Producto { nombre = "Hamburguesa Clásica", descripcion = "Carne, queso, lechuga, tomate y salsa especial", precio = 5.50m, idCategoriaSecundaria = hamburguesasCat.idCategoriaSecundaria },
                new Producto { nombre = "Hamburguesa Doble", descripcion = "Doble carne, queso extra y salsa BBQ", precio = 7.00m, idCategoriaSecundaria = hamburguesasCat.idCategoriaSecundaria },
                new Producto { nombre = "Hamburguesa con Bacon", descripcion = "Carne, queso, bacon crujiente y salsa especial", precio = 6.50m, idCategoriaSecundaria = hamburguesasCat.idCategoriaSecundaria },
                new Producto { nombre = "Hamburguesa Vegetariana", descripcion = "Hamburguesa de vegetales, lechuga, tomate y mayonesa", precio = 5.00m, idCategoriaSecundaria = hamburguesasCat.idCategoriaSecundaria },
                new Producto { nombre = "Hamburguesa Especial", descripcion = "Carne, queso, huevo frito, bacon y salsa secreta", precio = 8.00m, idCategoriaSecundaria = hamburguesasCat.idCategoriaSecundaria },
                new Producto { nombre = "Hamburguesa de Pollo", descripcion = "Pechuga de pollo a la parrilla, lechuga, tomate y mayonesa", precio = 6.00m, idCategoriaSecundaria = hamburguesasCat.idCategoriaSecundaria },
                new Producto { nombre = "Hamburguesa BBQ", descripcion = "Carne, queso cheddar, cebolla caramelizada y salsa BBQ", precio = 7.50m, idCategoriaSecundaria = hamburguesasCat.idCategoriaSecundaria },
                new Producto { nombre = "Hamburguesa Deluxe", descripcion = "Carne premium, queso suizo, aguacate y rúcula", precio = 9.00m, idCategoriaSecundaria = hamburguesasCat.idCategoriaSecundaria },
                new Producto { nombre = "Hamburguesa Mini", descripcion = "Mini hamburguesas perfectas para compartir", precio = 4.50m, idCategoriaSecundaria = hamburguesasCat.idCategoriaSecundaria },
                new Producto { nombre = "Hamburguesa Triple", descripcion = "Tres carnes, triple queso y salsa especial", precio = 10.00m, idCategoriaSecundaria = hamburguesasCat.idCategoriaSecundaria }
            };
            foreach (var product in hamburguesasProducts)
                await db.InsertAsync(product);

            // Lista de productos para Bebidas (10 productos reales)
            var bebidasProducts = new List<Producto>
            {
                new Producto { nombre = "Coca-Cola", descripcion = "Bebida gaseosa de cola", precio = 1.50m, idCategoriaSecundaria = bebidasCat.idCategoriaSecundaria },
                new Producto { nombre = "Pepsi", descripcion = "Bebida gaseosa de cola", precio = 1.50m, idCategoriaSecundaria = bebidasCat.idCategoriaSecundaria },
                new Producto { nombre = "Fanta Naranja", descripcion = "Bebida gaseosa de naranja", precio = 1.50m, idCategoriaSecundaria = bebidasCat.idCategoriaSecundaria },
                new Producto { nombre = "Sprite", descripcion = "Bebida gaseosa de limón-lima", precio = 1.50m, idCategoriaSecundaria = bebidasCat.idCategoriaSecundaria },
                new Producto { nombre = "Agua Mineral", descripcion = "Agua natural sin gas", precio = 1.00m, idCategoriaSecundaria = bebidasCat.idCategoriaSecundaria },
                new Producto { nombre = "Jugo de Naranja", descripcion = "Jugo 100% natural de naranja", precio = 2.00m, idCategoriaSecundaria = bebidasCat.idCategoriaSecundaria },
                new Producto { nombre = "Jugo de Manzana", descripcion = "Jugo 100% natural de manzana", precio = 2.00m, idCategoriaSecundaria = bebidasCat.idCategoriaSecundaria },
                new Producto { nombre = "Té Helado", descripcion = "Bebida refrescante de té", precio = 1.80m, idCategoriaSecundaria = bebidasCat.idCategoriaSecundaria },
                new Producto { nombre = "Limonada", descripcion = "Bebida refrescante de limón", precio = 1.80m, idCategoriaSecundaria = bebidasCat.idCategoriaSecundaria },
                new Producto { nombre = "Cerveza Lager", descripcion = "Cerveza de estilo lager", precio = 2.50m, idCategoriaSecundaria = bebidasCat.idCategoriaSecundaria }
            };
            foreach (var product in bebidasProducts)
                await db.InsertAsync(product);

            // Lista de productos para Complementos (10 productos: papas, nuggets, tequeños, alitas)
            var complementosProducts = new List<Producto>
            {
                new Producto { nombre = "Papas Fritas", descripcion = "Papas crujientes como acompañamiento", precio = 2.50m, idCategoriaSecundaria = complementosCat.idCategoriaSecundaria },
                new Producto { nombre = "Papas a la Francesa", descripcion = "Papas de corte grueso y doradas", precio = 2.80m, idCategoriaSecundaria = complementosCat.idCategoriaSecundaria },
                new Producto { nombre = "Nuggets de Pollo", descripcion = "Nuggets crujientes de pollo", precio = 3.50m, idCategoriaSecundaria = complementosCat.idCategoriaSecundaria },
                new Producto { nombre = "Nuggets Especiales", descripcion = "Nuggets con un toque de especias", precio = 3.80m, idCategoriaSecundaria = complementosCat.idCategoriaSecundaria },
                new Producto { nombre = "Tequeños de Queso", descripcion = "Tequeños rellenos de queso", precio = 3.00m, idCategoriaSecundaria = complementosCat.idCategoriaSecundaria },
                new Producto { nombre = "Tequeños Jamón y Queso", descripcion = "Tequeños rellenos de jamón y queso", precio = 3.50m, idCategoriaSecundaria = complementosCat.idCategoriaSecundaria },
                new Producto { nombre = "Alitas Picantes", descripcion = "Alitas de pollo con salsa picante", precio = 4.50m, idCategoriaSecundaria = complementosCat.idCategoriaSecundaria },
                new Producto { nombre = "Alitas BBQ", descripcion = "Alitas bañadas en salsa BBQ", precio = 4.50m, idCategoriaSecundaria = complementosCat.idCategoriaSecundaria },
                new Producto { nombre = "Combo Complementos 1", descripcion = "Papas, Nuggets y Tequeños en combo", precio = 7.00m, idCategoriaSecundaria = complementosCat.idCategoriaSecundaria },
                new Producto { nombre = "Combo Complementos 2", descripcion = "Alitas, Papas y Nuggets", precio = 8.00m, idCategoriaSecundaria = complementosCat.idCategoriaSecundaria }
            };
            foreach (var product in complementosProducts)
                await db.InsertAsync(product);
        }
    }
}
