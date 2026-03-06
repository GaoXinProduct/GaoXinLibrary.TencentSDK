using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Export;

/// <summary>获取导出结果响应</summary>
public class GetExportResultResponse : WecomBaseResponse
{
    /// <summary>
    /// 任务状态：0-未处理，1-处理中，2-完成，3-异常失败
    /// </summary>
    [JsonPropertyName("status")] public int Status { get; set; }

    /// <summary>导出的数据文件列表（任务完成后可用）</summary>
    [JsonPropertyName("data_list")] public ExportDataItem[]? DataList { get; set; }
}

