using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>获取客服账号列表响应</summary>
public sealed class KfAccountListResponse : WecomBaseResponse
{
    /// <summary>客服账号列表</summary>
    [JsonPropertyName("account_list")] public KfAccount[]? AccountList { get; set; }
}

