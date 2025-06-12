using System.ComponentModel.DataAnnotations;

namespace Templater.App.Scenarios;

public class ArchitectureManageScenario : BaseScenario<Unit>
{
    public override void Execute(Unit _)
    {
        var createIndex = 0;
        List<string> choices =
        [
            "Create a [underline]new[/] architecture",
            "Budget Api Clean Architecture"
        ];

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Architecture Management")
                .AddChoices(choices)
        );

        if (choices.IndexOf(choice) == createIndex)
        {
            // go to create architecture
        }
        
    }
}