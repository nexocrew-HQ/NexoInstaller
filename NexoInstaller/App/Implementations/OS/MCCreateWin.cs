using McCreate.App.Helper;
using McCreate.App.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace McCreate.App.Implementations.OS;

public class MCCreateWin : IOSAction
{
    public string Name { get; set; } = "Windows Installer";
    public string SoftwareID { get; set; } = "mccreate";

    public async Task Execute(IServiceProvider serviceProvider)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("[bold red]The Windows Version is only downloadable with our mccreate.exe [/]");
        AnsiConsole.MarkupLine("[dim][white]Move to [link]https://nexocrew.link/s/winmccreateinstall[/][/][/]");
        Console.ReadKey();
    }
}