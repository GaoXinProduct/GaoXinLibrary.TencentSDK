using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 小程序内容安全服务接口
/// </summary>
public interface IMiniProgramSecurityService
{
    /// <summary>
    /// 文本内容安全检测（security.msgSecCheck）
    /// <para>用于校验一段文本是否含有违法违规内容。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    Task<MsgSecCheckResponse> MsgSecCheckAsync(MsgSecCheckRequest request, CancellationToken ct = default);

    /// <summary>
    /// 音视频内容安全异步检测（security.mediaCheckAsync）
    /// <para>异步校验图片/音频是否含有违法违规内容，结果通过回调推送。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    Task<MediaCheckAsyncResponse> MediaCheckAsync(MediaCheckAsyncRequest request, CancellationToken ct = default);

    /// <summary>
    /// 获取用户安全等级（POST /wxa/getuserriskrank）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    Task<GetUserRiskRankResponse> GetUserRiskRankAsync(GetUserRiskRankRequest request, CancellationToken ct = default);
}

