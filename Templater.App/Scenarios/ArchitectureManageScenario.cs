using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Spectre.Console.Cli;
using Templater.App.Data;

namespace Templater.App.Scenarios;

public interface IArchitectureManageScenario : IScenario
{
}

public class ArchitectureManageScenario(
    IAnsiConsole console,
    IScenarioManager scenarioManager,
    IArchitectureCreateScenario createScenario,
    IArchitectureDetailsScenario detailsScenario,
    DataContext db)
    : IArchitectureManageScenario
{
    public async Task ExecuteAsync()
    {
        var cancel = "Cancel";
        var createIndex = 0;
        var architectures = await db.Architectures.ToListAsync();
        List<string> choices =
        [
            "Create a [underline]new[/] architecture",
            ..architectures.Select(a => a.Name).ToList(),
            cancel
        ];

        var choice = await console.PromptAsync(
            new SelectionPrompt<string>()
                .Title("Architecture Management")
                .AddChoices(choices)
        );
        
        var architecture = architectures.FirstOrDefault(a => a.Name == choice);
        if (architecture != null)
        {
            detailsScenario.Args = new ArchitectureDetailsDto(architecture.Id);
            await scenarioManager.GoToAsync(detailsScenario);
        } 
        else if (choices.IndexOf(choice) == createIndex)
        {
            await scenarioManager.GoToAsync(createScenario);
        } 
        else if (choice == cancel)
        {
            await scenarioManager.GoBackAsync();
        }
        else
        {
            throw new InvalidOperationException("Something went wrong selecting the architecture");
        }
    }
}