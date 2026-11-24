using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Security;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>安全管理服务实现</summary>
public sealed class SecurityService
{
    private const string FileOperationRecordsPath = "/cgi-bin/security/get_file_oper_record";
    private const long MaxFileOperationRangeSeconds = 14 * 24 * 60 * 60;

    private readonly WecomHttpClient _http;

    public SecurityService(WecomHttpClient http) => _http = http;

    /// <summary>获取最近 24 小时的第一页文件操作记录，兼容旧调用方式。</summary>
    /// <remarks>指定时间范围或继续分页时请使用 <see cref="GetFileOperationRecordsAsync"/>。</remarks>
    public Task<GetFileLeakPreventionResponse> GetFileLeakPreventionAsync(CancellationToken ct = default)
    {
        var now = DateTimeOffset.UtcNow;
        var request = new GetFileOperationRecordsRequest
        {
            StartTime = now.AddDays(-1).ToUnixTimeSeconds(),
            EndTime = now.ToUnixTimeSeconds()
        };

        return _http.PostQueryAsync<GetFileLeakPreventionResponse>(FileOperationRecordsPath, request, ct);
    }

    /// <summary>按时间范围查询文件操作记录，单次查询范围最长 14 天。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/98079">文件防泄漏接口</see></remarks>
    public Task<GetFileOperationRecordsResponse> GetFileOperationRecordsAsync(
        GetFileOperationRecordsRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (request.StartTime < 0 || request.EndTime < request.StartTime ||
            request.EndTime - request.StartTime > MaxFileOperationRangeSeconds)
        {
            throw new ArgumentOutOfRangeException(nameof(request), "起止时间必须为 Unix 秒时间戳，结束时间不得早于开始时间，且查询范围不能超过 14 天。");
        }

        return _http.PostQueryAsync<GetFileOperationRecordsResponse>(FileOperationRecordsPath, request, ct);
    }

    /// <summary>按最后登录成员获取设备信息。</summary>
    public Task<GetDeviceInfoResponse> GetDeviceInfoAsync(GetDeviceInfoRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<GetDeviceInfoResponse>("/cgi-bin/security/trustdevice/get_by_user", request, ct);

    /// <summary>导入可信设备，并返回每条导入记录的处理结果。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/98920">设备管理接口</see></remarks>
    public Task<ImportTrustedDevicesResponse> ImportTrustedDevicesAsync(
        ImportTrustedDevicesRequest request, CancellationToken ct = default)
        => _http.PostAsync<ImportTrustedDevicesResponse>("/cgi-bin/security/trustdevice/import", request, ct);

    /// <summary>按设备类型和分页游标查询设备列表。</summary>
    public Task<ListTrustedDevicesResponse> ListTrustedDevicesAsync(
        ListTrustedDevicesRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<ListTrustedDevicesResponse>("/cgi-bin/security/trustdevice/list", request, ct);

    /// <summary>按设备类型及设备标识删除设备。</summary>
    public Task<WecomBaseResponse> DeleteTrustedDevicesAsync(DeleteTrustedDevicesRequest request, CancellationToken ct = default)
        => _http.PostAsync<WecomBaseResponse>("/cgi-bin/security/trustdevice/delete", request, ct);

    /// <summary>通过设备申请，并返回成功和失败的设备标识。</summary>
    public Task<TrustedDeviceApprovalResponse> ApproveTrustedDevicesAsync(
        TrustedDeviceApprovalRequest request, CancellationToken ct = default)
        => _http.PostAsync<TrustedDeviceApprovalResponse>("/cgi-bin/security/trustdevice/approve", request, ct);

    /// <summary>驳回设备申请，并返回成功和失败的设备标识。</summary>
    public Task<TrustedDeviceApprovalResponse> RejectTrustedDevicesAsync(
        TrustedDeviceApprovalRequest request, CancellationToken ct = default)
        => _http.PostAsync<TrustedDeviceApprovalResponse>("/cgi-bin/security/trustdevice/reject", request, ct);

    /// <summary>获取截屏和录屏操作记录。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/100128">截屏和录屏管理接口</see></remarks>
    public Task<GetScreenOperationRecordsResponse> GetScreenOperationRecordsAsync(
        GetScreenOperationRecordsRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<GetScreenOperationRecordsResponse>("/cgi-bin/security/get_screen_oper_record", request, ct);

    /// <summary>获取企业微信相关功能所使用的域名和 IP 信息。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/100079">企业微信域名 IP 信息接口</see></remarks>
    public Task<GetServerDomainIpResponse> GetServerDomainIpAsync(CancellationToken ct = default)
        => _http.GetAsync<GetServerDomainIpResponse>("/cgi-bin/security/get_server_domain_ip", ct: ct);
}
