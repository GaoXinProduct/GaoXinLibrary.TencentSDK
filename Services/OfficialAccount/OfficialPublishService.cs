using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号发布能力服务实现</summary>
public class OfficialPublishService : IOfficialPublishService
{
    private readonly WechatHttpClient _http;
    public OfficialPublishService(WechatHttpClient http) => _http = http;

    public Task<SubmitPublishResponse> SubmitAsync(string mediaId, CancellationToken ct = default)
        => _http.PostAsync<SubmitPublishResponse>("/cgi-bin/freepublish/submit", new SubmitPublishRequest { MediaId = mediaId }, ct);

    public Task<GetPublishResponse> GetAsync(string publishId, CancellationToken ct = default)
        => _http.PostAsync<GetPublishResponse>("/cgi-bin/freepublish/get", new GetPublishRequest { PublishId = publishId }, ct);

    public Task<DeletePublishResponse> DeleteAsync(DeletePublishRequest request, CancellationToken ct = default)
        => _http.PostAsync<DeletePublishResponse>("/cgi-bin/freepublish/delete", request, ct);

    public Task<GetArticleResponse> GetArticleAsync(string articleId, CancellationToken ct = default)
        => _http.PostAsync<GetArticleResponse>("/cgi-bin/freepublish/getarticle", new GetArticleRequest { ArticleId = articleId }, ct);

    public Task<BatchGetPublishResponse> BatchGetAsync(BatchGetPublishRequest request, CancellationToken ct = default)
        => _http.PostAsync<BatchGetPublishResponse>("/cgi-bin/freepublish/batchget", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  公众号留言管理服务

