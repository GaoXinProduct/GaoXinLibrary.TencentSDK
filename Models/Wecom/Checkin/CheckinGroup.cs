using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>打卡规则</summary>
public class CheckinGroup
{
    /// <summary>打卡规则类型，1：固定时间上下班；2：按班次上下班；3：自由上下班</summary>
    [JsonPropertyName("grouptype")] public int GroupType { get; set; }

    /// <summary>打卡规则 id</summary>
    [JsonPropertyName("groupid")] public int GroupId { get; set; }

    /// <summary>打卡规则名称</summary>
    [JsonPropertyName("groupname")] public string? GroupName { get; set; }

    /// <summary>是否开启审批打卡</summary>
    [JsonPropertyName("open_sp_checkin")] public bool? OpenSpCheckin { get; set; }

    /// <summary>打卡时间配置，当规则类型为排班时没有意义</summary>
    [JsonPropertyName("checkindate")] public CheckinDate[]? CheckinDate { get; set; }

    /// <summary>特殊日期-必须打卡日期信息</summary>
    [JsonPropertyName("spe_workdays")] public SpeDay[]? SpeWorkdays { get; set; }

    /// <summary>特殊日期-不用打卡日期信息</summary>
    [JsonPropertyName("spe_offdays")] public SpeDay[]? SpeOffdays { get; set; }

    /// <summary>是否同步法定节假日</summary>
    [JsonPropertyName("sync_holidays")] public bool? SyncHolidays { get; set; }

    /// <summary>是否打卡必须拍照</summary>
    [JsonPropertyName("need_photo")] public bool? NeedPhoto { get; set; }

    /// <summary>是否备注时允许上传本地图片</summary>
    [JsonPropertyName("note_can_use_local_pic")] public bool? NoteCanUseLocalPic { get; set; }

    /// <summary>是否非工作日允许打卡</summary>
    [JsonPropertyName("allow_checkin_offworkday")] public bool? AllowCheckinOffworkday { get; set; }

    /// <summary>是否允许提交补卡申请</summary>
    [JsonPropertyName("allow_apply_offworkday")] public bool? AllowApplyOffworkday { get; set; }

    /// <summary>WiFi 打卡信息</summary>
    [JsonPropertyName("wifimac_infos")] public WifiMacInfo[]? WifiMacInfos { get; set; }

    /// <summary>位置打卡信息</summary>
    [JsonPropertyName("loc_infos")] public LocInfo[]? LocInfos { get; set; }

    /// <summary>打卡人员信息</summary>
    [JsonPropertyName("range")] public CheckinRange? Range { get; set; }

    /// <summary>创建打卡规则时间（unix 时间戳）</summary>
    [JsonPropertyName("create_time")] public long? CreateTime { get; set; }

    /// <summary>打卡人员白名单</summary>
    [JsonPropertyName("white_users")] public string[]? WhiteUsers { get; set; }

    /// <summary>打卡方式，0:手机；2:智慧考勤机；3:手机+智慧考勤机</summary>
    [JsonPropertyName("type")] public int? Type { get; set; }

    /// <summary>汇报对象信息</summary>
    [JsonPropertyName("reporterinfo")] public ReporterInfo? ReporterInfo { get; set; }

    /// <summary>加班信息</summary>
    [JsonPropertyName("ot_info")] public OtInfo? OtInfo { get; set; }

    /// <summary>每月最多补卡次数，-1 表示不限制</summary>
    [JsonPropertyName("allow_apply_bk_cnt")] public int? AllowApplyBkCnt { get; set; }

    /// <summary>范围外打卡处理方式，0-异常 1-正常外勤 2-不允许</summary>
    [JsonPropertyName("option_out_range")] public int? OptionOutRange { get; set; }

    /// <summary>规则创建人 userid</summary>
    [JsonPropertyName("create_userid")] public string? CreateUserId { get; set; }

    /// <summary>人脸识别打卡开关</summary>
    [JsonPropertyName("use_face_detect")] public bool? UseFaceDetect { get; set; }

    /// <summary>允许补卡时限（天），-1 表示不限制</summary>
    [JsonPropertyName("allow_apply_bk_day_limit")] public int? AllowApplyBkDayLimit { get; set; }

    /// <summary>规则最近编辑人 userid</summary>
    [JsonPropertyName("update_userid")] public string? UpdateUserId { get; set; }

    /// <summary>排班信息列表</summary>
    [JsonPropertyName("schedulelist")] public ScheduleInfo[]? ScheduleList { get; set; }

    /// <summary>上班打卡后 xx 秒可打下班卡</summary>
    [JsonPropertyName("offwork_interval_time")] public int? OffworkIntervalTime { get; set; }

    /// <summary>打卡交替方式，0-多组交替 1-单组交替 2-仅记录</summary>
    [JsonPropertyName("checkin_method_type")] public int? CheckinMethodType { get; set; }
}

