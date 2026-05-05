using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// 会议服务实现。
/// 覆盖基础会议、预约会议高级管理（Webinar、网络研讨会、Rooms会议室、布局背景管理、录制管理、PSTN电话外呼）等全部功能。
/// </summary>
public class MeetingService
{
    private readonly WecomHttpClient _http;

    public MeetingService(WecomHttpClient http) => _http = http;

    #region Basic & Statistics

    /// <summary>
    /// 创建会议。
    /// 文档：https://developer.work.weixin.qq.com/document/path/99041
    /// </summary>
    public async Task<CreateMeetingResponse> CreateMeetingAsync(CreateMeetingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateMeetingResponse>("/cgi-bin/meeting/create", request, ct);

    /// <summary>
    /// 更新会议信息。
    /// 文档：https://developer.work.weixin.qq.com/document/path/99042
    /// </summary>
    public async Task UpdateMeetingAsync(UpdateMeetingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/update", request, ct);

    /// <summary>
    /// 取消会议。
    /// 文档：https://developer.work.weixin.qq.com/document/path/99043
    /// </summary>
    public async Task CancelMeetingAsync(CancelMeetingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/cancel", request, ct);

    /// <summary>
    /// 获取会议详情。
    /// 文档：https://developer.work.weixin.qq.com/document/path/99044
    /// </summary>
    public async Task<MeetingInfo?> GetMeetingAsync(GetMeetingRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetMeetingResponse>("/cgi-bin/meeting/get_info", request, ct);
        return resp.MeetingInfo;
    }

    /// <summary>
    /// 获取用户会议ID列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/99050
    /// </summary>
    public async Task<GetUserMeetingIdResponse> GetUserMeetingIdAsync(GetUserMeetingIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetUserMeetingIdResponse>("/cgi-bin/meeting/get_user_meetingid", request, ct);

    /// <summary>
    /// 获取会议详情（按会议ID）。
    /// 文档：https://developer.work.weixin.qq.com/document/path/99049
    /// </summary>
    public async Task<GetMeetingDetailResponse> GetMeetingDetailAsync(GetMeetingDetailRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMeetingDetailResponse>("/cgi-bin/meeting/get_info_by_meeting_id", request, ct);

    /// <summary>
    /// 获取成员会议ID列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/99050
    /// </summary>
    public async Task<GetMeetingIdListResponse> GetMeetingIdListAsync(GetMeetingIdListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMeetingIdListResponse>("/cgi-bin/meeting/list", request, ct);

    /// <summary>
    /// 获取会议发起记录。
    /// 文档：https://developer.work.weixin.qq.com/document/path/99651
    /// </summary>
    public async Task<GetMeetingRecordResponse> GetMeetingRecordAsync(GetMeetingRecordRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMeetingRecordResponse>("/cgi-bin/meeting/get_record_file", request, ct);

    #endregion

    #region Advanced Booking

    /// <summary>
    /// 创建预约会议（高级）。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98767
    /// </summary>
    public async Task<CreateAdvancedMeetingResponse> CreateAdvancedMeetingAsync(CreateAdvancedMeetingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateAdvancedMeetingResponse>("/cgi-bin/meeting/create_advanced", request, ct);

    /// <summary>
    /// 修改预约会议（高级）。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98768
    /// </summary>
    public async Task<ModifyAdvancedMeetingResponse> ModifyAdvancedMeetingAsync(ModifyAdvancedMeetingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ModifyAdvancedMeetingResponse>("/cgi-bin/meeting/update_advanced", request, ct);

    /// <summary>
    /// 取消预约会议（高级）。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98769
    /// </summary>
    public async Task CancelAdvancedMeetingAsync(CancelAdvancedMeetingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/cancel_advanced", request, ct);

    /// <summary>
    /// 获取预约会议详情（高级）。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98770
    /// </summary>
    public async Task<GetAdvancedMeetingDetailResponse> GetAdvancedMeetingDetailAsync(GetAdvancedMeetingDetailRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetAdvancedMeetingDetailResponse>("/cgi-bin/meeting/get_advanced_meeting_info", request, ct);

    /// <summary>
    /// 获取会议受邀人列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98771
    /// </summary>
    public async Task<GetMeetingInviteeListResponse> GetMeetingInviteeListAsync(GetMeetingInviteeListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMeetingInviteeListResponse>("/cgi-bin/meeting/get_invitee_list", request, ct);

    /// <summary>
    /// 更新会议受邀人列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98772
    /// </summary>
    public async Task UpdateMeetingInviteeListAsync(UpdateMeetingInviteeListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/update_invitee", request, ct);

    /// <summary>
    /// 创建用户会议链接。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98773
    /// </summary>
    public async Task<CreateUserMeetingLinkResponse> CreateUserMeetingLinkAsync(CreateUserMeetingLinkRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateUserMeetingLinkResponse>("/cgi-bin/meeting/create_user_meeting_link", request, ct);

    /// <summary>
    /// 获取用户会议链接。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98774
    /// </summary>
    public async Task<GetUserMeetingLinkResponse> GetUserMeetingLinkAsync(GetUserMeetingLinkRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetUserMeetingLinkResponse>("/cgi-bin/meeting/get_user_meeting_link", request, ct);

    /// <summary>
    /// 获取实时会议参会者列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98775
    /// </summary>
    public async Task<GetRealTimeParticipantsResponse> GetRealTimeParticipantsAsync(GetRealTimeParticipantsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetRealTimeParticipantsResponse>("/cgi-bin/meeting/get_participants", request, ct);

    /// <summary>
    /// 获取等候室参会者列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98776
    /// </summary>
    public async Task<GetWaitRoomMembersResponse> GetWaitRoomMembersAsync(GetWaitRoomMembersRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetWaitRoomMembersResponse>("/cgi-bin/meeting/get_wait_room_members", request, ct);

    /// <summary>
    /// 获取设备签到状态。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98777
    /// </summary>
    public async Task<GetDeviceCheckInStatusResponse> GetDeviceCheckInStatusAsync(GetDeviceCheckInStatusRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetDeviceCheckInStatusResponse>("/cgi-bin/meeting/get_check_in_list", request, ct);

    /// <summary>
    /// 获取会议嘉宾列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98778
    /// </summary>
    public async Task<GetGuestListResponse> GetGuestListAsync(GetGuestListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetGuestListResponse>("/cgi-bin/meeting/get_guest_list", request, ct);

    /// <summary>
    /// 更新会议嘉宾列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98779
    /// </summary>
    public async Task UpdateGuestListAsync(UpdateGuestListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/update_guest_list", request, ct);

    /// <summary>
    /// 获取会议健康度。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98780
    /// </summary>
    public async Task<GetMeetingHealthResponse> GetMeetingHealthAsync(GetMeetingHealthRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMeetingHealthResponse>("/cgi-bin/meeting/get_meeting_health", request, ct);

    /// <summary>
    /// 更新报名配置。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98781
    /// </summary>
    public async Task UpdateRegistrationConfigAsync(UpdateRegistrationConfigRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/update_registration_config", request, ct);

    /// <summary>
    /// 获取报名配置。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98782
    /// </summary>
    public async Task<GetRegistrationConfigResponse> GetRegistrationConfigAsync(GetRegistrationConfigRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetRegistrationConfigResponse>("/cgi-bin/meeting/get_registration_config", request, ct);

    /// <summary>
    /// 获取成员报名ID。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98783
    /// </summary>
    public async Task<GetMemberRegistrationIdResponse> GetMemberRegistrationIdAsync(GetMemberRegistrationIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMemberRegistrationIdResponse>("/cgi-bin/meeting/get_member_registration_id", request, ct);

    /// <summary>
    /// 获取报名信息。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98784
    /// </summary>
    public async Task<GetRegistrationInfoResponse> GetRegistrationInfoAsync(GetRegistrationInfoRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetRegistrationInfoResponse>("/cgi-bin/meeting/get_registration_info", request, ct);

    /// <summary>
    /// 审批报名。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98785
    /// </summary>
    public async Task ApproveRegistrationAsync(ApproveRegistrationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/approve_registration", request, ct);

    /// <summary>
    /// 批量导入报名。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98786
    /// </summary>
    public async Task<ImportRegistrationResponse> ImportRegistrationAsync(ImportRegistrationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ImportRegistrationResponse>("/cgi-bin/meeting/import_registration", request, ct);

    /// <summary>
    /// 删除报名。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98787
    /// </summary>
    public async Task DeleteRegistrationAsync(DeleteRegistrationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/delete_registration", request, ct);

    #endregion

    #region In-Meeting Control

    /// <summary>
    /// 管理会议设置（如等候室、主持人密码等）。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98800
    /// </summary>
    public async Task<ManageMeetingSettingsResponse> ManageMeetingSettingsAsync(ManageMeetingSettingsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ManageMeetingSettingsResponse>("/cgi-bin/meeting/update_meeting_settings", request, ct);

    /// <summary>
    /// 管理联席主持人。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98801
    /// </summary>
    public async Task<ManageCoHostResponse> ManageCoHostAsync(ManageCoHostRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ManageCoHostResponse>("/cgi-bin/meeting/manage_co_host", request, ct);

    /// <summary>
    /// 静音参会成员。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98802
    /// </summary>
    public async Task<MuteMemberResponse> MuteMemberAsync(MuteMemberRequest request, CancellationToken ct = default)
        => await _http.PostAsync<MuteMemberResponse>("/cgi-bin/meeting/mute_member", request, ct);

    /// <summary>
    /// 管理摄像头（开启/关闭成员视频）。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98803
    /// </summary>
    public async Task<ManageVideoResponse> ManageVideoAsync(ManageVideoRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ManageVideoResponse>("/cgi-bin/meeting/manage_video", request, ct);

    /// <summary>
    /// 停止屏幕共享。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98804
    /// </summary>
    public async Task<StopScreenShareResponse> StopScreenShareAsync(StopScreenShareRequest request, CancellationToken ct = default)
        => await _http.PostAsync<StopScreenShareResponse>("/cgi-bin/meeting/stop_screen_share", request, ct);

    /// <summary>
    /// 更新参会者昵称。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98805
    /// </summary>
    public async Task UpdateMemberNicknameAsync(UpdateMemberNicknameRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/update_member_nickname", request, ct);

    /// <summary>
    /// 管理等候室成员（允许/拒绝入会）。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98806
    /// </summary>
    public async Task<ManageWaitRoomMembersResponse> ManageWaitRoomMembersAsync(ManageWaitRoomMembersRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ManageWaitRoomMembersResponse>("/cgi-bin/meeting/manage_wait_room_members", request, ct);

    /// <summary>
    /// 移出会议成员。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98807
    /// </summary>
    public async Task<RemoveMeetingMemberResponse> RemoveMeetingMemberAsync(RemoveMeetingMemberRequest request, CancellationToken ct = default)
        => await _http.PostAsync<RemoveMeetingMemberResponse>("/cgi-bin/meeting/remove_member", request, ct);

    /// <summary>
    /// 结束会议。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98808
    /// </summary>
    public async Task EndMeetingAsync(EndMeetingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/end_meeting", request, ct);

    /// <summary>
    /// 创建会议投票。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98809
    /// </summary>
    public async Task<CreateMeetingVoteResponse> CreateMeetingVoteAsync(CreateMeetingVoteRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateMeetingVoteResponse>("/cgi-bin/meeting/create_vote", request, ct);

    /// <summary>
    /// 修改会议投票。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98810
    /// </summary>
    public async Task<ModifyMeetingVoteResponse> ModifyMeetingVoteAsync(ModifyMeetingVoteRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ModifyMeetingVoteResponse>("/cgi-bin/meeting/modify_vote", request, ct);

    /// <summary>
    /// 获取会议投票列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98811
    /// </summary>
    public async Task<GetMeetingVoteListResponse> GetMeetingVoteListAsync(GetMeetingVoteListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMeetingVoteListResponse>("/cgi-bin/meeting/get_vote_list", request, ct);

    /// <summary>
    /// 获取会议投票详情。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98812
    /// </summary>
    public async Task<GetMeetingVoteDetailResponse> GetMeetingVoteDetailAsync(GetMeetingVoteDetailRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMeetingVoteDetailResponse>("/cgi-bin/meeting/get_vote_detail", request, ct);

    /// <summary>
    /// 获取会议投票信息。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98813
    /// </summary>
    public async Task<GetMeetingVoteInfoResponse> GetMeetingVoteInfoAsync(GetMeetingVoteInfoRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMeetingVoteInfoResponse>("/cgi-bin/meeting/get_vote_info", request, ct);

    /// <summary>
    /// 删除会议投票。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98814
    /// </summary>
    public async Task DeleteMeetingVoteAsync(DeleteMeetingVoteRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/delete_vote", request, ct);

    /// <summary>
    /// 发起会议投票。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98815
    /// </summary>
    public async Task<InitiateMeetingVoteResponse> InitiateMeetingVoteAsync(InitiateMeetingVoteRequest request, CancellationToken ct = default)
        => await _http.PostAsync<InitiateMeetingVoteResponse>("/cgi-bin/meeting/initiate_vote", request, ct);

    /// <summary>
    /// 结束会议投票。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98816
    /// </summary>
    public async Task EndMeetingVoteAsync(EndMeetingVoteRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/end_vote", request, ct);

    #endregion

    #region Webinar

    /// <summary>
    /// 创建网络研讨会（Webinar）。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98820
    /// </summary>
    public async Task<CreateWebinarResponse> CreateWebinarAsync(CreateWebinarRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateWebinarResponse>("/cgi-bin/meeting/webinar_create", request, ct);

    /// <summary>
    /// 修改网络研讨会。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98821
    /// </summary>
    public async Task<ModifyWebinarResponse> ModifyWebinarAsync(ModifyWebinarRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ModifyWebinarResponse>("/cgi-bin/meeting/webinar_update", request, ct);

    /// <summary>
    /// 取消网络研讨会。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98822
    /// </summary>
    public async Task CancelWebinarAsync(CancelWebinarRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/webinar_cancel", request, ct);

    /// <summary>
    /// 获取网络研讨会详情。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98823
    /// </summary>
    public async Task<GetWebinarDetailResponse> GetWebinarDetailAsync(GetWebinarDetailRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetWebinarDetailResponse>("/cgi-bin/meeting/webinar_get_info", request, ct);

    /// <summary>
    /// 获取网络研讨会嘉宾列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98824
    /// </summary>
    public async Task<GetWebinarGuestListResponse> GetWebinarGuestListAsync(GetWebinarGuestListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetWebinarGuestListResponse>("/cgi-bin/meeting/webinar_get_guest_list", request, ct);

    /// <summary>
    /// 更新网络研讨会嘉宾列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98825
    /// </summary>
    public async Task UpdateWebinarGuestListAsync(UpdateWebinarGuestListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/webinar_update_guest_list", request, ct);

    /// <summary>
    /// 管理网络研讨会暖场配置。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98826
    /// </summary>
    public async Task<ManageWebinarWarmupConfigResponse> ManageWebinarWarmupConfigAsync(ManageWebinarWarmupConfigRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ManageWebinarWarmupConfigResponse>("/cgi-bin/meeting/webinar_manage_warmup_config", request, ct);

    /// <summary>
    /// 更新网络研讨会报名配置。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98827
    /// </summary>
    public async Task UpdateWebinarRegistrationConfigAsync(UpdateWebinarRegistrationConfigRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/webinar_update_registration_config", request, ct);

    /// <summary>
    /// 获取网络研讨会报名配置。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98828
    /// </summary>
    public async Task<GetWebinarRegistrationConfigResponse> GetWebinarRegistrationConfigAsync(GetWebinarRegistrationConfigRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetWebinarRegistrationConfigResponse>("/cgi-bin/meeting/webinar_get_registration_config", request, ct);

    /// <summary>
    /// 获取网络研讨会成员报名ID。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98829
    /// </summary>
    public async Task<GetWebinarMemberRegistrationIdResponse> GetWebinarMemberRegistrationIdAsync(GetWebinarMemberRegistrationIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetWebinarMemberRegistrationIdResponse>("/cgi-bin/meeting/webinar_get_member_registration_id", request, ct);

    /// <summary>
    /// 获取网络研讨会报名信息。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98830
    /// </summary>
    public async Task<GetWebinarRegistrationInfoResponse> GetWebinarRegistrationInfoAsync(GetWebinarRegistrationInfoRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetWebinarRegistrationInfoResponse>("/cgi-bin/meeting/webinar_get_registration_info", request, ct);

    /// <summary>
    /// 审批网络研讨会报名。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98831
    /// </summary>
    public async Task ApproveWebinarRegistrationAsync(ApproveWebinarRegistrationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/webinar_approve_registration", request, ct);

    /// <summary>
    /// 批量导入网络研讨会报名。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98832
    /// </summary>
    public async Task<ImportWebinarRegistrationResponse> ImportWebinarRegistrationAsync(ImportWebinarRegistrationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ImportWebinarRegistrationResponse>("/cgi-bin/meeting/webinar_import_registration", request, ct);

    /// <summary>
    /// 删除网络研讨会报名。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98833
    /// </summary>
    public async Task DeleteWebinarRegistrationAsync(DeleteWebinarRegistrationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/webinar_delete_registration", request, ct);

    #endregion

    #region Rooms

    /// <summary>
    /// 预订会议室。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98840
    /// </summary>
    public async Task<ReserveRoomsResponse> ReserveRoomsAsync(ReserveRoomsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ReserveRoomsResponse>("/cgi-bin/meeting/rooms_reserve", request, ct);

    /// <summary>
    /// 释放会议室。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98841
    /// </summary>
    public async Task ReleaseRoomsAsync(ReleaseRoomsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/rooms_release", request, ct);

    /// <summary>
    /// 获取会议室列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98842
    /// </summary>
    public async Task<GetRoomsListResponse> GetRoomsListAsync(GetRoomsListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetRoomsListResponse>("/cgi-bin/meeting/rooms_get_list", request, ct);

    /// <summary>
    /// 获取会议室详情。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98843
    /// </summary>
    public async Task<GetRoomsDetailResponse> GetRoomsDetailAsync(GetRoomsDetailRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetRoomsDetailResponse>("/cgi-bin/meeting/rooms_get_detail", request, ct);

    /// <summary>
    /// 获取会议室配置。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98844
    /// </summary>
    public async Task<GetRoomsConfigResponse> GetRoomsConfigAsync(GetRoomsConfigRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetRoomsConfigResponse>("/cgi-bin/meeting/rooms_get_config", request, ct);

    /// <summary>
    /// 获取会议室当前会议列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98845
    /// </summary>
    public async Task<GetRoomsMeetingListResponse> GetRoomsMeetingListAsync(GetRoomsMeetingListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetRoomsMeetingListResponse>("/cgi-bin/meeting/rooms_get_meeting_list", request, ct);

    /// <summary>
    /// 获取会议室设备列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98846
    /// </summary>
    public async Task<GetDeviceListResponse> GetDeviceListAsync(GetDeviceListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetDeviceListResponse>("/cgi-bin/meeting/rooms_get_device_list", request, ct);

    /// <summary>
    /// 获取会议室控制器列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98847
    /// </summary>
    public async Task<GetControllerListResponse> GetControllerListAsync(GetControllerListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetControllerListResponse>("/cgi-bin/meeting/rooms_get_controller_list", request, ct);

    /// <summary>
    /// 获取会议室可用资源。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98848
    /// </summary>
    public async Task<GetRoomsResourceResponse> GetRoomsResourceAsync(GetRoomsResourceRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetRoomsResourceResponse>("/cgi-bin/meeting/rooms_get_resource", request, ct);

    /// <summary>
    /// 呼叫会议室。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98849
    /// </summary>
    public async Task<CallRoomsResponse> CallRoomsAsync(CallRoomsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CallRoomsResponse>("/cgi-bin/meeting/rooms_call", request, ct);

    /// <summary>
    /// 取消呼叫会议室。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98850
    /// </summary>
    public async Task CancelCallRoomsAsync(CancelCallRoomsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/rooms_cancel_call", request, ct);

    /// <summary>
    /// 获取会议室应答状态。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98851
    /// </summary>
    public async Task<GetRoomsAnswerStatusResponse> GetRoomsAnswerStatusAsync(GetRoomsAnswerStatusRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetRoomsAnswerStatusResponse>("/cgi-bin/meeting/rooms_get_answer_status", request, ct);

    /// <summary>
    /// 获取MRA设备状态。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98852
    /// </summary>
    public async Task<GetMRAStatusResponse> GetMRAStatusAsync(GetMRAStatusRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMRAStatusResponse>("/cgi-bin/meeting/rooms_get_mra_status", request, ct);

    /// <summary>
    /// 切换MRA布局。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98853
    /// </summary>
    public async Task<SwitchMRALayoutResponse> SwitchMRALayoutAsync(SwitchMRALayoutRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SwitchMRALayoutResponse>("/cgi-bin/meeting/rooms_switch_mra_layout", request, ct);

    /// <summary>
    /// 设置MRA举手状态。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98854
    /// </summary>
    public async Task<SetMRAHandRaiseResponse> SetMRAHandRaiseAsync(SetMRAHandRaiseRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SetMRAHandRaiseResponse>("/cgi-bin/meeting/rooms_set_mra_hand_raise", request, ct);

    /// <summary>
    /// 挂断MRA。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98855
    /// </summary>
    public async Task HangUpMRAAsync(HangUpMRARequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/rooms_hangup_mra", request, ct);

    #endregion

    #region Layout & Background

    /// <summary>
    /// 获取布局模版列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98860
    /// </summary>
    public async Task<GetLayoutTemplateListResponse> GetLayoutTemplateListAsync(GetLayoutTemplateListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetLayoutTemplateListResponse>("/cgi-bin/meeting/get_layout_template_list", request, ct);

    /// <summary>
    /// 添加基础布局。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98861
    /// </summary>
    public async Task<AddBasicLayoutResponse> AddBasicLayoutAsync(AddBasicLayoutRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddBasicLayoutResponse>("/cgi-bin/meeting/add_basic_layout", request, ct);

    /// <summary>
    /// 添加高级布局。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98862
    /// </summary>
    public async Task<AddAdvancedLayoutResponse> AddAdvancedLayoutAsync(AddAdvancedLayoutRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddAdvancedLayoutResponse>("/cgi-bin/meeting/add_advanced_layout", request, ct);

    /// <summary>
    /// 修改基础布局。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98863
    /// </summary>
    public async Task ModifyBasicLayoutAsync(ModifyBasicLayoutRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/modify_basic_layout", request, ct);

    /// <summary>
    /// 修改高级布局。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98864
    /// </summary>
    public async Task ModifyAdvancedLayoutAsync(ModifyAdvancedLayoutRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/modify_advanced_layout", request, ct);

    /// <summary>
    /// 设置默认布局。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98865
    /// </summary>
    public async Task SetDefaultLayoutAsync(SetDefaultLayoutRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/set_default_layout", request, ct);

    /// <summary>
    /// 设置高级布局。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98866
    /// </summary>
    public async Task SetAdvancedLayoutAsync(SetAdvancedLayoutRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/set_advanced_layout", request, ct);

    /// <summary>
    /// 获取会议布局列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98867
    /// </summary>
    public async Task<GetMeetingLayoutListResponse> GetMeetingLayoutListAsync(GetMeetingLayoutListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMeetingLayoutListResponse>("/cgi-bin/meeting/get_meeting_layout_list", request, ct);

    /// <summary>
    /// 获取用户布局。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98868
    /// </summary>
    public async Task<GetUserLayoutResponse> GetUserLayoutAsync(GetUserLayoutRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetUserLayoutResponse>("/cgi-bin/meeting/get_user_layout", request, ct);

    /// <summary>
    /// 批量删除布局。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98869
    /// </summary>
    public async Task BatchDeleteLayoutAsync(BatchDeleteLayoutRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/batch_delete_layout", request, ct);

    /// <summary>
    /// 添加会议背景。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98870
    /// </summary>
    public async Task<AddMeetingBackgroundResponse> AddMeetingBackgroundAsync(AddMeetingBackgroundRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddMeetingBackgroundResponse>("/cgi-bin/meeting/add_meeting_background", request, ct);

    /// <summary>
    /// 设置默认背景。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98871
    /// </summary>
    public async Task SetDefaultBackgroundAsync(SetDefaultBackgroundRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/set_default_background", request, ct);

    /// <summary>
    /// 获取会议背景列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98872
    /// </summary>
    public async Task<GetMeetingBackgroundListResponse> GetMeetingBackgroundListAsync(GetMeetingBackgroundListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMeetingBackgroundListResponse>("/cgi-bin/meeting/get_meeting_background_list", request, ct);

    /// <summary>
    /// 删除会议背景。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98873
    /// </summary>
    public async Task DeleteMeetingBackgroundAsync(DeleteMeetingBackgroundRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/delete_meeting_background", request, ct);

    /// <summary>
    /// 批量删除会议背景。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98874
    /// </summary>
    public async Task BatchDeleteBackgroundAsync(BatchDeleteBackgroundRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/batch_delete_background", request, ct);

    #endregion

    #region Recording

    /// <summary>
    /// 获取会议录制列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98880
    /// </summary>
    public async Task<GetRecordingListResponse> GetRecordingListAsync(GetRecordingListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetRecordingListResponse>("/cgi-bin/meeting/get_recording_list", request, ct);

    /// <summary>
    /// 获取会议录制访问统计。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98881
    /// </summary>
    public async Task<GetRecordingAccessStatResponse> GetRecordingAccessStatAsync(GetRecordingAccessStatRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetRecordingAccessStatResponse>("/cgi-bin/meeting/get_recording_access_stat", request, ct);

    /// <summary>
    /// 修改会议录制共享设置。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98882
    /// </summary>
    public async Task ModifyRecordingShareAsync(ModifyRecordingShareRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/modify_recording_share", request, ct);

    /// <summary>
    /// 删除会议录制。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98883
    /// </summary>
    public async Task DeleteRecordingAsync(DeleteRecordingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/delete_recording", request, ct);

    /// <summary>
    /// 获取会议录制下载链接。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98884
    /// </summary>
    public async Task<GetRecordingDownloadUrlResponse> GetRecordingDownloadUrlAsync(GetRecordingDownloadUrlRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetRecordingDownloadUrlResponse>("/cgi-bin/meeting/get_recording_download_url", request, ct);

    #endregion

    #region PSTN

    /// <summary>
    /// 批量发起PSTN电话外呼。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98890
    /// </summary>
    public async Task<BatchCallResponse> BatchCallAsync(BatchCallRequest request, CancellationToken ct = default)
        => await _http.PostAsync<BatchCallResponse>("/cgi-bin/meeting/pstn_batch_call", request, ct);

    /// <summary>
    /// 获取PSTN批量呼叫状态。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98891
    /// </summary>
    public async Task<GetBatchCallStatusResponse> GetBatchCallStatusAsync(GetBatchCallStatusRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetBatchCallStatusResponse>("/cgi-bin/meeting/pstn_get_batch_call_status", request, ct);

    /// <summary>
    /// 获取PSTN成员ID。
    /// 文档：https://developer.work.weixin.qq.com/document/path/98892
    /// </summary>
    public async Task<GetPSTNMemberIdResponse> GetPSTNMemberIdAsync(GetPSTNMemberIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetPSTNMemberIdResponse>("/cgi-bin/meeting/pstn_get_member_id", request, ct);

    #endregion
}
