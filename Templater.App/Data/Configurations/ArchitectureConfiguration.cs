using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Templater.App.Data.Types;

namespace Templater.App.Data.Configurations;

public class ArchitectureConfiguration : IEntityTypeConfiguration<Architecture>
{
    public void Configure(EntityTypeBuilder<Architecture> builder)
    {
        builder.HasIndex(a => new { a.Name }).IsUnique();
    }
}