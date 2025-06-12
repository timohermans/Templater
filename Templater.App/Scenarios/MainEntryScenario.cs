namespace Templater.App.Scenarios;

public class MainEntryScenario : BaseScenario<Unit>
{
    public override void Execute(Unit _)
    {
        var mainChoices = Enum.GetValues<MainActions>()
            .Select(e => new Choice<MainActions>(e))
            .ToArray();

        var action = AnsiConsole.Prompt(
            new SelectionPrompt<Choice<MainActions>>()
                .Title("[underline red]What[/] would you like to do?")
                .PageSize(10)
                .AddChoices(mainChoices) 
        );

        IScenario? toExecute = action.Value switch
        {
            MainActions.ManageArchitectures => new ArchitectureManageScenario(),
            MainActions.GenerateTemplates => new ArchitectureManageScenario(),
            MainActions.ManageTemplates => new ArchitectureManageScenario(),
            _ => null
        };

        if (toExecute != null)
        {
            ScenarioManager.GoTo(toExecute);
        }
    }
}