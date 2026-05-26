using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Tag;

#region 响应模型

public sealed class CreateTagResponse : WecomBaseResponse
{
    [JsonPropertyName("tagid")] public int TagId { get; set; }
}

#endregion
