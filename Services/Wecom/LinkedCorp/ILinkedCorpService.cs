using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 上下游/互联企业服务接口
/// <para>
/// 提供互联企业的成员、部门数据查询功能，适用于已通过企业互联或上下游建立连接的企业之间调用。
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/97213"/>
/// </para>
/// </summary>
public interface ILinkedCorpService
{
    /// <summary>
    /// 获取应用的可见范围
    /// <para>本接口只返回互联企业中非本企业内的成员和部门的信息。</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>可见的 userids 和 department_ids</returns>
    Task<GetPermListResponse> GetPermListAsync(CancellationToken ct = default);

    /// <summary>
    /// 获取互联企业成员详细信息
    /// </summary>
    /// <param name="userId">CorpId/UserId 拼接的字符串</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>成员详细信息</returns>
    Task<LinkedCorpUser?> GetUserAsync(string userId, CancellationToken ct = default);

    /// <summary>
    /// 获取互联企业部门成员（简要信息）
    /// </summary>
    /// <param name="departmentId">CorpId/DepartmentId 拼接的字符串</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>成员简要信息列表</returns>
    Task<LinkedCorpSimpleUser[]> GetUserSimpleListAsync(string departmentId, CancellationToken ct = default);

    /// <summary>
    /// 获取互联企业部门成员详情
    /// </summary>
    /// <param name="departmentId">CorpId/DepartmentId 拼接的字符串</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>成员详细信息列表</returns>
    Task<LinkedCorpUser[]> GetUserListAsync(string departmentId, CancellationToken ct = default);

    /// <summary>
    /// 获取互联企业部门列表
    /// </summary>
    /// <param name="departmentId">CorpId/DepartmentId 拼接的字符串</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>部门列表</returns>
    Task<LinkedCorpDepartment[]> GetDepartmentListAsync(string departmentId, CancellationToken ct = default);
}
