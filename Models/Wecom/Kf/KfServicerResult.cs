using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>接待人员操作结果</summary>
public class KfServicerResult
{
    /// <summary>接待人员 userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>接待人员部门 id</summary>
    [JsonPropertyName("department_id")] public int? DepartmentId { get; set; }

    /// <summary>错误码，0 表示成功</summary>
    [JsonPropertyName("errcode")] public int ErrCode { get; set; }

    /// <summary>错误信息</summary>
    [JsonPropertyName("errmsg")] public string? ErrMsg { get; set; }
}

