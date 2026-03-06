using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

public class GetUserIdListResponse : WecomBaseResponse
{
    /// <summary>成员userid与部门id关联列表</summary>
    [JsonPropertyName("dept_user")] public DeptUser[]? DeptUser { get; set; }

    /// <summary>分页游标，下次调用时传入</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
}

