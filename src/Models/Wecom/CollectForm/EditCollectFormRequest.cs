using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>编辑收集表请求</summary>
public class EditCollectFormRequest
{
    /// <summary>全量修改问题或全量修改设置。</summary>
    [JsonPropertyName("oper")]
    public CollectFormEditOperation Operation { get; set; } = CollectFormEditOperation.Questions;

    /// <summary>收集表 ID</summary>
    [JsonPropertyName("formid")]
    public string FormId { get; set; } = string.Empty;

    /// <summary>按操作类型提供问题或设置。</summary>
    [JsonPropertyName("form_info")]
    public CollectFormInfo FormInfo { get; set; } = new();

    /// <summary>收集表标题。</summary>
    [JsonIgnore]
    public string? Title { get => FormInfo.Title; set => FormInfo.Title = value; }

    /// <summary>收集表描述。</summary>
    [JsonIgnore]
    public string? Description { get => FormInfo.Description; set => FormInfo.Description = value; }

    /// <summary>定时关闭的 Unix 时间戳。请与 <see cref="CollectFormEditOperation.Settings"/> 一起使用。</summary>
    [JsonIgnore]
    public long EndTime { get => FormInfo.EndTime; set => FormInfo.EndTime = value; }
}

/// <summary>收集表修改操作。</summary>
public enum CollectFormEditOperation
{
    /// <summary>全量修改问题。</summary>
    Questions = 1,
    /// <summary>全量修改设置。</summary>
    Settings = 2
}
