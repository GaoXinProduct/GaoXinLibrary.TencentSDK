using GaoXinLibrary.TencentSDK.Wecom.Models.IpRange;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>IP段查询服务接口</summary>
public interface IIpRangeService
{
    /// <summary>获取企业微信接口IP段</summary>
    Task<string[]> GetApiIpListAsync(CancellationToken ct = default);

    /// <summary>获取企业微信回调IP段</summary>
    Task<string[]> GetCallbackIpListAsync(CancellationToken ct = default);
}
