using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 小程序客服消息服务接口
/// </summary>
public interface IMiniProgramCustomMessageService
{
    /// <summary>发送客服消息（POST /cgi-bin/message/custom/send）</summary>
    Task<SendCustomMessageResponse> SendAsync(SendCustomMessageRequest request, CancellationToken ct = default);
    /// <summary>下发客服当前输入状态（POST /cgi-bin/message/custom/typing）</summary>
    Task<SetTypingResponse> SetTypingAsync(SetTypingRequest request, CancellationToken ct = default);
}

