using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号草稿管理服务实现</summary>
public class OfficialDraftService : IOfficialDraftService
{
    private readonly WechatHttpClient _http;
    public OfficialDraftService(WechatHttpClient http) => _http = http;

    public Task<AddDraftResponse> AddAsync(AddDraftRequest request, CancellationToken ct = default)
        => _http.PostAsync<AddDraftResponse>("/cgi-bin/draft/add", request, ct);

    public Task<GetDraftResponse> GetAsync(string mediaId, CancellationToken ct = default)
        => _http.PostAsync<GetDraftResponse>("/cgi-bin/draft/get", new GetDraftRequest { MediaId = mediaId }, ct);

    public Task<DeleteDraftResponse> DeleteAsync(string mediaId, CancellationToken ct = default)
        => _http.PostAsync<DeleteDraftResponse>("/cgi-bin/draft/delete", new DeleteDraftRequest { MediaId = mediaId }, ct);

    public Task<BatchGetDraftResponse> BatchGetAsync(BatchGetDraftRequest request, CancellationToken ct = default)
        => _http.PostAsync<BatchGetDraftResponse>("/cgi-bin/draft/batchget", request, ct);

    public Task<GetDraftCountResponse> GetCountAsync(CancellationToken ct = default)
        => _http.GetAsync<GetDraftCountResponse>("/cgi-bin/draft/count", ct: ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  公众号发布能力服务

