using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号草稿管理服务实现</summary>
public class OfficialDraftService
{
    private readonly WechatHttpClient _http;
    public OfficialDraftService(WechatHttpClient http) => _http = http;

    /// <summary>新建草稿</summary>
    public Task<AddDraftResponse> AddAsync(AddDraftRequest request, CancellationToken ct = default)
        => _http.PostAsync<AddDraftResponse>("/cgi-bin/draft/add", request, ct);

    /// <summary>获取草稿</summary>
    public Task<GetDraftResponse> GetAsync(string mediaId, CancellationToken ct = default)
        => _http.PostAsync<GetDraftResponse>("/cgi-bin/draft/get", new GetDraftRequest { MediaId = mediaId }, ct);

    /// <summary>删除草稿</summary>
    public Task<DeleteDraftResponse> DeleteAsync(string mediaId, CancellationToken ct = default)
        => _http.PostAsync<DeleteDraftResponse>("/cgi-bin/draft/delete", new DeleteDraftRequest { MediaId = mediaId }, ct);

    /// <summary>获取草稿列表</summary>
    public Task<BatchGetDraftResponse> BatchGetAsync(BatchGetDraftRequest request, CancellationToken ct = default)
        => _http.PostAsync<BatchGetDraftResponse>("/cgi-bin/draft/batchget", request, ct);

    /// <summary>获取草稿总数</summary>
    public Task<GetDraftCountResponse> GetCountAsync(CancellationToken ct = default)
        => _http.GetAsync<GetDraftCountResponse>("/cgi-bin/draft/count", ct: ct);
}
