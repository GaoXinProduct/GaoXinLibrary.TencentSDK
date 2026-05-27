using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

/// <summary>批量删除成员请求</summary>
public sealed class BatchDeleteUserRequest
{
    [JsonPropertyName("useridlist")] public string[] UserIdList { get; set; } = [];
}

