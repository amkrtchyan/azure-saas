using Saas.Admin.Service.Data.Entities;

namespace Saas.Admin.Service.Data.Configuration;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasIndex(t => t.Route).IsUnique(true);

        builder.Property(t => t.Name).IsRequired();
        builder.Property(t => t.Route).IsRequired();
        builder.Property(t => t.CreatorEmail).IsRequired();

        builder.Property(t => t.CreatedTime)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(t => t.ConcurrencyToken)
            .IsConcurrencyToken();
    }
}
