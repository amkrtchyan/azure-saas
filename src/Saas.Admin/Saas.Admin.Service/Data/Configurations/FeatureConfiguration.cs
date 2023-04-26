using Saas.Admin.Service.Data.Entities;

namespace Saas.Admin.Service.Data.Configuration;

public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.HasKey(t => t.Id);
        builder.ToTable(nameof(Feature) + "s");

        builder.Property(t => t.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(50);

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
