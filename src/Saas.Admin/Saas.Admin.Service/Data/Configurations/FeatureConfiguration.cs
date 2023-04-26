using Saas.Admin.Service.Data.Entities;

namespace Saas.Admin.Service.Data.Configuration;

public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name).IsRequired();

        Seed(builder);
    }

    private static void Seed(EntityTypeBuilder<Feature> builder)
    {
        builder.HasData(new List<Feature>
        {
            new Feature()
            {
                Id = 1,
                Name = "Technical support",
            },
            new Feature()
            {
                Id = 2,
                Name = "Custom deployment",
            },
        });
    }
}
