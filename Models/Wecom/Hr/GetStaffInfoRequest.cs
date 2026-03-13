using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Hr;

/// <summary>获取员工信息请求</summary>
public class GetStaffInfoRequest
{
    /// <summary>用户 userid 列表</summary>
    [JsonPropertyName("userid_list")]
    public string[] UserIdList { get; set; } = [];
}
