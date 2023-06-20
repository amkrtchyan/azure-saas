using Saas.Admin.Service.Data.Entities;
using Saas.Shared.Constants;

namespace Saas.Admin.Service.Data.Configuration;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(t => t.Id);
        builder.ToTable(nameof(Subscription) + "s");

        builder.Property(t => t.Name)
            .HasMaxLength(50)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(t => t.MonthlyPayment)
            .HasPrecision(10, 2);

        builder.HasMany(e => e.Features)
            .WithMany(e => e.Subscriptions)
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
        builder.HasData(
            new
            {
                Id = 1,
                Name = "Trial",
                MaxUserNumber = 10,
                MonthlyPayment = 0m,
                ApplicationId = ApplicationContants.FinancialServicesApplicationId,
            },
            new
            {
                Id = 2,
                Name = "Basic",
                MaxUserNumber = 10,
                MonthlyPayment = 100m,
                ApplicationId = ApplicationContants.FinancialServicesApplicationId,
            },
            new
            {
                Id = 3,
                Name = "Standard",
                MaxUserNumber = 100,
                MonthlyPayment = 1000m,
                ApplicationId = ApplicationContants.FinancialServicesApplicationId,
            },
            new
            {
                Id = 4,
                Name = "Premium",
                MaxUserNumber = 10000,
                MonthlyPayment = 10000m,
                ApplicationId = ApplicationContants.FinancialServicesApplicationId,
            },
            new
            {
                Id = 5,
                Name = "Trial",
                MaxUserNumber = 10,
                MonthlyPayment = 0m,
                ApplicationId = ApplicationContants.PayrollServicesApplicationId,
            },
            new
            {
                Id = 6,
                Name = "Standard",
                MaxUserNumber = 100,
                MonthlyPayment = 1000m,
                ApplicationId = ApplicationContants.PayrollServicesApplicationId,
            }
        );
    }
}
