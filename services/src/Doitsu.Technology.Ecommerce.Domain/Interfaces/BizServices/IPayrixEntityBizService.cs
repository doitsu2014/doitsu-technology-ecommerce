namespace Doitsu.Technology.Ecommerce.Domain.Interfaces.BizServices;

public interface IPayrixEntityBizService
{
    Task SyncAllAsync(CancellationToken ct = default);
}