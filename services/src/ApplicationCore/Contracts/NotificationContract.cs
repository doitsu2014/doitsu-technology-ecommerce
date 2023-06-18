namespace HatDieu.ApplicationCore.Contracts;

public abstract record NotificationContract
{
    public abstract string Type      { get; }
    public          Guid   RequestId { get; set; }
}

public record NotificationContract<TData> : NotificationContract
    where TData : class
{
    public NotificationContract()
    {
        this.Data = null;
        this.Type = typeof(TData).Name;
    }

    public NotificationContract(TData data)
        : base()
    {
        this.Data = data;
    }

    public override string Type { get; }
    public          TData? Data { get; set; }
}