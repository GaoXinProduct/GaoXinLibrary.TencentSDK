using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>删除标签请求（POST /cgi-bin/tags/delete）</summary>
public sealed class DeleteTagRequest
{
    [JsonPropertyName("tag")] public required TagItem Tag { get; set; }
}

