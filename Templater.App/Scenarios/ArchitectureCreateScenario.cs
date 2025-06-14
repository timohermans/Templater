using Microsoft.EntityFrameworkCore;
using Spectre.Console.Cli;
using Templater.App.Data;
using Templater.App.Data.Types;

namespace Templater.App.Scenarios;

public interface IArchitectureCreateScenario : IScenario
{
}

public class ArchitectureCreateScenario(IAnsiConsole console, DataContext db, IScenarioManager scenarioManager)
    : IArchitectureCreateScenario
{
    public async Task ExecuteAsync()
    {
        var textPrompt = new TextPrompt<string>("Architecture [yellow underline]name[/]")
        {
            Validator = s =>
            {
                var doesNameExist = db.Architectures.Any(a => a.Name == s);
                if (doesNameExist)
                {
                    return ValidationResult.Error("Architecture already exists");
                }

                return ValidationResult.Success();
            }
        };

        var name = await console.PromptAsync(textPrompt);

        var architecture = new Architecture
        {
            Name = name,
        };
        await db.Architectures.AddAsync(architecture);
        await db.SaveChangesAsync();

        await scenarioManager.GoBackAsync();
    }
}