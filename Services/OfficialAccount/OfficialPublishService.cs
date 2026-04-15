using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号发布能力服务实现</summary>
public class OfficialPublishService
{
    private readonly WechatHttpClient _http;
    public OfficialPublishService(WechatHttpClient http) => _http = http;

    /// <summary>发布草稿</summary>
    public Task<SubmitPublishResponse> SubmitAsync(string mediaId, CancellationToken ct = default)
        => _http.PostAsync<SubmitPublishResponse>("/cgi-bin/freepublish/submit", new SubmitPublishRequest { MediaId = mediaId }, ct);

    /// <summary>查询发布状态</summary>
    public Task<GetPublishResponse> GetAsync(string publishId, CancellationToken ct = default)
        => _http.PostAsync<GetPublishResponse>("/cgi-bin/freepublish/get", new GetPublishRequest { PublishId = publishId }, ct);

    /// <summary>删除发布</summary>
    public Task<DeletePublishResponse> DeleteAsync(DeletePublishRequest request, CancellationToken ct = default)
        => _http.PostAsync<DeletePublishResponse>("/cgi-bin/freepublish/delete", request, ct);

    /// <summary>通过 article_id 获取已发布文章</summary>
    public Task<GetArticleResponse> GetArticleAsync(string articleId, CancellationToken ct = default)
        => _http.PostAsync<GetArticleResponse>("/cgi-bin/freepublish/getarticle", new GetArticleRequest { ArticleId = articleId }, ct);

    /// <summary>获取成功发布列表</summary>
    public Task<BatchGetPublishResponse> BatchGetAsync(BatchGetPublishRequest request, CancellationToken ct = default)
        => _http.PostAsync<BatchGetPublishResponse>("/cgi-bin/freepublish/batchget", request, ct);
}
