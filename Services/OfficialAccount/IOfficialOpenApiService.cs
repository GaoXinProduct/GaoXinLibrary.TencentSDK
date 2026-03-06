using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>公众号 OpenAPI 管理服务接口</summary>
public interface IOfficialOpenApiService
{
    /// <summary>清空 api 的调用 quota</summary>
    Task<OfficialClearQuotaResponse> ClearQuotaAsync(CancellationToken ct = default);
    /// <summary>查询 openAPI 调用额度</summary>
    Task<OfficialGetApiQuotaResponse> GetQuotaAsync(OfficialGetApiQuotaRequest request, CancellationToken ct = default);
    /// <summary>查询 rid 信息</summary>
    Task<OfficialGetRidInfoResponse> GetRidInfoAsync(string rid, CancellationToken ct = default);
}

