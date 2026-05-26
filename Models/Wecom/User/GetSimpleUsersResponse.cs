using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

public sealed class GetSimpleUsersResponse : WecomBaseResponse
{
    [JsonPropertyName("userlist")] public SimpleUserInfo[]? UserList { get; set; }
}

