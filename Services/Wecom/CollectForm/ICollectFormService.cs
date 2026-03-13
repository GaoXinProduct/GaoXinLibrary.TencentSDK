using GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>收集表服务接口</summary>
public interface ICollectFormService
{
    /// <summary>创建收集表</summary>
    Task<CreateCollectFormResponse> CreateCollectFormAsync(CollectFormOperationRequest request, CancellationToken ct = default);

    /// <summary>修改收集表</summary>
    Task ModifyCollectFormAsync(CollectFormOperationRequest request, CancellationToken ct = default);

    /// <summary>获取收集表详情</summary>
    Task<CollectFormInfo?> GetCollectFormAsync(GetCollectFormRequest request, CancellationToken ct = default);

    /// <summary>获取收集表答案</summary>
    Task<GetCollectAnswerResponse> GetCollectAnswerAsync(GetCollectAnswerRequest request, CancellationToken ct = default);
}
