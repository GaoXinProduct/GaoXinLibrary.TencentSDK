using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序硬件设备服务实现</summary>
public class MiniProgramDeviceService
{
    private readonly WechatHttpClient _http;
    public MiniProgramDeviceService(WechatHttpClient http) => _http = http;

    /// <summary>发送设备消息（POST /cgi-bin/message/device/subscribe/send）</summary>
    public Task<SendDeviceMessageResponse> SendMessageAsync(SendDeviceMessageRequest request, CancellationToken ct = default)
        => _http.PostAsync<SendDeviceMessageResponse>("/cgi-bin/message/device/subscribe/send", request, ct);

    /// <summary>
    /// 获取设备票据（POST /cgi-bin/message/device/subscribe/send_ticket）
    /// <para>用于获取设备票据。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetSnTicketResponse> GetSnTicketAsync(GetSnTicketRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetSnTicketResponse>("/cgi-bin/device/ticket/get_ticket", request, ct);

    /// <summary>
    /// 创建设备组（POST /iot/device/group/add）
    /// <para>创建一个设备组。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<CreateIotGroupIdResponse> CreateIotGroupIdAsync(CreateIotGroupIdRequest request, CancellationToken ct = default)
        => _http.PostAsync<CreateIotGroupIdResponse>("/iot/device/group/add", request, ct);

    /// <summary>
    /// 查询设备组信息（POST /iot/device/group/get）
    /// <para>查询指定设备组的详细信息。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetIotGroupInfoResponse> GetIotGroupInfoAsync(GetIotGroupInfoRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetIotGroupInfoResponse>("/iot/device/group/get", request, ct);

    /// <summary>
    /// 设备组添加设备（POST /iot/device/group/add_device）
    /// <para>向设备组添加设备。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<AddIotGroupDeviceResponse> AddIotGroupDeviceAsync(AddIotGroupDeviceRequest request, CancellationToken ct = default)
        => _http.PostAsync<AddIotGroupDeviceResponse>("/iot/device/group/add_device", request, ct);

    /// <summary>
    /// 设备组删除设备（POST /iot/device/group/del_device）
    /// <para>从设备组删除设备。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<RemoveIotGroupDeviceResponse> RemoveIotGroupDeviceAsync(RemoveIotGroupDeviceRequest request, CancellationToken ct = default)
        => _http.PostAsync<RemoveIotGroupDeviceResponse>("/iot/device/group/del_device", request, ct);

    /// <summary>
    /// 查询license资源包列表（POST /device/license/package/getlist）
    /// <para>查询已购买的license资源包列表。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetLicensePkgListResponse> GetLicensePkgListAsync(GetLicensePkgListRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetLicensePkgListResponse>("/device/license/package/getlist", request, ct);

    /// <summary>
    /// 激活设备license（POST /device/license/device/activate）
    /// <para>激活设备的license。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<ActiveLicenseDeviceResponse> ActiveLicenseDeviceAsync(ActiveLicenseDeviceRequest request, CancellationToken ct = default)
        => _http.PostAsync<ActiveLicenseDeviceResponse>("/device/license/device/activate", request, ct);

    /// <summary>
    /// 查询设备激活详情（POST /device/license/device/info）
    /// <para>查询设备的license激活详情。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetLicenseDeviceInfoResponse> GetLicenseDeviceInfoAsync(GetLicenseDeviceInfoRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetLicenseDeviceInfoResponse>("/device/license/device/info", request, ct);
}