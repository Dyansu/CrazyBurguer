using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ComidaApp.Models;
using ComidaApp.Services;
using System.Linq;

namespace ComidaApp.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private ObservableCollection<Producto> productos;
        public ObservableCollection<Producto> Productos
        {
            get => productos;
            set
            {
                productos = value;
                OnPropertyChanged();
            }
        }

        private string busqueda;
        public string Busqueda
        {
            get => busqueda;
            set
            {
                busqueda = value;
                OnPropertyChanged();
            }
        }

        // Comandos para búsqueda y filtrado
        public ICommand BuscarCommand { get; }
        public ICommand FiltrarCommand { get; }

        public MainViewModel()
        {
            Productos = new ObservableCollection<Producto>();
            BuscarCommand = new Command(async () => await BuscarProductos());
            FiltrarCommand = new Command<string>(async (categoria) => await FiltrarProductos(categoria));

            // Cargar productos de forma asíncrona
            Task.Run(async () => await CargarProductos());
        }

        private async Task CargarProductos()
        {
            var lista = await DatabaseService.GetProductosAsync();
            Device.BeginInvokeOnMainThread(() =>
            {
                Productos.Clear();
                foreach (var item in lista)
                    Productos.Add(item);
            });
        }

        private async Task BuscarProductos()
        {
            var lista = await DatabaseService.GetProductosAsync();
            var resultado = lista.Where(p => p.nombre.ToLower().Contains(Busqueda?.ToLower() ?? string.Empty)).ToList();
            Device.BeginInvokeOnMainThread(() =>
            {
                Productos.Clear();
                foreach (var item in resultado)
                    Productos.Add(item);
            });
        }

        private async Task FiltrarProductos(string categoria)
        {
            var lista = await DatabaseService.GetProductosAsync();
            var resultado = lista.Where(p => p.nombre.ToLower().Contains(categoria.ToLower())).ToList();
            Device.BeginInvokeOnMainThread(() =>
            {
                Productos.Clear();
                foreach (var item in resultado)
                    Productos.Add(item);
            });
        }
    }
}
