using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.AccountId;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>账号ID管理服务实现</summary>
public sealed class AccountIdService
{
    private readonly WecomHttpClient _http;

    public AccountIdService(WecomHttpClient http) => _http = http;

    /// <summary>tmp_external_userid的转换</summary>
    public async Task<ConvertTmpExternalUserIdResponse> ConvertTmpExternalUserIdAsync(ConvertTmpExternalUserIdRequest request, CancellationToken ct = default)
        => await _http.PostQueryAsync<ConvertTmpExternalUserIdResponse>("/cgi-bin/idconvert/convert_tmp_external_userid", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 转换智能机器人获取的密文成员 ID，需要自建应用凭证和对应成员可见权限。
    /// 参考 <see href="https://developer.work.weixin.qq.com/document/path/101521"/>。
    /// </summary>
    public Task<ConvertRobotOpenUserIdsResponse> ConvertRobotOpenUserIdsAsync(ConvertRobotOpenUserIdsRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (request.OpenUserIds is not { Length: > 0 and <= 1000 })
            throw new ArgumentException("OpenUserIds 必须包含 1 至 1000 个 ID。", nameof(request));

        return _http.PostQueryAsync<ConvertRobotOpenUserIdsResponse>("/cgi-bin/batch/openuserid_to_userid", request, ct);
    }
}
