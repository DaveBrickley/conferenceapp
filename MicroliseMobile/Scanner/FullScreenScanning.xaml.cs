using Xamarin.Forms;
using ZXing;
using ZXing.Net.Mobile.Forms;
using MicroliseMobile.Models;
using MicroliseMobile.Views;
using MicroliseMobile.Scanner;
using System.IO;
using System.Web;

namespace MicroliseMobile.Scanner
{
    public partial class FullScreenScanning : ContentPage
    {

        public bool HasResult = false;

        public FullScreenScanning()
        {
            InitializeComponent();
        }



        public void Handle_OnScanResult(Result result)
        {

            if (HasResult == true)

            {

                return; // do nothing - stop having more than one popup open

            }

            Device.BeginInvokeOnMainThread(async () =>
            {
                HasResult = true;

                if (result.Text.Length > 200)

                {

                    await DisplayAlert("Alert", "The code scanned is larger than can be stored in the database", "OK");

                    return;


                }


                var action = await DisplayAlert("Scanned result", result.Text, "Submit","Keep Scanning");

                if (result.Text == "http://www.homster.net")

                {


                    throw new System.Exception

                    {


                    };

                }






                var encodedString = HttpUtility.UrlEncode(result.Text);

                if (action)

                {
                    var barCode = new Item
                    {

                        Id = encodedString,
                        Text = "Please click the button below to submit your scanned code to the Microlise database"


                    };

                    //var Submit = new SubmitResult();

                    //Submit.SubmitCodeToCloud(result.Text);


                    var Submit = new Views.SubmitResult();

                    Submit.BindingContext = barCode;

                    // Navigate to our scanner page
                    await Navigation.PushModalAsync(Submit);
                    NavigationPage.SetHasBackButton(this, false);

                    HasResult = false;

                }

                else

                {
                    HasResult = false;

                }


            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _scanView.IsScanning = true;

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            

            _scanView.IsScanning = false;

        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {


            var About = new Views.AboutPage();

            // Navigate to our scanner page
            await Navigation.PushModalAsync(About);
        }
    }
}