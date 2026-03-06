using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>联系人-成员</summary>
public class ApplyMember
{
    /// <summary>成员 userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>成员名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }
}

