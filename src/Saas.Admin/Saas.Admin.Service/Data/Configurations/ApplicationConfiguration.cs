using Saas.Admin.Service.Data.Entities;

namespace Saas.Admin.Service.Data.Configuration;

public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name).IsRequired();

        Seed(builder);
    }

    private static void Seed(EntityTypeBuilder<Application> builder)
    {
        builder.HasData(new List<Application>
        {
            new Application()
            {
                Id = 1,
                Name = "Financial services",
            },
            new Application()
            {
                Id = 2,
                Name = "Pyroll services",
            },
        });
    }
}
