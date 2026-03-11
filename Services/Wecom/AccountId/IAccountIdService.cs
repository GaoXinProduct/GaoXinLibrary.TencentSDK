using GaoXinLibrary.TencentSDK.Wecom.Models.AccountId;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>账号ID管理服务接口</summary>
public interface IAccountIdService
{
    /// <summary>tmp_external_userid的转换</summary>
    Task<ConvertTmpExternalUserIdResponse> ConvertTmpExternalUserIdAsync(string[] tmpExternalUserIds, int businessType = 1, CancellationToken ct = default);
}
