using GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>收集表服务接口</summary>
public interface ICollectFormService
{
    /// <summary>创建收集表</summary>
    Task<CreateCollectFormResponse> CreateCollectFormAsync(CollectFormInfo form, CancellationToken ct = default);

    /// <summary>修改收集表</summary>
    Task ModifyCollectFormAsync(CollectFormInfo form, CancellationToken ct = default);

    /// <summary>获取收集表详情</summary>
    Task<CollectFormInfo?> GetCollectFormAsync(string formId, CancellationToken ct = default);

    /// <summary>获取收集表答案</summary>
    Task<GetCollectAnswerResponse> GetCollectAnswerAsync(string formId, string? cursor = null, int limit = 100, CancellationToken ct = default);
}
