using Doitsu.Technology.Ecommerce.Domain.Interfaces.BizServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/data-warehouse")]
[ApiController]
public class DataWarehouseController : ControllerBase
{
    private readonly IPayrixEntityBizService _payrixEntityBizService;

    public DataWarehouseController(IPayrixEntityBizService payrixEntityBizService)
    {
        _payrixEntityBizService = payrixEntityBizService;
    }

    [HttpPost("payrix-entities/sync-all-requests")]
    public async Task<IActionResult> CreateSyncAllRequestsAsync(CancellationToken ct = default)
    {
        await _payrixEntityBizService.SyncAllAsync(ct);
        return Ok();
    }
}