using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>删除模板请求（POST /cgi-bin/template/del_private_template）</summary>
public class DeleteTemplateRequest
{
    [JsonPropertyName("template_id")] public required string TemplateId { get; set; }
}

