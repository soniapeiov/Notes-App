namespace Notas.Views;

public partial class PaginaTodasNotas : ContentPage
{
    public PaginaTodasNotas()
    {
        InitializeComponent();
        BindingContext = new Models.TodasNotas();
    }
    protected override void OnAppearing()
    {
        ((Models.TodasNotas)BindingContext).CarregaNotas();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PaginaNotas));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // obtain the selected note
            var note = (Models.Nota)e.CurrentSelection[0];
            // navigate to the note page, passing the filename as a parameter
            await Shell.Current.GoToAsync($"{nameof(PaginaNotas)}?{nameof(PaginaNotas.ItemId)}={note.Filename}");
            // deselect the item
            notesCollection.SelectedItem = null;

        }
    }
}