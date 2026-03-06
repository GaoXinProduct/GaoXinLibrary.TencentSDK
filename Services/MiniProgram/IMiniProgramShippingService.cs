using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 小程序发货信息管理服务接口
/// <para>
/// 商户在小程序内调起微信支付后，需要在发货后上传发货信息。
/// </para>
/// </summary>
public interface IMiniProgramShippingService
{
    /// <summary>
    /// 发货信息录入（upload_shipping_info）
    /// <para>录入发货信息，将发货状态同步到微信侧。</para>
    /// </summary>
    /// <param name="request">发货信息</param>
    /// <param name="ct">取消令牌</param>
    Task<UploadShippingInfoResponse> UploadShippingInfoAsync(UploadShippingInfoRequest request, CancellationToken ct = default);

    /// <summary>
    /// 发货信息合单录入（upload_combined_shipping_info）
    /// <para>合单支付场景下录入发货信息。</para>
    /// </summary>
    /// <param name="request">合单发货信息</param>
    /// <param name="ct">取消令牌</param>
    Task<UploadCombinedShippingInfoResponse> UploadCombinedShippingInfoAsync(UploadCombinedShippingInfoRequest request, CancellationToken ct = default);

    /// <summary>
    /// 查询订单发货状态（get_order）
    /// </summary>
    /// <param name="request">查询请求</param>
    /// <param name="ct">取消令牌</param>
    Task<GetOrderResponse> GetOrderAsync(GetOrderRequest request, CancellationToken ct = default);

    /// <summary>
    /// 查询小程序是否已完成交易结算管理确认（is_trade_managed）
    /// </summary>
    /// <param name="request">查询请求</param>
    /// <param name="ct">取消令牌</param>
    Task<IsTradeManagedResponse> IsTradeManagedAsync(IsTradeManagedRequest request, CancellationToken ct = default);
}

