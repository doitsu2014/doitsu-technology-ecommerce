namespace HatDieu.Domain.Interfaces.BizServices;

public interface IPayrixEntityBizService
{
    Task SyncAllAsync(CancellationToken ct = default);
}