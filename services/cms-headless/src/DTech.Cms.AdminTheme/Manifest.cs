using DTech.Cms.Abstractions;
using OrchardCore.DisplayManagement.Manifest;

[assembly: Theme(
    Name = "DTech Cms AdminTheme",
    Description = "DTech.Cms.AdminTheme",
    Author = ManifestConstants.ManifestAuthor,
    Website = ManifestConstants.ManifestWebsite,
    Version = ManifestConstants.ManifestVersion,
    Tags = new[] {"admin"},
    BaseTheme = "TheAdmin"
)]