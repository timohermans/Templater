namespace Templater.App.Scenarios;

public class Unit
{
}

public interface IScenario
{
    void Execute(object args);
}

public abstract class BaseScenario<TArgs> : IScenario
{
    public abstract void Execute(TArgs args);
    
    public void Execute(object args)
    {
        if (args is not TArgs argsTyped)
        {
            throw new ArgumentException($"Invalid argument type. Expected {typeof(TArgs).Name}, but got {args.GetType().Name}.");
        }
        
        Execute(argsTyped);
    }
}