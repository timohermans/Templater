namespace Templater.App.Scenarios;

public interface IMainEntryScenario : IScenario
{
}

public class MainEntryScenario(
    IAnsiConsole console,
    IScenarioManager scenarioManager,
    IArchitectureManageScenario archManageScenario) : IMainEntryScenario
{
    public async Task ExecuteAsync()
    {
        var mainChoices = Enum.GetValues<MainActions>()
            .Select(e => new Choice<MainActions>(e))
            .ToArray();

        var action = await console.PromptAsync(
            new SelectionPrompt<Choice<MainActions>>()
                .Title("[underline red]What[/] would you like to do?")
                .PageSize(10)
                .AddChoices(mainChoices)
        );

        switch (action.Value)
        {
            case MainActions.ManageArchitectures:
                await scenarioManager.GoToAsync(archManageScenario);
                break;
            default:
                await scenarioManager.GoBackAsync();
                break;
        }
    }
}