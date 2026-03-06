using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>公众号草稿管理服务接口</summary>
public interface IOfficialDraftService
{
    /// <summary>新建草稿</summary>
    Task<AddDraftResponse> AddAsync(AddDraftRequest request, CancellationToken ct = default);
    /// <summary>获取草稿</summary>
    Task<GetDraftResponse> GetAsync(string mediaId, CancellationToken ct = default);
    /// <summary>删除草稿</summary>
    Task<DeleteDraftResponse> DeleteAsync(string mediaId, CancellationToken ct = default);
    /// <summary>获取草稿列表</summary>
    Task<BatchGetDraftResponse> BatchGetAsync(BatchGetDraftRequest request, CancellationToken ct = default);
    /// <summary>获取草稿总数</summary>
    Task<GetDraftCountResponse> GetCountAsync(CancellationToken ct = default);
}

