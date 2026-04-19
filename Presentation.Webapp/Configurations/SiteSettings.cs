namespace Presentation.Webapp.Configurations;

public sealed class SiteSettings
{
    public required string SiteName { get; init; }
    public required string Slogan { get; init; }
    public required string Description { get; init; }
    public required string Language { get; init; }
    public required string Copyright { get; init; }
}
