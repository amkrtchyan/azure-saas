
namespace Saas.Shared.Options;

public record PayrollApiOptions
{
    public const string SectionName = "PayrollApi";

    public string? BaseUrl { get; init; }
}
