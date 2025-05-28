using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace EscanerQR.View;

public partial class ScanPage : ContentPage
{
    private readonly Action<string> _onScanCompleted;
    public ScanPage(Action<string> onScanCompleted)
	{
		InitializeComponent();
        _onScanCompleted = onScanCompleted;
    }

    private void OnBarcodeDetected(object sender, BarcodeDetectionEventArgs e)
    {
        string? qrContent = e.Results.FirstOrDefault()?.Value;
        if (!string.IsNullOrEmpty(qrContent))
        {
            cameraBarcodeReaderView.IsDetecting = false;
            //var codigo = e.Results.FirstOrDefault()?.Value;
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _onScanCompleted.Invoke(qrContent); //Devuelve el resultado a MainPage
                //DisplayAlert("QR Detectado", $"Carné: {codigo}", "OK");
                Navigation.PopModalAsync();//Cierra la página del escáner
            });
        }
    }
}