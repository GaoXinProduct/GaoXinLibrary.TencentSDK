using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序码服务实现</summary>
public class MiniProgramQrCodeService
{
    private readonly WechatHttpClient _http;

    public MiniProgramQrCodeService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <summary>
    /// 获取不限制的小程序码（wxacode.getUnlimited）
    /// <para>
    /// 通过该接口生成的小程序码数量不受限制，适用于需要将小程序码嵌入线下物料等场景。
    /// 返回二进制图片数据。
    /// </para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>小程序码图片二进制数据</returns>
    public Task<byte[]> GetUnlimitedAsync(GetUnlimitedQrCodeRequest request, CancellationToken ct = default)
        => _http.PostForBytesAsync("/wxa/getwxacodeunlimit", request, ct);

    /// <summary>
    /// 获取小程序码（wxacode.get）
    /// <para>
    /// 生成数量有限的小程序码（每个 path 限量 10 万个），适用于需要扫码跳转到指定页面的场景。
    /// 返回二进制图片数据。
    /// </para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>小程序码图片二进制数据</returns>
    public Task<byte[]> GetQrCodeAsync(GetQrCodeRequest request, CancellationToken ct = default)
        => _http.PostForBytesAsync("/wxa/getwxacode", request, ct);

    /// <summary>
    /// 获取小程序二维码（wxacode.createQRCode）
    /// <para>
    /// 生成数量有限的小程序二维码（每个 path 限量 10 万个）。
    /// 返回二进制图片数据。
    /// </para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>小程序二维码图片二进制数据</returns>
    public Task<byte[]> CreateQrCodeAsync(CreateQrCodeRequest request, CancellationToken ct = default)
        => _http.PostForBytesAsync("/cgi-bin/wxaapp/createwxaqrcode", request, ct);
}
