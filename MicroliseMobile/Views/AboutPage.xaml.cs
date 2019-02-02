using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MicroliseMobile.Authenticate;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace MicroliseMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        async void Handle_Clicked(object sender, System.EventArgs e)
        {

            if (CrossConnectivity.Current.IsConnected)

            {

                //await Navigation.PushModalAsync(new Authenticate.LoginPage());
                //NavigationPage.SetHasBackButton(this, false);

                Application.Current.MainPage = new Authenticate.LoginPage();
            }

            else

            {


                await DisplayAlert("Network", "Please check your network connection", "OK");



            }


        }


        public AboutPage()
        {
            InitializeComponent();
        }
    }
}