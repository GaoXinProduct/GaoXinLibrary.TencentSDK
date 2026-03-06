using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取模板列表响应（GET /cgi-bin/template/get_all_private_template）</summary>
public class GetTemplateListResponse : WechatBaseResponse
{
    [JsonPropertyName("template_list")] public List<TemplateInfo>? TemplateList { get; set; }
}

