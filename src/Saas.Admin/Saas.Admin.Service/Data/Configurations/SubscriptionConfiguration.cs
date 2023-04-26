using Saas.Admin.Service.Data.Entities;

namespace Saas.Admin.Service.Data.Configuration;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name).IsRequired();

        builder.HasMany(e => e.Features)
            .WithMany()
            .UsingEntity("SubscriptionFeatures")
            .HasData(GetSubscriptionFeatures());

        Seed(builder);
    }

    private object[] GetSubscriptionFeatures()
    {
        return new object[]
        {
            new { SubscriptionsId = 3, FeaturesId = 1 },
            new { SubscriptionsId = 4, FeaturesId = 1 },
            new { SubscriptionsId = 4, FeaturesId = 2 },
        };
    }

    private static void Seed(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasData(new List<Subscription>
        {
            new Subscription()
            {
                Id = 1,
                Name = "Trial",
                MaxUserNumber = 10,
                Price = 0,
            },
            new Subscription()
            {
                Id = 2,
                Name = "Basic",
                MaxUserNumber = 10,
                Price = 100,
            },
            new Subscription()
            {
                Id = 3,
                Name = "Standard",
                MaxUserNumber = 100,
                Price = 1000,
            },
            new Subscription()
            {
                Id = 4,
                Name = "Premium",
                MaxUserNumber = 10000,
                Price = 10000,
            }
        });
    }
}
