using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Tag;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

public class TagService
{
    private readonly WecomHttpClient _http;

    public TagService(WecomHttpClient http) => _http = http;

    /// <summary>
    /// 创建标签
    /// <para>对应接口：POST /cgi-bin/tag/create</para>
    /// </summary>
    /// <param name="tagName">标签名称，长度限制32个字以内</param>
    /// <param name="tagId">标签 ID（可选，不填时由企业微信自动生成）</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>创建的标签 ID</returns>
    public async Task<int> CreateTagAsync(string tagName, int? tagId = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateTagResponse>("/cgi-bin/tag/create",
            new CreateTagRequest { TagName = tagName, TagId = tagId }, ct);
        return resp.TagId;
    }

    /// <summary>
    /// 更新标签名称
    /// <para>对应接口：POST /cgi-bin/tag/update</para>
    /// </summary>
    /// <param name="tagId">标签 ID</param>
    /// <param name="tagName">新标签名称，长度限制32个字以内</param>
    /// <param name="ct">取消令牌</param>
    public async Task UpdateTagAsync(int tagId, string tagName, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/tag/update",
            new UpdateTagRequest { TagId = tagId, TagName = tagName }, ct);

    /// <summary>
    /// 删除标签
    /// <para>对应接口：GET /cgi-bin/tag/delete</para>
    /// </summary>
    /// <param name="tagId">标签 ID</param>
    /// <param name="ct">取消令牌</param>
    public async Task DeleteTagAsync(int tagId, CancellationToken ct = default)
        => await _http.GetAsync<WecomBaseResponse>("/cgi-bin/tag/delete",
            new() { ["tagid"] = tagId.ToString() }, ct);

    /// <summary>
    /// 获取标签成员列表（成员列表与部门列表）
    /// <para>对应接口：GET /cgi-bin/tag/get</para>
    /// </summary>
    /// <param name="tagId">标签 ID</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>包含成员列表和部门列表的响应</returns>
    public async Task<GetTagMembersResponse> GetTagMembersAsync(int tagId, CancellationToken ct = default)
        => await _http.GetAsync<GetTagMembersResponse>("/cgi-bin/tag/get",
            new() { ["tagid"] = tagId.ToString() }, ct);

    /// <summary>
    /// 增加标签成员（支持按成员或按部门添加）
    /// <para>对应接口：POST /cgi-bin/tag/addtagusers</para>
    /// </summary>
    /// <param name="tagId">标签 ID</param>
    /// <param name="userIds">要添加的成员 UserId 列表（最多1000个）</param>
    /// <param name="partyIds">要添加的部门 ID 列表（最多100个）</param>
    /// <param name="ct">取消令牌</param>
    public async Task AddTagMembersAsync(int tagId, string[]? userIds = null, int[]? partyIds = null, CancellationToken ct = default)
        => await _http.PostAsync<TagMembersOperationResponse>("/cgi-bin/tag/addtagusers",
            new TagMembersRequest { TagId = tagId, UserList = userIds, PartyList = partyIds }, ct);

    /// <summary>
    /// 删除标签成员（支持按成员或按部门删除）
    /// <para>对应接口：POST /cgi-bin/tag/deltagusers</para>
    /// </summary>
    /// <param name="tagId">标签 ID</param>
    /// <param name="userIds">要删除的成员 UserId 列表（最多1000个）</param>
    /// <param name="partyIds">要删除的部门 ID 列表（最多100个）</param>
    /// <param name="ct">取消令牌</param>
    public async Task DeleteTagMembersAsync(int tagId, string[]? userIds = null, int[]? partyIds = null, CancellationToken ct = default)
        => await _http.PostAsync<TagMembersOperationResponse>("/cgi-bin/tag/deltagusers",
            new TagMembersRequest { TagId = tagId, UserList = userIds, PartyList = partyIds }, ct);

    /// <summary>
    /// 获取企业标签列表
    /// <para>对应接口：GET /cgi-bin/tag/list</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>标签信息数组</returns>
    public async Task<TagInfo[]> GetTagListAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetTagListResponse>("/cgi-bin/tag/list", null, ct);
        return resp.TagList ?? [];
    }
}
