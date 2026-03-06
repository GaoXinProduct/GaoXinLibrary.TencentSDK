using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>添加打卡规则响应</summary>
public class AddCheckinOptionResponse : WecomBaseResponse
{
    /// <summary>新增打卡规则 id</summary>
    [JsonPropertyName("id")] public int Id { get; set; }
}

