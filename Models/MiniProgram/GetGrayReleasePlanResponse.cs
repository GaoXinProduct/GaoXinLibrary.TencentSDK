using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>获取分阶段发布详情响应（GET /wxa/getgrayreleaseplan）</summary>
public class GetGrayReleasePlanResponse : WechatBaseResponse
{
    /// <summary>分阶段发布详情</summary>
    [JsonPropertyName("gray_release_plan")] public GrayReleasePlan? GrayReleasePlan { get; set; }
}

/// <summary>分阶段发布计划</summary>
public class GrayReleasePlan
{
    /// <summary>状态：0=初始未设置 1=正在灰度 2=全量发布</summary>
    [JsonPropertyName("status")]             public int Status { get; set; }
    /// <summary>灰度比例（1-100）</summary>
    [JsonPropertyName("gray_percentage")]    public int GrayPercentage { get; set; }
    /// <summary>灰度版本信息</summary>
    [JsonPropertyName("support_experiencer")] public bool SupportExperiencer { get; set; }
    /// <summary>创建时间戳</summary>
    [JsonPropertyName("create_timestamp")]   public long CreateTimestamp { get; set; }
}
