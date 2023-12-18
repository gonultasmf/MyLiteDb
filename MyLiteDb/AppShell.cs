namespace MyLiteDb;

public partial class AppShell : Shell
{
    public AppShell(MainPage mainPage)
    {
        Items.Add(mainPage);
    }
}
