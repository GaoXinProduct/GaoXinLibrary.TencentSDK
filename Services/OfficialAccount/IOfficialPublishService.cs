using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>公众号发布能力服务接口</summary>
public interface IOfficialPublishService
{
    /// <summary>发布草稿</summary>
    Task<SubmitPublishResponse> SubmitAsync(string mediaId, CancellationToken ct = default);
    /// <summary>查询发布状态</summary>
    Task<GetPublishResponse> GetAsync(string publishId, CancellationToken ct = default);
    /// <summary>删除发布</summary>
    Task<DeletePublishResponse> DeleteAsync(DeletePublishRequest request, CancellationToken ct = default);
    /// <summary>通过 article_id 获取已发布文章</summary>
    Task<GetArticleResponse> GetArticleAsync(string articleId, CancellationToken ct = default);
    /// <summary>获取成功发布列表</summary>
    Task<BatchGetPublishResponse> BatchGetAsync(BatchGetPublishRequest request, CancellationToken ct = default);
}

