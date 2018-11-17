using System;
using System.Collections.Generic;


using Xamarin.Forms;

namespace MicroliseMobile.Scanner
{
    public partial class Scanner : ContentPage
    {

        public Scanner()
        {
            InitializeComponent();
        }


        async void Handle_Clicked(object sender, System.EventArgs e)
        {


            var scanPage = new FullScreenScanning();
            // Navigate to our scanner page
            await Navigation.PushModalAsync(scanPage);
            //NavigationPage.SetHasBackButton(this, false);

        }

        async void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            var logmeout = new Authenticate.CloudData();

            logmeout.Logout();

            var home = new Views.AboutPage();
            // Navigate to our scanner page
            await Navigation.PushModalAsync(home);
            NavigationPage.SetHasBackButton(this, false);

        }


        protected override bool OnBackButtonPressed()
        {
            System.Diagnostics.Debug.WriteLine("Debug: back button pressed");

            return true;
        }
    }
}
