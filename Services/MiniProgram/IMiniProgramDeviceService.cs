using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 小程序硬件设备服务接口
/// </summary>
public interface IMiniProgramDeviceService
{
    /// <summary>发送设备消息（POST /cgi-bin/message/device/subscribe/send）</summary>
    Task<SendDeviceMessageResponse> SendMessageAsync(SendDeviceMessageRequest request, CancellationToken ct = default);
}

