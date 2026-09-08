namespace Notas.Models;

internal class Sobre
{
    public string Title => AppInfo.Name;
    public string Version => AppInfo.VersionString;
    public string MoreInfoUrl => "https://islagaia.pt/";
    public string Message => "Esta aplicação foi desenvolvida em .NET MAUI.";
}
