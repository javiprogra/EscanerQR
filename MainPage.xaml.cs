using ZXing.Net.Maui;

namespace EscanerQR
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnBarcodeDetected(object sender, BarcodeDetectionEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                string? qrContent = e.Results.FirstOrDefault()?.Value;
                if (!string.IsNullOrEmpty(qrContent))
                {
                    DisplayAlert("Código QR detectado", qrContent, "OK");
                }
            });
        }
    }
}
