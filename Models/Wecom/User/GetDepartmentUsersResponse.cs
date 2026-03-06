using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

public class GetDepartmentUsersResponse : WecomBaseResponse
{
    [JsonPropertyName("userlist")] public UserInfo[]? UserList { get; set; }
}

