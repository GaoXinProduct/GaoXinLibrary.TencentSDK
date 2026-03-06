using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序发货信息管理服务实现</summary>
public class MiniProgramShippingService : IMiniProgramShippingService
{
    private readonly WechatHttpClient _http;

    public MiniProgramShippingService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <inheritdoc/>
    public Task<UploadShippingInfoResponse> UploadShippingInfoAsync(UploadShippingInfoRequest request, CancellationToken ct = default)
        => _http.PostAsync<UploadShippingInfoResponse>("/wxa/sec/order/upload_shipping_info", request, ct);

    /// <inheritdoc/>
    public Task<UploadCombinedShippingInfoResponse> UploadCombinedShippingInfoAsync(UploadCombinedShippingInfoRequest request, CancellationToken ct = default)
        => _http.PostAsync<UploadCombinedShippingInfoResponse>("/wxa/sec/order/upload_combined_shipping_info", request, ct);

    /// <inheritdoc/>
    public Task<GetOrderResponse> GetOrderAsync(GetOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetOrderResponse>("/wxa/sec/order/get_order", request, ct);

    /// <inheritdoc/>
    public Task<IsTradeManagedResponse> IsTradeManagedAsync(IsTradeManagedRequest request, CancellationToken ct = default)
        => _http.PostAsync<IsTradeManagedResponse>("/wxa/sec/order/is_trade_managed", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  小程序 OCR / 图像处理服务

