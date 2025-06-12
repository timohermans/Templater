using Templater.App.Scenarios;

namespace Templater.App;

public static class ScenarioManager
{
    private static readonly List<KeyValuePair<IScenario, object>> _scenarios = [];
    public static IReadOnlyList<KeyValuePair<IScenario, object>> Scenarios => _scenarios.AsReadOnly();

    public static void GoTo(IScenario scenario) => GoTo(scenario, null);
    public static void GoTo<TArgs>(BaseScenario<TArgs> scenario, TArgs? args) => GoTo(scenario as IScenario, args);
    
    private static void GoTo(IScenario scenario, object? args)
    {
        var scenarioArgs = args ?? new Unit();
        _scenarios.Add(new KeyValuePair<IScenario, object>(scenario, scenarioArgs));
        scenario.Execute(scenarioArgs);
    }
}