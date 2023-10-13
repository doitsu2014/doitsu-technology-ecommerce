using DTech.Cms.Abstractions;
using OrchardCore.DisplayManagement.Manifest;

[assembly: Theme(
    Id = "DTech.Cms.SiteTheme",
    Name = "DTech Cms Theme for Website",
    Author = ManifestConstants.ManifestAuthor,
    Website = ManifestConstants.ManifestWebsite,
    Version = ManifestConstants.ManifestVersion,
    Description = "Doitsu Technology Theme",
    Category = ManifestConstants.ManifestCategory,
    BaseTheme = "TheTheme",
    Tags = new[] {"Blog", "Bootstrap", "Razor"}
)]