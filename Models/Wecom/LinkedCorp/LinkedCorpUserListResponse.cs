using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

/// <summary>获取互联企业部门成员详情响应</summary>
public class LinkedCorpUserListResponse : WecomBaseResponse
{
    /// <summary>成员列表</summary>
    [JsonPropertyName("userlist")] public LinkedCorpUser[]? UserList { get; set; }
}

