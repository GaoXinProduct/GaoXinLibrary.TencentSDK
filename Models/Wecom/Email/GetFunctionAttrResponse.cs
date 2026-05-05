using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>获取用户功能属性响应</summary>
/// <remarks>文档路径: /document/path/95513</remarks>
public class GetFunctionAttrResponse : WecomBaseResponse
{
    /// <summary>功能属性，1=邮件，2=日程，3=联系人</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>属性值</summary>
    [JsonPropertyName("value")]
    public int Value { get; set; }
}