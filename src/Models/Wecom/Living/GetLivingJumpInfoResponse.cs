using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Living;

/// <summary>获取跳转小程序商城的直播观众信息响应</summary>
public class GetLivingJumpInfoResponse : WecomBaseResponse
{
    /// <summary>观众跳转信息</summary>
    [JsonPropertyName("jump_info")]
    public LivingJumpInfo? JumpInfo { get; set; }
}

/// <summary>观众跳转信息</summary>
public class LivingJumpInfo
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    /// <summary>跳转路径</summary>
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    /// <summary>跳转参数</summary>
    [JsonPropertyName("params")]
    public string? Params { get; set; }
}