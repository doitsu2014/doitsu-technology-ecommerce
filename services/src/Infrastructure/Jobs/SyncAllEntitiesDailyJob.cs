﻿using HatDieu.Domain.Interfaces.BizServices;

namespace HatDieu.Infrastructure.Jobs;

public class SyncAllEntitiesDailyJob
{
    private readonly IPayrixEntityBizService _payrixEntityBizService;

    public SyncAllEntitiesDailyJob(IPayrixEntityBizService payrixEntityBizService)
    {
        _payrixEntityBizService = payrixEntityBizService;
    }

    public async Task ExecuteAsync(CancellationToken ct = default)
    {
        await _payrixEntityBizService.SyncAllAsync(ct);
    }
}