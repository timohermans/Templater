using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Templater.App;
using Templater.App.Data;
using Templater.App.Scenarios;

AnsiConsole.Markup("[underline red]Hello[/] World!");

var services = new ServiceCollection();

services.AddDbContext<DataContext>(options =>
    options.UseSqlite(DataContext.ConnectionString));

services.AddSingleton(AnsiConsole.Console);
services.Scan(scan =>
    scan.FromEntryAssembly()
        .AddClasses(classes => classes.AssignableTo<IScenario>())
        .AsImplementedInterfaces()
        .WithTransientLifetime()
        .AddClasses(classes => classes.AssignableTo<IScenarioManager>())
        .AsImplementedInterfaces()
        .WithSingletonLifetime()
);

var serviceProvider = services.BuildServiceProvider();

var scenarioManager = serviceProvider.GetRequiredService<IScenarioManager>();
var mainEntryScenario = serviceProvider.GetRequiredService<IMainEntryScenario>();

await using var db = serviceProvider.GetRequiredService<DataContext>();
await db.Database.MigrateAsync();

await scenarioManager.GoToAsync(mainEntryScenario);