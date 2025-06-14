namespace Templater.App.Scenarios;

public interface IScenario
{
    Task ExecuteAsync();
}

public interface IScenario<in TArgs> : IScenario
{
    TArgs Args { set; }
}