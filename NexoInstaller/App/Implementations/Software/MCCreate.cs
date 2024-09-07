using McCreate.App.Helper;
using McCreate.App.Interfaces;
using McCreate.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace McCreate.App.Implementations.Software;

public class MCCreate : IProgramAction
{
    public string Name { get; set; } = "MCCreate";

    public string ID { get; set; } = "mccreate";

    public async Task Execute(IServiceProvider serviceProvider)
    {
        var implementationService = serviceProvider.GetRequiredService<ImplementationService>();

        var actionsList = implementationService.GetImplementations<IOSAction>().Where(x => x.SoftwareID == ID);

        if (!actionsList.Any())
            throw new Exception(
                "There are no registered Implementations for IProgramAction, please register one in Program.cs");


        var selection = new SelectionPrompt<IOSAction>();

        selection
            .Title("What would you like to do?")
            .PageSize(5)
            .MoreChoicesText("[grey](Move up and down to reveal more actions)[/]")
            .AddChoices(actionsList).HighlightStyle(new Style().Foreground(Color.DodgerBlue2))
            .Converter = x => $"[white bold]{x.Name}[/]";

        var action = AnsiConsole.Prompt(selection);

        AnsiHelper.ConfirmSelection("Selected action", action.Name);

        action.Execute(serviceProvider).GetAwaiter().GetResult();
    }
}