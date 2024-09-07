using McCreate.App.Helper;
using McCreate.App.Interfaces;
using McCreate.App.Services;
using Spectre.Console;

namespace McCreate.App;

public class EntryPoint : IEntryPoint
{
    private ImplementationService ImplementationService;
    private IServiceProvider ServiceProvider;

    public EntryPoint(ImplementationService implementationService, IServiceProvider serviceProvider)
    {
        ImplementationService = implementationService;
        ServiceProvider = serviceProvider;
    }

    public void Run()
    {
        var actionsList = ImplementationService.GetImplementations<IProgramAction>();

        if (actionsList.Length < 1)
            throw new Exception(
                "There are no registered Implementations for IProgramAction, please register one in Program.cs");
        
        
        var selection = new SelectionPrompt<IProgramAction>();

        selection
            .Title("What would you like to do?")
            .PageSize(5)
            .MoreChoicesText("[grey](Move up and down to reveal more actions)[/]")
            .AddChoices(actionsList).HighlightStyle(new Style().Foreground(Color.DodgerBlue2))
            .Converter = x => $"[white bold]{x.Name}[/]";

        var action = AnsiConsole.Prompt(selection);

        AnsiHelper.ConfirmSelection("Selected action", action.Name);
        
        action.Execute(ServiceProvider).GetAwaiter().GetResult();
    }  
}