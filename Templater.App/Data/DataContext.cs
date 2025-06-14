using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Templater.App.Data.Types;

namespace Templater.App.Data;

/// <summary>
/// This will only be used during migrations and other CLI stuff
/// </summary>
public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlite(DataContext.ConnectionString);

        return new DataContext(optionsBuilder.Options);
    }
}

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public const string ConnectionString = "Data Source=templater.db";
    
    public DbSet<Architecture> Architectures { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Template> Templates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}