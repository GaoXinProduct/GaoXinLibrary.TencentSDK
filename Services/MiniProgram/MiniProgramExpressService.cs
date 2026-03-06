using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序物流助手服务实现</summary>
public class MiniProgramExpressService : IMiniProgramExpressService
{
    private readonly WechatHttpClient _http;
    public MiniProgramExpressService(WechatHttpClient http) => _http = http;

    /// <inheritdoc/>
    public Task<GetAllDeliveryResponse> GetAllDeliveryAsync(CancellationToken ct = default)
        => _http.GetAsync<GetAllDeliveryResponse>("/cgi-bin/express/business/delivery/getall", ct: ct);
    /// <inheritdoc/>
    public Task<GetExpressOrderResponse> GetOrderAsync(GetExpressOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetExpressOrderResponse>("/cgi-bin/express/business/order/get", request, ct);
    /// <inheritdoc/>
    public Task<GetExpressPathResponse> GetPathAsync(GetExpressPathRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetExpressPathResponse>("/cgi-bin/express/business/path/get", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  小程序运维中心服务

