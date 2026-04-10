using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Callback;
using GaoXinLibrary.TencentSDK.Wecom.Models.GroupChat;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>智能机器人服务实现</summary>
public class SmartRobotService : ISmartRobotService
{
    private readonly WecomCryptoHelper _crypto;
    private readonly WecomHttpClient _http;

    /// <summary>
    /// 初始化智能机器人服务
    /// </summary>
    /// <param name="http">企业微信 HTTP 客户端</param>
    /// <param name="options">企业微信智能机器人配置（需包含 CallbackToken 和 CallbackEncodingAesKey）</param>
    public SmartRobotService(WecomHttpClient http, WecomOptions options)
    {
        _http = http;

        if (!string.IsNullOrWhiteSpace(options.CallbackToken) &&
            !string.IsNullOrWhiteSpace(options.CallbackEncodingAesKey))
        {
            _crypto = new WecomCryptoHelper(options.CallbackToken, options.CallbackEncodingAesKey, options.CorpId);
        }
        else
        {
            _crypto = null!;
        }
    }

    /// <inheritdoc/>
    public string VerifyUrl(string msgSignature, string timestamp, string nonce, string echoStr)
    {
        EnsureCryptoConfigured();
        return _crypto.VerifyUrl(msgSignature, timestamp, nonce, echoStr);
    }

    /// <inheritdoc/>
    public CallbackMessageBase DecryptAndParse(string msgSignature, string timestamp, string nonce, string postBody)
    {
        EnsureCryptoConfigured();
        var decryptedXml = _crypto.DecryptMessage(msgSignature, timestamp, nonce, postBody);
        return CallbackMessageBase.FromXml(decryptedXml);
    }

    /// <inheritdoc/>
    public string EncryptReply(string replyXml, string? timestamp = null, string? nonce = null)
    {
        EnsureCryptoConfigured();
        timestamp ??= DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        nonce ??= Guid.NewGuid().ToString("N")[..16];
        return _crypto.EncryptReply(replyXml, timestamp, nonce);
    }

    /// <inheritdoc/>
    public async Task<SendMessageResponse> SendMessageAsync(SendMessageRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<SendMessageResponse>("/cgi-bin/message/send", request, ct);
    }

    // ─── 智能表格自动化创建的群聊 ──────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<GetSmartSheetChatListResponse> GetSmartSheetChatListAsync(GetSmartSheetChatListRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetSmartSheetChatListResponse>("/cgi-bin/chatdata/list", request, ct);
    }

    /// <inheritdoc/>
    public async Task<GetSmartSheetChatResponse> GetSmartSheetChatAsync(string chatId, CancellationToken ct = default)
    {
        return await _http.GetAsync<GetSmartSheetChatResponse>("/cgi-bin/chatdata/get",
            new Dictionary<string, string?> { ["chatid"] = chatId }, ct);
    }

    /// <inheritdoc/>
    public async Task UpdateSmartSheetChatAsync(UpdateSmartSheetChatRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>("/cgi-bin/chatdata/update", request, ct);
    }

    private void EnsureCryptoConfigured()
    {
        if (_crypto is null)
            throw new TencentException("智能机器人回调功能未配置：请在 WecomSmartBotOptions 中设置 CallbackToken 和 CallbackEncodingAesKey");
    }
}
