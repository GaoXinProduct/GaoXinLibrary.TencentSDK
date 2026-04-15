using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序内容安全服务实现</summary>
public class MiniProgramSecurityService
{
    private readonly WechatHttpClient _http;

    public MiniProgramSecurityService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <summary>
    /// 文本内容安全检测（security.msgSecCheck）
    /// <para>用于校验一段文本是否含有违法违规内容。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<MsgSecCheckResponse> MsgSecCheckAsync(MsgSecCheckRequest request, CancellationToken ct = default)
        => _http.PostAsync<MsgSecCheckResponse>("/wxa/msg_sec_check", request, ct);

    /// <summary>
    /// 音视频内容安全异步检测（security.mediaCheckAsync）
    /// <para>异步校验图片/音频是否含有违法违规内容，结果通过回调推送。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<MediaCheckAsyncResponse> MediaCheckAsync(MediaCheckAsyncRequest request, CancellationToken ct = default)
        => _http.PostAsync<MediaCheckAsyncResponse>("/wxa/media_check_async", request, ct);

    /// <summary>
    /// 获取用户安全等级（POST /wxa/getuserriskrank）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetUserRiskRankResponse> GetUserRiskRankAsync(GetUserRiskRankRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetUserRiskRankResponse>("/wxa/getuserriskrank", request, ct);
}
