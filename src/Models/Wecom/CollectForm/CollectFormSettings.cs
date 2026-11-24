namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>收集表的填写范围、管理员和定时设置。</summary>
public sealed class CollectFormSettings
{
    /// <summary>填写权限，0 为所有人，1 为指定成员或部门，4 为家校范围。</summary>
    [JsonPropertyName("fill_out_auth")] public uint? FillOutAuth { get; set; }
    /// <summary>可填写的成员和部门。</summary>
    [JsonPropertyName("fill_in_range")] public CollectFormMemberRange? FillInRange { get; set; }
    /// <summary>收集表管理员。</summary>
    [JsonPropertyName("setting_manager_range")] public CollectFormMemberRange? ManagerRange { get; set; }
    /// <summary>周期填写设置。</summary>
    [JsonPropertyName("timed_repeat_info")] public CollectFormRepeatSettings? RepeatSettings { get; set; }
    /// <summary>每人是否可提交多份。</summary>
    [JsonPropertyName("allow_multi_fill")] public bool? AllowMultipleSubmissions { get; set; }
    /// <summary>定时关闭的 Unix 时间戳。</summary>
    [JsonPropertyName("timed_finish")] public uint? TimedFinish { get; set; }
    /// <summary>是否允许匿名填写。</summary>
    [JsonPropertyName("can_anonymous")] public bool? AllowAnonymous { get; set; }
    /// <summary>是否在提交时提醒。</summary>
    [JsonPropertyName("can_notify_submit")] public bool? NotifyOnSubmission { get; set; }
}

/// <summary>收集表的成员范围。</summary>
public sealed class CollectFormMemberRange
{
    /// <summary>成员 userid 列表。</summary>
    [JsonPropertyName("userids")] public string[]? UserIds { get; set; }
    /// <summary>部门 ID 列表。</summary>
    [JsonPropertyName("departmentids")] public ulong[]? DepartmentIds { get; set; }
}

/// <summary>收集表的定时重复设置。</summary>
public sealed class CollectFormRepeatSettings
{
    /// <summary>是否启用定时重复。</summary>
    [JsonPropertyName("enable")] public bool? Enabled { get; set; }
    /// <summary>首次提醒的 Unix 时间戳。</summary>
    [JsonPropertyName("remind_time")] public uint? RemindTime { get; set; }
    /// <summary>重复类型，0 为每周，1 为每天，2 为每月。</summary>
    [JsonPropertyName("repeat_type")] public uint? RepeatType { get; set; }
    /// <summary>每周重复日的位掩码。</summary>
    [JsonPropertyName("week_flag")] public uint? WeekFlag { get; set; }
    /// <summary>每天重复时是否跳过节假日。</summary>
    [JsonPropertyName("skip_holiday")] public bool? SkipHoliday { get; set; }
    /// <summary>每月重复日期。</summary>
    [JsonPropertyName("day_of_month")] public uint? DayOfMonth { get; set; }
    /// <summary>补填期限。</summary>
    [JsonPropertyName("fork_finish_type")] public uint? ForkFinishType { get; set; }
}
