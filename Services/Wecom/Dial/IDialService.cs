using GaoXinLibrary.TencentSDK.Wecom.Models.Dial;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>公费电话服务接口</summary>
public interface IDialService
{
    /// <summary>获取公费电话拨打记录</summary>
    Task<DialRecord[]> GetDialRecordAsync(GetDialRecordRequest request, CancellationToken ct = default);
}
