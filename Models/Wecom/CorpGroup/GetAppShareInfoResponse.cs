using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpGroup;

/// <summary>获取应用共享信息响应</summary>
public class GetAppShareInfoResponse : WecomBaseResponse
{
    /// <summary>下级/下游企业的应用共享信息列表</summary>
    [JsonPropertyName("corp_list")] public SharedCorpInfo[]? CorpList { get; set; }
}

