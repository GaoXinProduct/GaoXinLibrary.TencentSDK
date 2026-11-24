using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Todo;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>企业微信待办服务。</summary>
public sealed class TodoService
{
    private readonly WecomHttpClient _http;

    public TodoService(WecomHttpClient http) => _http = http;

    /// <summary>获取指定待办的详情。</summary>
    /// <seealso href="https://developer.work.weixin.qq.com/document/path/101524"/>
    public Task<GetTodoResponse> GetTodoAsync(string todoId, CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(todoId);
        return _http.PostQueryAsync<GetTodoResponse>("/cgi-bin/todo/get", new { todo_id = todoId }, ct);
    }

    /// <summary>更新指定待办的状态和参与人。</summary>
    /// <seealso href="https://developer.work.weixin.qq.com/document/path/101534"/>
    public Task UpdateTodoAsync(UpdateTodoRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.TodoId);
        if (request.Attendees is { Length: > 20 })
            throw new ArgumentException("待办参与人不能超过 20 个。", nameof(request));

        return _http.PostAsync<WecomBaseResponse>("/cgi-bin/todo/update", request, ct);
    }
}
