using Saas.Admin.Service.Data.Entities;

namespace Saas.Admin.Service.Data.Configuration;

public class TenantSubscriptionConfiguration : IEntityTypeConfiguration<TenantSubscription>
{
    public void Configure(EntityTypeBuilder<TenantSubscription> builder)
    {
        builder.ToTable(nameof(TenantSubscription) + "s");
    }
}
