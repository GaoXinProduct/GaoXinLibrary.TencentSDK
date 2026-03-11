using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

/// <summary>
/// 读取成员直接响应
/// <para>
/// ⚠ 自 2022-06-20 起，除通讯录同步以外的基础应用及新建自建应用，
/// 以下字段不再返回：<c>avatar</c>、<c>thumb_avatar</c>、<c>gender</c>、
/// <c>mobile</c>、<c>email</c>、<c>biz_mail</c>、<c>qr_code</c>、<c>address</c>。
/// 需通过 OAuth2 手工授权获取，参见
/// <see href="https://developer.work.weixin.qq.com/document/path/95833">获取访问用户敏感信息</see>。
/// </para>
/// </summary>
public class GetUserDirectResponse : WecomBaseResponse
{
    [JsonPropertyName("userid")] public string? UserId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("alias")] public string? Alias { get; set; }

    /// <summary>
    /// 手机号码。自 2022-06-20 起，非通讯录同步应用不再返回。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("mobile")] public string? Mobile { get; set; }

    [JsonPropertyName("department")] public int[]? Department { get; set; }
    [JsonPropertyName("position")] public string? Position { get; set; }

    /// <summary>
    /// 性别。自 2022-06-20 起，非通讯录同步应用不再返回。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("gender")] public string? Gender { get; set; }

    /// <summary>
    /// 邮箱。自 2022-06-20 起，非通讯录同步应用不再返回。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("email")] public string? Email { get; set; }

    /// <summary>
    /// 企业邮箱。自 2022-06-20 起，非通讯录同步应用不再返回。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("biz_mail")] public string? BizMail { get; set; }

    /// <summary>
    /// 头像url。自 2022-06-20 起，非通讯录同步应用不再返回。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("avatar")] public string? Avatar { get; set; }

    /// <summary>
    /// 头像缩略图url。自 2022-06-20 起，非通讯录同步应用不再返回。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("thumb_avatar")] public string? ThumbAvatar { get; set; }

    [JsonPropertyName("telephone")] public string? Telephone { get; set; }

    /// <summary>
    /// 地址。自 2022-06-20 起，非通讯录同步应用不再返回。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("address")] public string? Address { get; set; }

    [JsonPropertyName("open_userid")] public string? OpenUserId { get; set; }
    [JsonPropertyName("main_department")] public int MainDepartment { get; set; }
    [JsonPropertyName("status")] public int Status { get; set; }

    /// <summary>
    /// 员工个人二维码。自 2022-06-20 起，非通讯录同步应用不再返回。
    /// </summary>
    [Obsolete("自 2022-06-20 起，非通讯录同步应用不再返回此字段，需通过 OAuth2 授权获取（getuserdetail）。")]
    [JsonPropertyName("qr_code")] public string? QrCode { get; set; }

    [JsonPropertyName("enable")] public int Enable { get; set; }
    [JsonPropertyName("english_name")] public string? EnglishName { get; set; }
    [JsonPropertyName("direct_leader")] public string[]? DirectLeader { get; set; }
    [JsonPropertyName("hide_mobile")] public int HideMobile { get; set; }

    public UserInfo ToUserInfo() => new()
    {
        UserId = UserId ?? string.Empty,
        Name = Name,
        Alias = Alias,
        Mobile = Mobile,
        Department = Department,
        Position = Position,
        Gender = Gender,
        Email = Email,
        BizMail = BizMail,
        Avatar = Avatar,
        ThumbAvatar = ThumbAvatar,
        Telephone = Telephone,
        Address = Address,
        OpenUserId = OpenUserId,
        MainDepartment = MainDepartment,
        Status = Status,
        QrCode = QrCode,
        Enable = Enable,
        EnglishName = EnglishName,
        DirectLeader = DirectLeader,
        HideMobile = HideMobile
    };
}

