using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>图片消息</summary>
public class CallbackImageMessage : CallbackMessageBase
{
    /// <summary>消息 ID</summary>
    public long MsgId { get; set; }

    /// <summary>图片链接（由系统生成）</summary>
    public string PicUrl { get; set; } = string.Empty;

    /// <summary>图片媒体文件 ID（可调用获取临时素材接口拉取数据）</summary>
    public string MediaId { get; set; } = string.Empty;
}

