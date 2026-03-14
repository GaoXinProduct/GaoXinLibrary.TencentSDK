namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// 智能机器人长连接 WebSocket 命令常量
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/></para>
/// </summary>
public static class WsCommands
{
    /// <summary>注册/订阅（连接后首先发送）</summary>
    public const string Subscribe = "aibot_subscribe";

    /// <summary>消息回调（用户发送消息到机器人）</summary>
    public const string MsgCallback = "aibot_msg_callback";

    /// <summary>事件回调（enter_chat / template_card_event / feedback_event / disconnected_event）</summary>
    public const string EventCallback = "aibot_event_callback";

    /// <summary>回复欢迎语（收到 enter_chat 事件后 5 秒内回复）</summary>
    public const string RespondWelcomeMsg = "aibot_respond_welcome_msg";

    /// <summary>回复消息（支持流式回复）</summary>
    public const string RespondMsg = "aibot_respond_msg";

    /// <summary>回复更新模版卡片消息</summary>
    public const string RespondUpdateMsg = "aibot_respond_update_msg";

    /// <summary>主动推送消息</summary>
    public const string SendMsg = "aibot_send_msg";

    /// <summary>心跳请求</summary>
    public const string Ping = "ping";

    /// <summary>心跳响应</summary>
    public const string Pong = "pong";

    /// <summary>上传临时素材 - 初始化</summary>
    public const string UploadMediaInit = "aibot_upload_media_init";

    /// <summary>上传临时素材 - 发送分片</summary>
    public const string UploadMediaChunk = "aibot_upload_media_chunk";

    /// <summary>上传临时素材 - 完成上传</summary>
    public const string UploadMediaFinish = "aibot_upload_media_finish";

    /// <summary>回传文档工具调用结果</summary>
    public const string RespondToolResult = "aibot_respond_tool_result";
}
