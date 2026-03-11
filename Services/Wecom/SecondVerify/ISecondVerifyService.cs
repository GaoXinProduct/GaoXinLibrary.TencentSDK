using GaoXinLibrary.TencentSDK.Wecom.Models.SecondVerify;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>二次验证服务接口</summary>
public interface ISecondVerifyService
{
    /// <summary>获取用户二次验证信息</summary>
    Task<GetTfaInfoResponse> GetTfaInfoAsync(string code, CancellationToken ct = default);

    /// <summary>登录二次验证</summary>
    Task TfaSuccessAsync(string userId, CancellationToken ct = default);
}
