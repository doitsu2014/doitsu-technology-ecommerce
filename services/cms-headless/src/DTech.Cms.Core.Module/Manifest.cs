using OrchardCore.Modules.Manifest;
using ManifestConstants = DTech.Cms.Abstractions.ManifestConstants;

[assembly: Module(
    Name = "DTech Cms Core Module",
    Author = ManifestConstants.ManifestAuthor,
    Website = ManifestConstants.ManifestWebsite,
    Version = ManifestConstants.ManifestVersion,
    Description = "DTech.Cms.Core.Module",
    Category = ManifestConstants.ManifestCategory
)]