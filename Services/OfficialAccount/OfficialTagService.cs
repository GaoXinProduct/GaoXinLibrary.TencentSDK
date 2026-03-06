using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号用户标签管理服务实现</summary>
public class OfficialTagService : IOfficialTagService
{
    private readonly WechatHttpClient _http;
    public OfficialTagService(WechatHttpClient http) => _http = http;

    public Task<CreateTagResponse> CreateAsync(string name, CancellationToken ct = default)
        => _http.PostAsync<CreateTagResponse>("/cgi-bin/tags/create", new CreateTagRequest { Tag = new TagItem { Name = name } }, ct);

    public Task<GetTagsResponse> GetAllAsync(CancellationToken ct = default)
        => _http.GetAsync<GetTagsResponse>("/cgi-bin/tags/get", ct: ct);

    public Task<TagOperationResponse> UpdateAsync(int id, string name, CancellationToken ct = default)
        => _http.PostAsync<TagOperationResponse>("/cgi-bin/tags/update", new UpdateTagRequest { Tag = new TagItem { Id = id, Name = name } }, ct);

    public Task<TagOperationResponse> DeleteAsync(int id, CancellationToken ct = default)
        => _http.PostAsync<TagOperationResponse>("/cgi-bin/tags/delete", new DeleteTagRequest { Tag = new TagItem { Id = id } }, ct);

    public Task<GetTagUsersResponse> GetUsersAsync(GetTagUsersRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetTagUsersResponse>("/cgi-bin/user/tag/get", request, ct);

    public Task<TagOperationResponse> BatchTagAsync(BatchTagRequest request, CancellationToken ct = default)
        => _http.PostAsync<TagOperationResponse>("/cgi-bin/tags/members/batchtagging", request, ct);

    public Task<TagOperationResponse> BatchUntagAsync(BatchTagRequest request, CancellationToken ct = default)
        => _http.PostAsync<TagOperationResponse>("/cgi-bin/tags/members/batchuntagging", request, ct);

    public Task<GetUserTagsResponse> GetUserTagsAsync(string openId, CancellationToken ct = default)
        => _http.PostAsync<GetUserTagsResponse>("/cgi-bin/tags/getidlist", new GetUserTagsRequest { OpenId = openId }, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  公众号草稿管理服务

