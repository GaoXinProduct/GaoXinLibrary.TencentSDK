using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// 小程序交易管理服务实现
/// <para>
/// 提供发货信息管理、交易保障等相关接口。
/// </para>
/// </summary>
public sealed class MiniProgramTradeService
{
    private readonly WechatHttpClient _http;

    /// <summary>
    /// 初始化交易管理服务
    /// </summary>
    /// <param name="http">微信HTTP客户端</param>
    public MiniProgramTradeService(WechatHttpClient http) => _http = http;

    /// <summary>
    /// 确认收货提醒（POST /wxa/sec/order/notify_confirm_receive）
    /// <para>发货后提醒用户确认收货。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<NotifyConfirmReceiveResponse> NotifyConfirmReceiveAsync(NotifyConfirmReceiveRequest request, CancellationToken ct = default)
        => _http.PostAsync<NotifyConfirmReceiveResponse>("/wxa/sec/order/notify_confirm_receive", request, ct);

    /// <summary>
    /// 消息跳转路径设置（POST /wxa/sec/order/set_msg_jump_path）
    /// <para>设置小程序交易相关的消息跳转路径。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<SetMsgJumpPathResponse> SetMsgJumpPathAsync(SetMsgJumpPathRequest request, CancellationToken ct = default)
        => _http.PostAsync<SetMsgJumpPathResponse>("/wxa/sec/order/set_msg_jump_path", request, ct);

    /// <summary>
    /// 查询小程序是否已完成交易结算管理确认（POST /wxa/sec/order/is_trade_management_confirmation_completed）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<IsTradeManagementConfirmationCompletedResponse> IsTradeManagementConfirmationCompletedAsync(IsTradeManagementConfirmationCompletedRequest request, CancellationToken ct = default)
        => _http.PostAsync<IsTradeManagementConfirmationCompletedResponse>("/wxa/sec/order/is_trade_management_confirmation_completed", request, ct);

    /// <summary>
    /// 特殊发货报备（POST /wxa/sec/order/op_special_order）
    /// <para>用于商家向微信报备特殊发货情况。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<OpSpecialOrderResponse> OpSpecialOrderAsync(OpSpecialOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<OpSpecialOrderResponse>("/wxa/sec/order/op_special_order", request, ct);

    /// <summary>
    /// 品牌申请（POST /wxa/sec/order/famous_brand/apply）
    /// <para>商家申请品牌认证。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<FamousBrandApplyResponse> FamousBrandApplyAsync(FamousBrandApplyRequest request, CancellationToken ct = default)
        => _http.PostAsync<FamousBrandApplyResponse>("/wxa/sec/order/famous_brand/apply", request, ct);

    /// <summary>
    /// 小程序品牌申请状态查询（POST /wxa/sec/order/famous_brand/get_apply_status）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetFamousBrandApplyStatusResponse> GetFamousBrandApplyStatusAsync(GetFamousBrandApplyStatusRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetFamousBrandApplyStatusResponse>("/wxa/sec/order/famous_brand/get_apply_status", request, ct);

    /// <summary>
    /// 小程序交易类型变更申请（POST /wxa/sec/order/set_trade_type）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<SetWxATradeTypeResponse> SetWxATradeTypeAsync(SetWxATradeTypeRequest request, CancellationToken ct = default)
        => _http.PostAsync<SetWxATradeTypeResponse>("/wxa/sec/order/set_trade_type", request, ct);
}