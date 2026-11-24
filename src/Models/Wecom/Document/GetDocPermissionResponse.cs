using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>获取文档权限响应</summary>
public class GetDocPermissionResponse : WecomBaseResponse
{
    /// <summary>旧版权限信息字段</summary>
    [JsonPropertyName("permission_info")] public DocPermissionInfo? PermissionInfo { get; set; }

    /// <summary>文档加入规则</summary>
    [JsonPropertyName("access_rule")] public DocAccessRule? AccessRule { get; set; }

    /// <summary>文档安全设置</summary>
    [JsonPropertyName("secure_setting")] public DocSecuritySettings? SecureSetting { get; set; }

    /// <summary>文档成员及其权限</summary>
    [JsonPropertyName("doc_member_list")] public DocMemberPermission[]? DocMemberList { get; set; }

    /// <summary>有文档访问权限的部门</summary>
    [JsonPropertyName("co_auth_list")] public DocDepartmentPermission[]? CoAuthList { get; set; }
}
