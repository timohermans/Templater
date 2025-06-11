namespace Templater.App.Scenarios;

public static class MainEntryScenario
{
    public static void Execute()
    {
        Choice<MainActions>[] mainChoices = Enum.GetValues<MainActions>()
            .Select(e => new Choice<MainActions>(e))
            .ToArray();

        var action = AnsiConsole.Prompt(
            new SelectionPrompt<Choice<MainActions>>()
                .Title("[underline red]What[/] would you like to do?")
                .PageSize(10)
                .AddChoices(mainChoices) 
        );
    
        action.Value switch
        {
            // TODO: fix
        } 
    }
}