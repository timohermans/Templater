using Microsoft.EntityFrameworkCore;
using Templater.App.Data;

namespace Templater.App.Scenarios;

public interface IArchitectureDetailsScenario : IScenario<ArchitectureDetailsDto>
{
}

public record ArchitectureDetailsDto(int Id);

public class ArchitectureDetailsScenario(IScenarioManager scenarioManager, DataContext db, IAnsiConsole console)
    : IArchitectureDetailsScenario
{
    public ArchitectureDetailsDto Args { get; set; }

    public async Task ExecuteAsync()
    {
        var architecture = await db.Architectures.FindAsync(Args.Id);
        if (architecture == null)
        {
            console.WriteLine("Architecture not found..? Going back?");
            await scenarioManager.GoBackAsync();
        }
    }
}