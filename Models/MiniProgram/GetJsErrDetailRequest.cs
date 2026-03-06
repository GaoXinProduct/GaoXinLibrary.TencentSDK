using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 查询JS错误详情请求（POST /wxaapi/log/jserr_detail）
/// </summary>
public class GetJsErrDetailRequest
{
    /// <summary>开始时间戳（Unix 秒）</summary>
    [JsonPropertyName("startTime")]   public long StartTime { get; set; }
    /// <summary>结束时间戳（Unix 秒）</summary>
    [JsonPropertyName("endTime")]     public long EndTime { get; set; }
    /// <summary>错误信息（JS 错误的 errMsg）</summary>
    [JsonPropertyName("errMsg")]      public string? ErrMsg { get; set; }
    /// <summary>小程序版本号（可选）</summary>
    [JsonPropertyName("version")]     public string? Version { get; set; }
    /// <summary>操作系统（"0" 全部；"1" iOS；"2" Android；"3" DevTools）</summary>
    [JsonPropertyName("osName")]      public string OsName { get; set; } = "0";
    /// <summary>排序方式（"0" 升序；"1" 降序）</summary>
    [JsonPropertyName("desc")]        public string Desc { get; set; } = "0";
    /// <summary>分页起始</summary>
    [JsonPropertyName("start")]       public int Start { get; set; }
    /// <summary>每页条数（最大 100）</summary>
    [JsonPropertyName("limit")]       public int Limit { get; set; } = 20;
}
