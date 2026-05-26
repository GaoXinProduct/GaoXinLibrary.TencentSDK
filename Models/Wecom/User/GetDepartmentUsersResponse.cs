using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

public sealed class GetDepartmentUsersResponse : WecomBaseResponse
{
    [JsonPropertyName("userlist")] public UserInfo[]? UserList { get; set; }
}

