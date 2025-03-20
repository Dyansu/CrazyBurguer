using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComidaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Al tocar el ícono de usuario, se activa el flyout con animación
        private async void OnUserIconTapped(object sender, EventArgs e)
        {
            // Animación de "scale" al pulsar
            await UserIcon.ScaleTo(1.2, 100);
            await UserIcon.ScaleTo(1, 100);

            if (Application.Current.MainPage is FlyoutPage flyoutPage)
            {
                flyoutPage.IsPresented = true;
            }
        }

        // Al tocar el ícono de carrito, se abre la página modal con animación
        private async void OnCartIconTapped(object sender, EventArgs e)
        {
            await CartIcon.ScaleTo(1.2, 100);
            await CartIcon.ScaleTo(1, 100);
            await Navigation.PushModalAsync(new CartPage());
        }
    }
}


