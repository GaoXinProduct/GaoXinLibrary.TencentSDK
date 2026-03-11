using GaoXinLibrary.TencentSDK.Wecom.Models.Dial;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>公费电话服务接口</summary>
public interface IDialService
{
    /// <summary>获取公费电话拨打记录</summary>
    Task<DialRecord[]> GetDialRecordAsync(long startTime, long endTime, int offset = 0, int limit = 100, CancellationToken ct = default);
}
