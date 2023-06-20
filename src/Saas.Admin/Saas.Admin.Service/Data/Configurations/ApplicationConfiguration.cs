using Saas.Admin.Service.Data.Entities;
using Saas.Shared.Constants;

namespace Saas.Admin.Service.Data.Configuration;

public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(50)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(t => t.Url)
            .HasMaxLength(1024)
            .IsUnicode(false)
            .IsRequired();

        builder.HasMany(t => t.Subscriptions)
            .WithOne()
            .IsRequired();

        Seed(builder);
    }

    private static void Seed(EntityTypeBuilder<Application> builder)
    {
        builder.HasData(new List<Application>
        {
            new Application()
            {
                Id = ApplicationContants.FinancialServicesApplicationId,
                Name = "Financial services",
                Url = "financial.topal.ch",
            },
            new Application()
            {
                Id = ApplicationContants.PayrollServicesApplicationId,
                Name = "Payroll services",
                Url = "payroll.topal.ch",
            },
        });
    }
}
