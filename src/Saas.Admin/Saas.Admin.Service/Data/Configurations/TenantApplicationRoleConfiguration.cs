using Saas.Admin.Service.Data.Entities;

namespace Saas.Admin.Service.Data.Configuration;

public class TenantApplicationRoleConfiguration : IEntityTypeConfiguration<TenantApplicationRole>
{
    public void Configure(EntityTypeBuilder<TenantApplicationRole> builder)
    {
        builder.ToTable(nameof(TenantApplicationRole) + "s");

        builder.HasAlternateKey(e => new { e.TenantId, e.ApplicationId, e.Role });

        builder.Property(t => t.Role)
            .HasMaxLength(50)
            .IsUnicode(false)
            .IsRequired();
    }
}
