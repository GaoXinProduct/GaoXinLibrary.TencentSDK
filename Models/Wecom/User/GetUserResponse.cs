using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

#region 响应模型

public class GetUserResponse : WecomBaseResponse
{
    [JsonPropertyName("user_info")] public UserInfo? UserInfo { get; set; }
}

#endregion
