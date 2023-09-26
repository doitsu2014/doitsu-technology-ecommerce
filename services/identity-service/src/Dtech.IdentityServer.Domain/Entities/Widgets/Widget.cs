namespace Dtech.IdentityServer.Domain.Entities.Widgets;

public class Widget
{
    public Guid Id { get; set; }

    public enum TypeEnum
    {
        Slider = 0,
    }
}