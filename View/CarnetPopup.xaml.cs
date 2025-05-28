namespace EscanerQR.View;
using Plugin.Maui.Audio;

public partial class CarnetPopup : ContentPage
{
    private readonly IAudioPlayer? player;
	public CarnetPopup(string mensaje, string imagen, bool sonidoValido)
	{
		InitializeComponent();

        ResultadoTexto.Text = mensaje;
        ResultadoImagen.Source = imagen;

        var audioManager = AudioManager.Current;
        if (sonidoValido)
        {
            player = audioManager.CreatePlayer("valid.wav");
        }
        else
        {
            player = audioManager.CreatePlayer("invalid.wav");
        }
        player?.Play();
    }

    private async void OnCerrarClicked(object sender, EventArgs e)
    {
        player?.Stop();
        await Navigation.PopModalAsync(); // cerrar el popup
    }
}