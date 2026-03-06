using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Department;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 部门管理服务接口
/// <para>对应企业微信文档「通讯录管理 › 部门管理」章节</para>
/// </summary>
public interface IDepartmentService
{
    /// <summary>
    /// 创建部门
    /// <para>对应接口：POST /cgi-bin/department/create</para>
    /// </summary>
    /// <param name="request">部门创建请求，包含名称、上级部门ID等</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>新创建的部门 ID</returns>
    Task<int> CreateDepartmentAsync(CreateDepartmentRequest request, CancellationToken ct = default);

    /// <summary>
    /// 更新部门信息（名称、排序、负责人等）
    /// <para>对应接口：POST /cgi-bin/department/update</para>
    /// </summary>
    /// <param name="request">部门更新请求，id 字段为必填</param>
    /// <param name="ct">取消令牌</param>
    Task UpdateDepartmentAsync(UpdateDepartmentRequest request, CancellationToken ct = default);

    /// <summary>
    /// 删除部门（部门下不能有成员或子部门）
    /// <para>对应接口：GET /cgi-bin/department/delete</para>
    /// </summary>
    /// <param name="id">要删除的部门 ID</param>
    /// <param name="ct">取消令牌</param>
    Task DeleteDepartmentAsync(int id, CancellationToken ct = default);

    /// <summary>
    /// 获取部门列表
    /// <para>对应接口：GET /cgi-bin/department/list</para>
    /// </summary>
    /// <param name="id">部门 ID；填写后仅返回该部门及其子部门，不填则返回整个企业的部门列表</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>部门信息数组</returns>
    Task<DepartmentInfo[]> GetDepartmentListAsync(int? id = null, CancellationToken ct = default);

    /// <summary>
    /// 获取子部门 ID 列表
    /// <para>对应接口：GET /cgi-bin/department/simplelist</para>
    /// </summary>
    /// <param name="id">父部门 ID</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>子部门信息数组（包含自身）</returns>
    Task<SubDeptInfo[]> GetSubDepartmentIdsAsync(int id, CancellationToken ct = default);

    /// <summary>
    /// 获取单个部门详细信息
    /// <para>对应接口：GET /cgi-bin/department/get</para>
    /// </summary>
    /// <param name="id">部门 ID</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>部门详细信息</returns>
    Task<DepartmentInfo> GetDepartmentAsync(int id, CancellationToken ct = default);
}
