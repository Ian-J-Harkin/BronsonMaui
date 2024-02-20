namespace BronsonMaui
{
    public partial class MainPage : ContentPage
    {
        //int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            //count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult myPhoto = await MediaPicker.Default.CaptureVideoAsync();


                if (myPhoto != null)
                {
                    //save the image captured in the application.
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, myPhoto.FileName);
                    using Stream sourceStream = await myPhoto.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);
                    await sourceStream.CopyToAsync(localFileStream);
                    await Shell.Current.DisplayAlert("OOPS", localFileStream.Name, "Ok");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Your device is not supported", "");
            }
        }
    }
}