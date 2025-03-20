using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComidaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenuFlyoutPage : ContentPage
    {
        public SideMenuFlyoutPage()
        {
            InitializeComponent();
        }

        private void OnCerrarClicked(object sender, EventArgs e)
        {
            if (Application.Current.MainPage is FlyoutPage flyoutPage)
            {
                flyoutPage.IsPresented = false;
            }
        }
    }
}
