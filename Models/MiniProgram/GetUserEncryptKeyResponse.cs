using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 获取用户 encryptKey 响应
/// </summary>
public class GetUserEncryptKeyResponse : WechatBaseResponse
{
    /// <summary>加密 key 列表</summary>
    [JsonPropertyName("key_info_list")] public List<UserEncryptKeyInfo>? KeyInfoList { get; set; }
}

