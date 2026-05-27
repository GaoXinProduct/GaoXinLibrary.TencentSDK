using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// 小程序动态消息服务实现
/// <para>
/// 提供activity_id创建、动态消息更新等服务。
/// </para>
/// </summary>
public sealed class MiniProgramDynamicMessageService
{
    private readonly WechatHttpClient _http;

    /// <summary>
    /// 初始化动态消息服务
    /// </summary>
    /// <param name="http">微信HTTP客户端</param>
    public MiniProgramDynamicMessageService(WechatHttpClient http) => _http = http;

    /// <summary>
    /// 创建activity_id（POST /cgi-bin/message/wxopen/activityid/create）
    /// <para>创建一次性的订阅消息activity_id。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<CreateActivityIdResponse> CreateActivityIdAsync(CreateActivityIdRequest request, CancellationToken ct = default)
        => _http.PostAsync<CreateActivityIdResponse>("/cgi-bin/message/wxopen/activityid/create", request, ct);

    /// <summary>
    /// 修改动态消息（POST /cgi-bin/message/wxopen/updatablemsg/update）
    /// <para>更新已创建的动态消息的状态。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<UpdateActivityMsgResponse> UpdateActivityMsgAsync(UpdateActivityMsgRequest request, CancellationToken ct = default)
        => _http.PostAsync<UpdateActivityMsgResponse>("/cgi-bin/message/wxopen/updatablemsg/update", request, ct);

    /// <summary>
    /// 修改小程序聊天工具的动态卡片消息（POST /cgi-bin/message/wxopen/updatablemsg/setchat）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<SetChatToolMsgResponse> SetChatToolMsgAsync(SetChatToolMsgRequest request, CancellationToken ct = default)
        => _http.PostAsync<SetChatToolMsgResponse>("/cgi-bin/message/wxopen/updatablemsg/setchat", request, ct);
}