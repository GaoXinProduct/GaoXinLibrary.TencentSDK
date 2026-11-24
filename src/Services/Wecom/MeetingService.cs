using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>会议服务实现</summary>
public sealed class MeetingService
{
    private readonly WecomHttpClient _http;

    public MeetingService(WecomHttpClient http) => _http = http;

    /// <summary>创建预约会议</summary>
    public async Task<CreateMeetingResponse> CreateMeetingAsync(CreateMeetingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateMeetingResponse>("/cgi-bin/meeting/create", request, ct).ConfigureAwait(false);

    /// <summary>修改预约会议</summary>
    public async Task UpdateMeetingAsync(UpdateMeetingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/update", request, ct).ConfigureAwait(false);

    /// <summary>取消预约会议</summary>
    public async Task CancelMeetingAsync(CancelMeetingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/cancel", request, ct).ConfigureAwait(false);

    /// <summary>获取会议详情</summary>
    public async Task<MeetingInfo?> GetMeetingAsync(GetMeetingRequest request, CancellationToken ct = default)
    {
        var response = await _http.PostQueryAsync<MeetingInfo>("/cgi-bin/meeting/get_info", request, ct).ConfigureAwait(false);
        var meeting = response.LegacyMeetingInfo ?? response;
        meeting.MeetingId ??= request.MeetingId;
        if (meeting.MeetingEnd == 0 && meeting.MeetingDuration is long duration)
            meeting.MeetingEnd = checked(meeting.MeetingStart + duration);
        return meeting;
    }

    /// <summary>获取成员会议ID列表</summary>
    public async Task<GetUserMeetingIdResponse> GetUserMeetingIdAsync(GetUserMeetingIdRequest request, CancellationToken ct = default)
        => await _http.PostQueryAsync<GetUserMeetingIdResponse>("/cgi-bin/meeting/get_user_meetingid", request, ct).ConfigureAwait(false);

    /// <summary>分页获取当前会中的成员。周期性会议须传入子会议 ID。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/98157">企业微信接口文档</see></remarks>
    public Task<GetRealTimeParticipantsResponse> GetRealTimeParticipantsAsync(GetRealTimeParticipantsRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<GetRealTimeParticipantsResponse>("/cgi-bin/meeting/get_realtime_attendee_list", request, ct);

    /// <summary>分页查询会议云录制。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/99236">企业微信接口文档</see></remarks>
    public Task<GetRecordingListResponse> GetRecordingListAsync(GetRecordingListRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<GetRecordingListResponse>("/cgi-bin/meeting/record/list", request, ct);

    /// <summary>获取会议录制的播放和下载地址。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/100917">企业微信接口文档</see></remarks>
    public Task<GetRecordingDownloadUrlResponse> GetRecordingDownloadUrlAsync(GetRecordingDownloadUrlRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<GetRecordingDownloadUrlResponse>("/cgi-bin/meeting/record/get_file_list", request, ct);

    /// <summary>按日获取会议录制的观看和下载统计。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/99263">企业微信接口文档</see></remarks>
    public Task<GetRecordingAccessStatResponse> GetRecordingAccessStatAsync(GetRecordingAccessStatRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<GetRecordingAccessStatResponse>("/cgi-bin/meeting/record/get_statistics", request, ct);

    /// <summary>修改会议录制共享设置。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/98208">企业微信接口文档</see></remarks>
    public Task<ModifyRecordingShareResponse> ModifyRecordingShareAsync(ModifyRecordingShareRequest request, CancellationToken ct = default)
        => _http.PostAsync<ModifyRecordingShareResponse>("/cgi-bin/meeting/record/update_sharing_config", request, ct);

    /// <summary>删除指定会议录制 ID 下的全部云录制文件。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/98206">企业微信接口文档</see></remarks>
    public Task<DeleteRecordingResponse> DeleteRecordingAsync(DeleteRecordingRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.MeetingId);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.MeetingRecordId);
        return _http.PostAsync<DeleteRecordingResponse>("/cgi-bin/meeting/record/delete", request, ct);
    }

    /// <summary>删除单个会议录制文件。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/98207">企业微信接口文档</see></remarks>
    public Task<WecomBaseResponse> DeleteRecordingFileAsync(DeleteRecordingFileRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.MeetingId);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.RecordFileId);
        return _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/record/delete_file", request, ct);
    }

    /// <summary>创建网络研讨会。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/98842">企业微信接口文档</see></remarks>
    public Task<CreateWebinarResponse> CreateWebinarAsync(CreateWebinarRequest request, CancellationToken ct = default)
        => _http.PostAsync<CreateWebinarResponse>("/cgi-bin/meeting/create_webinars", request, ct);

    /// <summary>由创建者修改网络研讨会。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/98843">企业微信接口文档</see></remarks>
    public Task<ModifyWebinarResponse> ModifyWebinarAsync(ModifyWebinarRequest request, CancellationToken ct = default)
        => _http.PostAsync<ModifyWebinarResponse>("/cgi-bin/meeting/update_webinars", request, ct);

    /// <summary>由创建者取消网络研讨会。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/98870">企业微信接口文档</see></remarks>
    public Task<CancelWebinarResponse> CancelWebinarAsync(CancelWebinarRequest request, CancellationToken ct = default)
        => _http.PostAsync<CancelWebinarResponse>("/cgi-bin/meeting/cancel_webinars", request, ct);

    /// <summary>按会议 ID 或会议号获取网络研讨会详情。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/98860">企业微信接口文档</see></remarks>
    public Task<WebinarDetailInfo> GetWebinarDetailAsync(GetWebinarDetailRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<WebinarDetailInfo>("/cgi-bin/meeting/get_webinars", request, ct);
}
