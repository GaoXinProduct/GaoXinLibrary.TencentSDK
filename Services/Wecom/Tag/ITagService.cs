using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Tag;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 标签管理服务接口
/// <para>对应企业微信文档「通讯录管理 › 标签管理」章节</para>
/// </summary>
public interface ITagService
{
    /// <summary>
    /// 创建标签
    /// <para>对应接口：POST /cgi-bin/tag/create</para>
    /// </summary>
    /// <param name="tagName">标签名称，长度限制32个字以内</param>
    /// <param name="tagId">标签 ID（可选，不填时由企业微信自动生成）</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>创建的标签 ID</returns>
    Task<int> CreateTagAsync(string tagName, int? tagId = null, CancellationToken ct = default);

    /// <summary>
    /// 更新标签名称
    /// <para>对应接口：POST /cgi-bin/tag/update</para>
    /// </summary>
    /// <param name="tagId">标签 ID</param>
    /// <param name="tagName">新标签名称，长度限制32个字以内</param>
    /// <param name="ct">取消令牌</param>
    Task UpdateTagAsync(int tagId, string tagName, CancellationToken ct = default);

    /// <summary>
    /// 删除标签
    /// <para>对应接口：GET /cgi-bin/tag/delete</para>
    /// </summary>
    /// <param name="tagId">标签 ID</param>
    /// <param name="ct">取消令牌</param>
    Task DeleteTagAsync(int tagId, CancellationToken ct = default);

    /// <summary>
    /// 获取标签成员列表（成员列表与部门列表）
    /// <para>对应接口：GET /cgi-bin/tag/get</para>
    /// </summary>
    /// <param name="tagId">标签 ID</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>包含成员列表和部门列表的响应</returns>
    Task<GetTagMembersResponse> GetTagMembersAsync(int tagId, CancellationToken ct = default);

    /// <summary>
    /// 增加标签成员（支持按成员或按部门添加）
    /// <para>对应接口：POST /cgi-bin/tag/addtagusers</para>
    /// </summary>
    /// <param name="tagId">标签 ID</param>
    /// <param name="userIds">要添加的成员 UserId 列表（最多1000个）</param>
    /// <param name="partyIds">要添加的部门 ID 列表（最多100个）</param>
    /// <param name="ct">取消令牌</param>
    Task AddTagMembersAsync(int tagId, string[]? userIds = null, int[]? partyIds = null, CancellationToken ct = default);

    /// <summary>
    /// 删除标签成员（支持按成员或按部门删除）
    /// <para>对应接口：POST /cgi-bin/tag/deltagusers</para>
    /// </summary>
    /// <param name="tagId">标签 ID</param>
    /// <param name="userIds">要删除的成员 UserId 列表（最多1000个）</param>
    /// <param name="partyIds">要删除的部门 ID 列表（最多100个）</param>
    /// <param name="ct">取消令牌</param>
    Task DeleteTagMembersAsync(int tagId, string[]? userIds = null, int[]? partyIds = null, CancellationToken ct = default);

    /// <summary>
    /// 获取企业标签列表
    /// <para>对应接口：GET /cgi-bin/tag/list</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>标签信息数组</returns>
    Task<TagInfo[]> GetTagListAsync(CancellationToken ct = default);
}
