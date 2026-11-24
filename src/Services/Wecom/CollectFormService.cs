using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>收集表服务实现</summary>
public sealed class CollectFormService
{
    private readonly WecomHttpClient _http;

    public CollectFormService(WecomHttpClient http) => _http = http;

    /// <summary>创建收集表。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/97462"/></remarks>
    public Task<CreateCollectFormResponse> CreateCollectFormAsync(CollectFormOperationRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentNullException.ThrowIfNull(request.FormInfo);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.FormInfo.Title);
        ArgumentNullException.ThrowIfNull(request.FormInfo.Questions);

        return _http.PostAsync<CreateCollectFormResponse>("/cgi-bin/wedoc/create_form", new
        {
            spaceid = request.SpaceId,
            fatherid = request.ParentFolderId,
            form_info = BuildFormInfo(request.FormInfo, includeQuestions: true, includeSettings: true)
        }, ct);
    }

    /// <summary>通过兼容入口修改收集表的问题或设置。</summary>
    public Task ModifyCollectFormAsync(CollectFormOperationRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        var form = request.FormInfo;
        ArgumentNullException.ThrowIfNull(form);
        var hasQuestions = form.Title is not null || form.Description is not null ||
            form.Header is not null || form.Questions is not null;
        if (hasQuestions && form.Settings is not null)
            throw new ArgumentException("修改问题和修改设置需要分别调用 EditCollectFormAsync。", nameof(request));

        return EditCollectFormAsync(new EditCollectFormRequest
        {
            FormId = form.FormId ?? string.Empty,
            FormInfo = form,
            Operation = form.Settings is null ? CollectFormEditOperation.Questions : CollectFormEditOperation.Settings
        }, ct);
    }

    /// <summary>按指定操作修改收集表的问题或设置。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/97816"/></remarks>
    public Task<EditCollectFormResponse> EditCollectFormAsync(EditCollectFormRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.FormId);
        ArgumentNullException.ThrowIfNull(request.FormInfo);

        if (request.Operation is not (CollectFormEditOperation.Questions or CollectFormEditOperation.Settings))
            throw new ArgumentOutOfRangeException(nameof(request), request.Operation, "未知的收集表修改操作。");

        var editSettings = request.Operation == CollectFormEditOperation.Settings;
        if (editSettings && request.FormInfo.Settings?.FillOutAuth is null)
            throw new ArgumentException("修改设置时必须明确指定 Settings.FillOutAuth。", nameof(request));

        return _http.PostAsync<EditCollectFormResponse>("/cgi-bin/wedoc/modify_form", new
        {
            oper = request.Operation,
            formid = request.FormId,
            form_info = BuildFormInfo(request.FormInfo, includeQuestions: !editSettings, includeSettings: editSettings)
        }, ct);
    }

    /// <summary>获取收集表详情及可查询的周期 ID。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/97817"/></remarks>
    public async Task<CollectFormInfo?> GetCollectFormAsync(GetCollectFormRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.FormId);
        var resp = await _http.PostQueryAsync<GetCollectFormResponse>("/cgi-bin/wedoc/get_form_info", request, ct).ConfigureAwait(false);
        return resp.FormInfo;
    }

    /// <summary>获取指定周期的填写统计、已提交成员或未提交成员。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/97818"/></remarks>
    public Task<GetCollectFormStatResponse> GetCollectFormStatAsync(GetCollectFormStatRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.RepeatedId);
        if (!Enum.IsDefined(request.RequestType))
            throw new ArgumentOutOfRangeException(nameof(request), request.RequestType, "未知的收集表统计查询类型。");
        if (request.RequestType == CollectFormStatisticType.Submitted &&
            (request.StartTime is null || request.EndTime is null || request.StartTime > request.EndTime))
            throw new ArgumentException("查询已提交成员时必须指定有效的起止时间。", nameof(request));

        return _http.PostQueryAsync<GetCollectFormStatResponse>("/cgi-bin/wedoc/get_form_statistic", request, ct);
    }

    /// <summary>读取指定周期和答案 ID 的答案。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/97819"/></remarks>
    public Task<GetCollectAnswerResponse> GetCollectAnswerAsync(GetCollectAnswerRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.RepeatedId);
        if (request.AnswerIds is null || request.AnswerIds.Length is < 1 or > 100)
            throw new ArgumentException("请指定 1 到 100 个答案 ID。", nameof(request));

        return _http.PostQueryAsync<GetCollectAnswerResponse>("/cgi-bin/wedoc/get_form_answer", request, ct);
    }

    private static object BuildFormInfo(CollectFormInfo form, bool includeQuestions, bool includeSettings)
    {
        var questions = form.Questions;
        return new
        {
            form_title = includeQuestions ? form.Title : null,
            form_desc = includeQuestions ? form.Description : null,
            form_header = includeQuestions ? form.Header : null,
            form_question = includeQuestions && questions is not null
                ? new CollectFormQuestions
                {
                    Items = questions.Items.Select((question, index) => question.WithDefaultPosition(index + 1)).ToArray()
                }
                : null,
            form_setting = includeSettings ? form.Settings : null
        };
    }
}
