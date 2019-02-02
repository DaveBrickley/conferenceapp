using System;
using System.Collections.Generic;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using MicroliseMobile.Models;

using Xamarin.Forms;

namespace MicroliseMobile.Authenticate
{
    public partial class LoginPage : ContentPage
    {


        async void CallAuthenticate()

        {

            var x = new CloudData();
            AuthenticationResult token = await x.GetAccessToken();
            System.Diagnostics.Debug.WriteLine("Debug: access token " + token);

            if (token == null)

            {


                await DisplayAlert("Alert", "User has cancelled login or the browser is incompatible", "OK");

                var About = new Views.AboutPage();

                // Navigate to our scanner page
                //await Navigation.PushModalAsync(About);
                //NavigationPage.SetHasBackButton(this, false);

                Application.Current.MainPage = About;

                return;
            }

            GraphUser y = await x.GetDisplayName();

            //await DisplayAlert("Alert", "Welcome, " + y, "OK");

            var displayName = new Item
            {

                Id = y.displayName,
                Text = "Welcome! You have successfully logged in"


            };

            var Scanner = new Scanner.Scanner();

            Scanner.BindingContext = displayName;

            // Navigate to our scanner page
            //await Navigation.PushModalAsync(Scanner);
            //NavigationPage.SetHasBackButton(this, false);

            Application.Current.MainPage = Scanner;

        }



        public LoginPage()
        {
            InitializeComponent();

            CallAuthenticate();
        }
    }
}
