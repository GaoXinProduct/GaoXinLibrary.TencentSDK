using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>公众号客服消息服务接口</summary>
public interface IOfficialCustomMessageService
{
    /// <summary>发送客服消息</summary>
    Task<OfficialCustomMessageResponse> SendAsync(OfficialCustomMessageRequest request, CancellationToken ct = default);
    /// <summary>下发客服输入状态</summary>
    Task<OfficialSetTypingResponse> SetTypingAsync(OfficialSetTypingRequest request, CancellationToken ct = default);
    /// <summary>添加客服帐号</summary>
    Task<KfAccountOperationResponse> AddKfAccountAsync(AddKfAccountRequest request, CancellationToken ct = default);
    /// <summary>修改客服帐号</summary>
    Task<KfAccountOperationResponse> UpdateKfAccountAsync(UpdateKfAccountRequest request, CancellationToken ct = default);
    /// <summary>删除客服帐号</summary>
    Task<KfAccountOperationResponse> DeleteKfAccountAsync(string kfAccount, CancellationToken ct = default);
    /// <summary>获取所有客服帐号</summary>
    Task<GetKfListResponse> GetKfListAsync(CancellationToken ct = default);
}

