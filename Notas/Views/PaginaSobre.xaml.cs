namespace Notas.Views;

public partial class PaginaSobre : ContentPage
{
    public PaginaSobre()
    {
        InitializeComponent();
    }
    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Sobre sobre)
        {
            // Open the URL in the default browser.
            await Launcher.Default.OpenAsync(sobre.MoreInfoUrl);
        }

    }
}