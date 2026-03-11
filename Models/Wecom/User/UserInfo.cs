using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

// ─── 成员信息 ───────────────────────────────────────────────────────────────

/// <summary>
/// 成员详细信息
/// <para>
/// ⚠ 自 2022-06-20 起，除通讯录同步以外的基础应用及新建自建应用，
/// 调用读取成员/获取部门成员详情接口时，以下字段不再返回：
/// <c>avatar</c>、<c>thumb_avatar</c>、<c>gender</c>、<c>mobile</c>、
/// <c>email</c>、<c>biz_mail</c>、<c>qr_code</c>、<c>address</c>。
/// 需通过 OAuth2 手工授权获取，参见
/// <see href="https://developer.work.weixin.qq.com/document/path/95833">获取访问用户敏感信息</see>。
/// </para>
/// </summary>
public class UserInfo
{
    /// <summary>成员UserID</summary>
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;

    /// <summary>成员名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>别名</summary>
    [JsonPropertyName("alias")] public string? Alias { get; set; }

    /// <summary>
    /// 手机号码。
    /// 自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("mobile")] public string? Mobile { get; set; }

    /// <summary>成员所属部门id列表</summary>
    [JsonPropertyName("department")] public int[]? Department { get; set; }

    /// <summary>部门内的排序值</summary>
    [JsonPropertyName("order")] public int[]? Order { get; set; }

    /// <summary>职务信息</summary>
    [JsonPropertyName("position")] public string? Position { get; set; }

    /// <summary>
    /// 性别。0=未定义，1=男，2=女。
    /// 自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("gender")] public string? Gender { get; set; }

    /// <summary>
    /// 邮箱。
    /// 自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("email")] public string? Email { get; set; }

    /// <summary>
    /// 企业邮箱。
    /// 自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("biz_mail")] public string? BizMail { get; set; }

    /// <summary>是否为部门负责人，0-否；1-是</summary>
    [JsonPropertyName("is_leader_in_dept")] public int[]? IsLeaderInDept { get; set; }

    /// <summary>直属上级UserID</summary>
    [JsonPropertyName("direct_leader")] public string[]? DirectLeader { get; set; }

    /// <summary>
    /// 头像url。
    /// 自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("avatar")] public string? Avatar { get; set; }

    /// <summary>
    /// 头像缩略图url。
    /// 自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("thumb_avatar")] public string? ThumbAvatar { get; set; }

    /// <summary>座机</summary>
    [JsonPropertyName("telephone")] public string? Telephone { get; set; }

    /// <summary>
    /// 地址。
    /// 自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("address")] public string? Address { get; set; }

    /// <summary>全局唯一。仅第三方应用可获取</summary>
    [JsonPropertyName("open_userid")] public string? OpenUserId { get; set; }

    /// <summary>主部门</summary>
    [JsonPropertyName("main_department")] public int MainDepartment { get; set; }

    /// <summary>激活状态: 1=已激活，2=已禁用，4=未激活，5=退出企业</summary>
    [JsonPropertyName("status")] public int Status { get; set; }

    /// <summary>
    /// 员工个人二维码。
    /// 自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("qr_code")] public string? QrCode { get; set; }

    /// <summary>启用/禁用成员</summary>
    [JsonPropertyName("enable")] public int Enable { get; set; }

    /// <summary>是否隐藏手机号</summary>
    [JsonPropertyName("hide_mobile")] public int HideMobile { get; set; }

    /// <summary>英文名</summary>
    [JsonPropertyName("english_name")] public string? EnglishName { get; set; }
}

