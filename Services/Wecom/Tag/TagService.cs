using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Tag;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

public class TagService : ITagService
{
    private readonly WecomHttpClient _http;

    public TagService(WecomHttpClient http) => _http = http;

    public async Task<int> CreateTagAsync(string tagName, int? tagId = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateTagResponse>("/cgi-bin/tag/create",
            new CreateTagRequest { TagName = tagName, TagId = tagId }, ct);
        return resp.TagId;
    }

    public async Task UpdateTagAsync(int tagId, string tagName, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/tag/update",
            new UpdateTagRequest { TagId = tagId, TagName = tagName }, ct);

    public async Task DeleteTagAsync(int tagId, CancellationToken ct = default)
        => await _http.GetAsync<WecomBaseResponse>("/cgi-bin/tag/delete",
            new() { ["tagid"] = tagId.ToString() }, ct);

    public async Task<GetTagMembersResponse> GetTagMembersAsync(int tagId, CancellationToken ct = default)
        => await _http.GetAsync<GetTagMembersResponse>("/cgi-bin/tag/get",
            new() { ["tagid"] = tagId.ToString() }, ct);

    public async Task AddTagMembersAsync(int tagId, string[]? userIds = null, int[]? partyIds = null, CancellationToken ct = default)
        => await _http.PostAsync<TagMembersOperationResponse>("/cgi-bin/tag/addtagusers",
            new TagMembersRequest { TagId = tagId, UserList = userIds, PartyList = partyIds }, ct);

    public async Task DeleteTagMembersAsync(int tagId, string[]? userIds = null, int[]? partyIds = null, CancellationToken ct = default)
        => await _http.PostAsync<TagMembersOperationResponse>("/cgi-bin/tag/deltagusers",
            new TagMembersRequest { TagId = tagId, UserList = userIds, PartyList = partyIds }, ct);

    public async Task<TagInfo[]> GetTagListAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetTagListResponse>("/cgi-bin/tag/list", null, ct);
        return resp.TagList ?? [];
    }
}
