using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>公众号用户标签管理服务接口</summary>
public interface IOfficialTagService
{
    /// <summary>创建标签</summary>
    Task<CreateTagResponse> CreateAsync(string name, CancellationToken ct = default);
    /// <summary>获取公众号已创建的标签</summary>
    Task<GetTagsResponse> GetAllAsync(CancellationToken ct = default);
    /// <summary>编辑标签</summary>
    Task<TagOperationResponse> UpdateAsync(int id, string name, CancellationToken ct = default);
    /// <summary>删除标签</summary>
    Task<TagOperationResponse> DeleteAsync(int id, CancellationToken ct = default);
    /// <summary>获取标签下粉丝列表</summary>
    Task<GetTagUsersResponse> GetUsersAsync(GetTagUsersRequest request, CancellationToken ct = default);
    /// <summary>批量为用户打标签</summary>
    Task<TagOperationResponse> BatchTagAsync(BatchTagRequest request, CancellationToken ct = default);
    /// <summary>批量为用户取消标签</summary>
    Task<TagOperationResponse> BatchUntagAsync(BatchTagRequest request, CancellationToken ct = default);
    /// <summary>获取用户身上的标签列表</summary>
    Task<GetUserTagsResponse> GetUserTagsAsync(string openId, CancellationToken ct = default);
}

