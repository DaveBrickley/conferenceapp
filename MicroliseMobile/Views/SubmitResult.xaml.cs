using System;
using System.Collections.Generic;
using MicroliseMobile.Authenticate;
using MicroliseMobile.Scanner;
using Plugin.Connectivity;
using System.Web;

using Xamarin.Forms;

namespace MicroliseMobile.Views
{
    public partial class SubmitResult : ContentPage
    {
        public SubmitResult()
        {
            InitializeComponent();

        }


        async public void SubmitCodeToCloud(string code)

        {


            //string encodedString = Base64Encode(code);

            System.Diagnostics.Debug.WriteLine("Debug: user is attempting to submit code of length " + code.Length + ":" + code);

            var submit = new CloudData();

            var response = await submit.PostBarcode(code);

            if (response == "OK")

            {

                var action = await DisplayAlert("Success", "Your barcode was successfully stored in the Cloud. Scan another?", "OK", "Cancel");

                if (action)

                {
                    var scanPage = new FullScreenScanning();
                    // Navigate to our scanner page
                    await Navigation.PushModalAsync(scanPage);
                    NavigationPage.SetHasBackButton(this, false);

                }

                else

                {

                    var About = new Views.AboutPage();

                    // Navigate to our scanner page
                    await Navigation.PushModalAsync(About);
                    NavigationPage.SetHasBackButton(this, false);

                }

            }

            else

            {

                await DisplayAlert("Alert", "An error occurred, please scan and submit your barcode again", "OK");



            }


        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {

                await DisplayAlert("Network", "Please check you are connected to the network", "Ok");
            }

            else

            {

                SubmitCodeToCloud(TextID.Text);

            }

        }
    }
}
