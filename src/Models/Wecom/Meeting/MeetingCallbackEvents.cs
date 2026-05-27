namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

public enum MeetingCallbackEventType
{
    MeetingStarted,
    MeetingEnded,
    MeetingJoined,
    MeetingLeft,
    MeetingInvite,
    MeetingRejected,
    MeetingCancelled,
    MeetingAlarm,
    MeetingRecord,
    MeetingSipCreated
}

public sealed class MeetingCallbackEvent
{
    public string Event { get; set; } = string.Empty;
    public string MeetingId { get; set; } = string.Empty;
    public long MeetingStartTime { get; set; }
    public long MeetingEndTime { get; set; }
    public string? MeetingTopic { get; set; }
    public string? MeetingCreateTime { get; set; }
    public string? CreatorId { get; set; }
    public List<AttendeeInfo>? Attendees { get; set; }
    public string? RoomId { get; set; }
    public string? RecordFileId { get; set; }
    public string? RecordUrl { get; set; }
}

public sealed class AttendeeInfo
{
    public string? UserId { get; set; }
    public string? NickName { get; set; }
    public int JoinTime { get; set; }
    public int LeaveTime { get; set; }
    public int Duration { get; set; }
}