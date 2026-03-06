using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

public class GetUserDirectResponse : WecomBaseResponse
{
    [JsonPropertyName("userid")] public string? UserId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("alias")] public string? Alias { get; set; }
    [JsonPropertyName("mobile")] public string? Mobile { get; set; }
    [JsonPropertyName("department")] public int[]? Department { get; set; }
    [JsonPropertyName("position")] public string? Position { get; set; }
    [JsonPropertyName("gender")] public string? Gender { get; set; }
    [JsonPropertyName("email")] public string? Email { get; set; }
    [JsonPropertyName("biz_mail")] public string? BizMail { get; set; }
    [JsonPropertyName("avatar")] public string? Avatar { get; set; }
    [JsonPropertyName("thumb_avatar")] public string? ThumbAvatar { get; set; }
    [JsonPropertyName("telephone")] public string? Telephone { get; set; }
    [JsonPropertyName("address")] public string? Address { get; set; }
    [JsonPropertyName("open_userid")] public string? OpenUserId { get; set; }
    [JsonPropertyName("main_department")] public int MainDepartment { get; set; }
    [JsonPropertyName("status")] public int Status { get; set; }
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

