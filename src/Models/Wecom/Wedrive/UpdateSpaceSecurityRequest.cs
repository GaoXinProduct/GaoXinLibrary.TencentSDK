namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>修改指定空间的安全设置</summary>
/// <remarks>可选字段留空表示保留该设置的原有值。</remarks>
public sealed record UpdateSpaceSecurityRequest
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public required string SpaceId { get; init; }

    /// <summary>是否启用水印</summary>
    [JsonPropertyName("enable_watermark")]
    public bool? EnableWatermark { get; init; }

    /// <summary>是否仅管理员可增减空间成员和修改文件分享设置</summary>
    [JsonPropertyName("add_member_only_admin")]
    public bool? AddMemberOnlyAdmin { get; init; }

    /// <summary>是否启用成员邀请链接</summary>
    [JsonPropertyName("enable_share_url")]
    public bool? EnableShareUrl { get; init; }

    /// <summary>是否允许通过链接加入空间而无需审批</summary>
    [JsonPropertyName("share_url_no_approve")]
    public bool? ShareUrlNoApprove { get; init; }

    /// <summary>邀请链接的默认权限</summary>
    [JsonPropertyName("share_url_no_approve_default_auth")]
    public int? ShareUrlNoApproveDefaultAuth { get; init; }

    /// <summary>是否开启保密模式</summary>
    [JsonPropertyName("enable_confidential_mode")]
    public bool? EnableConfidentialMode { get; init; }

    /// <summary>文件的默认分享范围</summary>
    [JsonPropertyName("default_file_scope")]
    public int? DefaultFileScope { get; init; }

    /// <summary>是否禁止向外部分享</summary>
    [JsonPropertyName("ban_share_external")]
    public bool? BanShareExternal { get; init; }
}
