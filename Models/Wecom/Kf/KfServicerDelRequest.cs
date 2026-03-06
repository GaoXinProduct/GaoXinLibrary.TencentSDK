using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>删除接待人员请求</summary>
public class KfServicerDelRequest
{
    /// <summary>客服账号 id</summary>
    [JsonPropertyName("open_kfid")] public string OpenKfId { get; set; } = string.Empty;

    /// <summary>接待人员 userid 列表</summary>
    [JsonPropertyName("userid_list")] public string[]? UserIdList { get; set; }

    /// <summary>接待人员部门 id 列表</summary>
    [JsonPropertyName("department_id_list")] public int[]? DepartmentIdList { get; set; }
}

