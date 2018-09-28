using System;
using System.Collections.Generic;
using System.IO;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class PictureView : ContentPage
    {

        public PictureView()
        {
            InitializeComponent();
        }

        async void BrowseForPicture(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();


            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            try
            {
                Stream stream = null;
                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file == null)
                    return;

                stream = file.GetStream();
                file.Dispose();
                showedPicture.Source = ImageSource.FromStream(() => stream);

            }
            catch //(Exception ex)
            {
                await DisplayAlert("Error.", "Error", "OK");
                // Xamarin.Insights.Report(ex);
                // await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured it in Xamarin Insights! Thanks.", "OK");
            }

        }

        async void RecordPicture(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || CrossMedia.Current.IsTakePhotoSupported) {
                await DisplayAlert("Error.", "No camera avaiablde!", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            showedPicture.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

        }

    }
}
