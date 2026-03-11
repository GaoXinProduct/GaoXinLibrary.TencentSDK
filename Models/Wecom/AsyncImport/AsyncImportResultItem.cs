using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.AsyncImport;

/// <summary>异步导入结果项</summary>
public class AsyncImportResultItem
{
    /// <summary>成员UserID/部门ID</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>操作类型（按需设定，如 1-新增，2-修改，3-删除）</summary>
    [JsonPropertyName("action")] public int Action { get; set; }

    /// <summary>错误码</summary>
    [JsonPropertyName("errcode")] public int ErrCode { get; set; }

    /// <summary>错误信息</summary>
    [JsonPropertyName("errmsg")] public string? ErrMsg { get; set; }
}
