using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;
using EscanerQR.View;
using EscanerQR.Models;

namespace EscanerQR
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnValidarCarnetManualClicked(object sender, EventArgs e)
        {
            var carnet = carnetEntry.Text?.Trim();
            string? valido = "";
            string? image = "";
            bool sonidoValido;

            if (string.IsNullOrEmpty(carnet))
            {
                DisplayAlert("Campo vacío", "Por favor, ingrese un numero de carné.", "OK");
            }
            else
            {
                int[]carnetArray = new int[10];
                
                
                ValidarCarnet validarCarnet = new ValidarCarnet();
                
                for (int i = 0; i < carnet.Length; i++)
                {
                    carnetArray[i] = int.Parse(carnet[i].ToString());
                }

                if (carnetArray[9] == validarCarnet.digitoValidacion(carnet))
                {
                    //DisplayAlert("Carné válido", "Número de carné válido.", "OK");
                    valido = "El carnet es valido";
                    image = "check.png";
                    sonidoValido = true;
                }
                else
                {
                    //DisplayAlert("Carné válido", "Número de carné NO válido.", "OK")
                    valido = "El carnet no es valido";
                    image = "error.png";
                    sonidoValido = false;
                }

                Navigation.PushModalAsync(new CarnetPopup(valido, image, sonidoValido));
            }
        }

        private async void OnEscanearQRClicked(object sender, EventArgs e)
        {
            var scanPage = new ScanPage((qrText) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    carnetEntry.Text = qrText;
                    /*resultadoLabel.Text = $"Carné escaneado: {qrText}";
                    resultadoLabel.TextColor = Colors.Green;*/
                });
            });
            await Navigation.PushModalAsync(scanPage);
        }
    }
}