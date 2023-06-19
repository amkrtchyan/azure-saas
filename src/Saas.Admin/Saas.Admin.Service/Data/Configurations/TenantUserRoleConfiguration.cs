using Saas.Admin.Service.Data.Entities;

namespace Saas.Admin.Service.Data.Configuration;

public class TenantUserRoleConfiguration : IEntityTypeConfiguration<TenantUserRole>
{
    public void Configure(EntityTypeBuilder<TenantUserRole> builder)
    {
        builder.ToTable(nameof(TenantUserRole) + "s");

        builder.HasKey(e => new { e.TenantId, e.UserId, e.ApplicationRoleId });

        builder.HasOne<Tenant>()
            .WithMany()
            .HasForeignKey(e => e.TenantId);

        builder.HasOne<TenantApplicationRole>()
            .WithMany()
            .HasForeignKey(e => new { e.ApplicationRoleId, e.TenantId })
            .HasPrincipalKey(e => new { e.Id, e.TenantId });
    }
}
