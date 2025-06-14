using Templater.App.Scenarios;

namespace Templater.App;

public interface IScenarioManager
{
    Task GoToAsync(IScenario scenario);
    Task GoBackAsync();
}

public class ScenarioManager() : IScenarioManager
{
    private readonly List<IScenario> _scenarios = [];

    public async Task GoToAsync(IScenario scenario)
    {
        _scenarios.Add(scenario);
        await scenario.ExecuteAsync();
    }

    public async Task GoBackAsync()
    {
        if (_scenarios.Count <= 1) return;

        _scenarios.RemoveAt(_scenarios.Count - 1);
        var scenario = _scenarios.Last();
        await scenario.ExecuteAsync();
    }
}