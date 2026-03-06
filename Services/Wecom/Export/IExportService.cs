using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Export;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 异步导出接口服务
/// <para>
/// 提供通讯录数据的异步导出功能，适用于数据量较大的企业。
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/94850"/>
/// </para>
/// </summary>
public interface IExportService
{
    /// <summary>
    /// 导出成员（简要信息）
    /// <para>异步导出企业通讯录成员的简要信息。</para>
    /// </summary>
    /// <param name="encodingAesKey">base64encode 的加密密钥（43 位）</param>
    /// <param name="blockSize">每块数据的人员数上限，范围 [10^4, 10^6]，默认 10^6</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>导出任务 ID</returns>
    Task<string> ExportSimpleUserAsync(string encodingAesKey, int? blockSize = null, CancellationToken ct = default);

    /// <summary>
    /// 导出成员详情
    /// <para>异步导出企业通讯录成员的详细信息。</para>
    /// </summary>
    /// <param name="encodingAesKey">base64encode 的加密密钥（43 位）</param>
    /// <param name="blockSize">每块数据的人员数上限，范围 [10^4, 10^6]，默认 10^6</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>导出任务 ID</returns>
    Task<string> ExportUserAsync(string encodingAesKey, int? blockSize = null, CancellationToken ct = default);

    /// <summary>
    /// 导出部门
    /// <para>异步导出企业通讯录部门信息。</para>
    /// </summary>
    /// <param name="encodingAesKey">base64encode 的加密密钥（43 位）</param>
    /// <param name="blockSize">每块数据的部门数上限，范围 [10^4, 10^6]，默认 10^6</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>导出任务 ID</returns>
    Task<string> ExportDepartmentAsync(string encodingAesKey, int? blockSize = null, CancellationToken ct = default);

    /// <summary>
    /// 导出标签成员
    /// <para>异步导出指定标签下的成员信息。</para>
    /// </summary>
    /// <param name="tagId">标签 ID</param>
    /// <param name="encodingAesKey">base64encode 的加密密钥（43 位）</param>
    /// <param name="blockSize">每块数据的人员数上限，范围 [10^4, 10^6]，默认 10^6</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>导出任务 ID</returns>
    Task<string> ExportTagUserAsync(int tagId, string encodingAesKey, int? blockSize = null, CancellationToken ct = default);

    /// <summary>
    /// 获取导出结果
    /// <para>根据任务 ID 查询导出任务的状态及数据文件下载信息。</para>
    /// </summary>
    /// <param name="jobId">导出任务 ID</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>导出结果（含任务状态和数据文件列表）</returns>
    Task<GetExportResultResponse> GetExportResultAsync(string jobId, CancellationToken ct = default);
}
