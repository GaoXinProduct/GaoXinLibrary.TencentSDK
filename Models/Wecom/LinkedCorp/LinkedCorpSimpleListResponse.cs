using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

/// <summary>获取互联企业部门成员简要信息响应</summary>
public class LinkedCorpSimpleListResponse : WecomBaseResponse
{
    /// <summary>成员列表</summary>
    [JsonPropertyName("userlist")] public LinkedCorpSimpleUser[]? UserList { get; set; }
}

