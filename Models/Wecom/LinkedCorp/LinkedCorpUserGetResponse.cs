using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

/// <summary>获取互联企业成员详细信息响应</summary>
public class LinkedCorpUserGetResponse : WecomBaseResponse
{
    /// <summary>成员详细信息</summary>
    [JsonPropertyName("user_info")] public LinkedCorpUser? UserInfo { get; set; }
}

