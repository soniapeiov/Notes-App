using System.Collections.ObjectModel;
namespace Notas.Models;

internal class TodasNotas
{
    public ObservableCollection<Nota> Notas { get; set; } = new ObservableCollection<Nota>();

    public TodasNotas() => CarregaNotas();

    public void CarregaNotas()
    {
        Notas.Clear();

        // Get all .notas.txt files in the app data directory.
        string appDataPath = FileSystem.AppDataDirectory;

        IEnumerable<Nota> notas = Directory.EnumerateFiles(appDataPath, "*.notas.txt")  // Get all .notas.txt files
            .Select(filename => new Nota()  // Create a Nota object for each file
            {
                Filename = filename,    // Store the filename
                Text = File.ReadAllText(filename),  // Read the file content
                Date = File.GetCreationTime(filename)  // Get the file creation date
            }).OrderBy(nota => nota.Date);  // Order the notes by date

        // Add the notes to the ObservableCollection
        foreach (Nota nota in notas)
            Notas.Add(nota);
    }
}