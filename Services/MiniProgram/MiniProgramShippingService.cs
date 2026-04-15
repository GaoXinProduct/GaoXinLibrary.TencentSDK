using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序发货信息管理服务实现</summary>
public class MiniProgramShippingService
{
    private readonly WechatHttpClient _http;

    public MiniProgramShippingService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <summary>
    /// 发货信息录入（upload_shipping_info）
    /// <para>录入发货信息，将发货状态同步到微信侧。</para>
    /// </summary>
    /// <param name="request">发货信息</param>
    /// <param name="ct">取消令牌</param>
    public Task<UploadShippingInfoResponse> UploadShippingInfoAsync(UploadShippingInfoRequest request, CancellationToken ct = default)
        => _http.PostAsync<UploadShippingInfoResponse>("/wxa/sec/order/upload_shipping_info", request, ct);

    /// <summary>
    /// 发货信息合单录入（upload_combined_shipping_info）
    /// <para>合单支付场景下录入发货信息。</para>
    /// </summary>
    /// <param name="request">合单发货信息</param>
    /// <param name="ct">取消令牌</param>
    public Task<UploadCombinedShippingInfoResponse> UploadCombinedShippingInfoAsync(UploadCombinedShippingInfoRequest request, CancellationToken ct = default)
        => _http.PostAsync<UploadCombinedShippingInfoResponse>("/wxa/sec/order/upload_combined_shipping_info", request, ct);

    /// <summary>
    /// 查询订单发货状态（get_order）
    /// </summary>
    /// <param name="request">查询请求</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetOrderResponse> GetOrderAsync(GetOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetOrderResponse>("/wxa/sec/order/get_order", request, ct);

    /// <summary>
    /// 查询小程序是否已完成交易结算管理确认（is_trade_managed）
    /// </summary>
    /// <param name="request">查询请求</param>
    /// <param name="ct">取消令牌</param>
    public Task<IsTradeManagedResponse> IsTradeManagedAsync(IsTradeManagedRequest request, CancellationToken ct = default)
        => _http.PostAsync<IsTradeManagedResponse>("/wxa/sec/order/is_trade_managed", request, ct);
}
