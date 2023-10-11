using DTech.Cms.Abstractions;
using OrchardCore.DisplayManagement.Manifest;

[assembly: Theme(
    Name = "DTech.Cms.AdminTheme",
    Author = ManifestConstants.ManifestAuthor,
    Website = ManifestConstants.ManifestWebsite,
    Version = ManifestConstants.ManifestVersion,
    Description = "DTech.Cms.AdminTheme",
    Tags = new[] {"admin"},
    BaseTheme = "TheAdmin"
)]