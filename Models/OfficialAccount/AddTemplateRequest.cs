using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取模板 ID 请求（POST /cgi-bin/template/api_add_template）</summary>
public class AddTemplateRequest
{
    /// <summary>模板库中模板的编号</summary>
    [JsonPropertyName("template_id_short")] public required string TemplateIdShort { get; set; }
    /// <summary>关键词排列顺序（可选）</summary>
    [JsonPropertyName("keyword_name_list")] public List<string>? KeywordNameList { get; set; }
}

