using OrchardCore.Modules.Manifest;

[assembly: Module(
    Id = "OrchardCore.Dtech.Cms",
    Name = "Dtech Cms Module",
    Author = "Doitsu Technology",
    Website = "https://doitsu.tech",
    Version = "0.0.1",
    Description = "Provides recipes.",
    Category = "Recipes",
    Dependencies = new[]
    {
        "OrchardCore.Recipes"
    })
]