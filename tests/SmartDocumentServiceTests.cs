using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Document;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartDocument;
using GaoXinLibrary.TencentSDK.Wecom.Services;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class SmartDocumentServiceTests
{
    [Fact]
    public async Task Pages_UseHierarchyAndWriteContracts()
    {
        using var handler = new SmartDocumentHandler(
            new("get_page_hierarchy", """{"docid":"doc"}""",
                """{"errcode":0,"pages":[{"page_id":"root","parent_id":"","title":"首页"}]}"""),
            new("add_page", """{"docid":"doc","info":{"title":"子页","parent_id":"root","layout_mode":3}}""",
                """{"errcode":0,"info":{"page_id":"child","parent_id":"root","title":"子页","layout_mode":3}}"""),
            new("update_page", """{"docid":"doc","info":{"page_id":"child","after_id":"","parent_id":""}}""",
                """{"errcode":0,"info":{"page_id":"child","parent_id":"","title":"子页"}}"""),
            new("delete_page", """{"docid":"doc","page_id":"child"}"""));
        using var http = new HttpClient(handler);
        var service = CreateService(http);

        var hierarchy = await service.GetPageHierarchyAsync(new() { DocId = "doc" });
        var root = Assert.Single(hierarchy.Pages!);
        Assert.Equal("root", root.PageId);
        Assert.Equal(string.Empty, root.ParentId);

        var added = await service.AddPageAsync(new()
        {
            DocId = "doc",
            Info = new() { Title = "子页", ParentId = root.PageId, LayoutMode = SmartDocumentPageLayoutMode.FullWidth }
        });
        var child = Assert.IsType<SmartDocumentPageInfo>(added.Info);
        Assert.Equal("child", child.PageId);
        Assert.Equal(SmartDocumentPageLayoutMode.FullWidth, child.LayoutMode);

        var updated = await service.UpdatePageAsync(new()
        {
            DocId = "doc",
            Info = new() { PageId = child.PageId, ParentId = string.Empty, AfterId = string.Empty }
        });
        Assert.Equal(string.Empty, updated.Info?.ParentId);
        await service.DeletePageAsync(new() { DocId = "doc", PageId = child.PageId });
        handler.AssertComplete();
    }

    [Fact]
    public async Task Blocks_PreservePaginationAndTypeSpecificProperties()
    {
        using var handler = new SmartDocumentHandler(
            new("add_blocks",
                """{"docid":"doc","page_id":"page","blocks":[{"type":"BLOCK_TYPE_TODO","title":"准备材料","props":{"todo_props":{"checked":false}}}]}""",
                """{"errcode":0,"blocks":[{"id":"block","type":"BLOCK_TYPE_TODO","title":"准备材料","props":{"todo_props":{"checked":false}}}]}"""),
            new("update_blocks", """{"docid":"doc","page_id":"page","blocks":[{"id":"block","content":"已完成","props":{"todo_props":{"checked":true}}}]}""",
                """{"errcode":0,"blocks":[{"id":"block","type":"BLOCK_TYPE_TODO","title":"已完成","props":{"todo_props":{"checked":true}}}]}"""),
            new("get_block_list", """{"docid":"doc","page_id":"page","ids":["block"],"start":0,"limit":1}""",
                """{"errcode":0,"blocks":[{"id":"block","type":"BLOCK_TYPE_TODO","content":"已完成","children":[]}],"has_more":"true","next_start":1}"""),
            new("get_block_list", """{"docid":"doc","page_id":"page","start":1,"limit":1}""",
                """{"errcode":0,"blocks":[],"has_more":false}"""),
            new("delete_blocks", """{"docid":"doc","page_id":"page","ids":["block"]}"""));
        using var http = new HttpClient(handler);
        var service = CreateService(http);

        var added = await service.AddBlocksAsync(new()
        {
            DocId = "doc",
            PageId = "page",
            Blocks = [new() { Type = "BLOCK_TYPE_TODO", Title = "准备材料", Props = new() { TodoProps = new() { IsChecked = false } } }]
        });
        var block = Assert.Single(added.Blocks!);
        Assert.Equal("block", block.Id);
        Assert.False(block.Props?.TodoProps?.IsChecked);

        var updated = await service.UpdateBlocksAsync(new()
        {
            DocId = "doc",
            PageId = "page",
            Blocks = [new() { Id = block.Id, Content = "已完成", Props = new() { TodoProps = new() { IsChecked = true } } }]
        });
        Assert.True(Assert.Single(updated.Blocks!).Props?.TodoProps?.IsChecked);

        var firstPage = await service.GetBlocksAsync(new() { DocId = "doc", PageId = "page", Ids = [block.Id], Start = 0, Limit = 1 });
        Assert.True(firstPage.HasMore);
        Assert.Equal(1, firstPage.NextStart);
        Assert.Equal("已完成", Assert.Single(firstPage.Blocks!).Content);

        var secondPage = await service.GetBlocksAsync(new() { DocId = "doc", PageId = "page", Start = firstPage.NextStart, Limit = 1 });
        Assert.False(secondPage.HasMore);
        Assert.Empty(secondPage.Blocks!);
        await service.DeleteBlocksAsync(new() { DocId = "doc", PageId = "page", Ids = [block.Id] });
        handler.AssertComplete();
    }

    [Fact]
    public async Task Export_SeparateCreationAndResultRequestsPreserveTaskState()
    {
        using var handler = new SmartDocumentHandler(
            new("export_task", """{"docid":"doc","content_type":1,"page_id":"page"}""",
                """{"errcode":0,"task_id":"task"}"""),
            new("get_export_result", """{"task_id":"task"}""", """{"errcode":0,"task_done":false}"""),
            new("get_export_result", """{"task_id":"task"}""", """{"errcode":0,"task_done":true,"content":"# 标题"}"""));
        using var http = new HttpClient(handler);
        var service = CreateService(http);

        var task = await service.CreateExportTaskAsync(new() { DocId = "doc", PageId = "page" });
        Assert.Equal("task", task.TaskId);
        var request = new GetSmartDocumentExportResultRequest { TaskId = task.TaskId! };
        var pending = await service.GetExportResultAsync(request);
        Assert.False(pending.TaskDone);
        Assert.Null(pending.Content);
        var completed = await service.GetExportResultAsync(request);
        Assert.True(completed.TaskDone);
        Assert.Equal("# 标题", completed.Content);
        handler.AssertComplete();
    }

    [Fact]
    public async Task DataTables_DistinguishDocumentSheetAndBlockIds()
    {
        using var handler = new SmartDocumentHandler(
            new("get_smartsheet_info", """{"docid":"doc"}""", """{"errcode":0,"ss_docid":"source"}"""),
            new("add_smartsheet", """{"docid":"doc","info":{"title":"数据表","after_id":"before"}}""",
                """{"errcode":0,"info":{"block_id":"block","sheet_id":"sheet","ss_docid":"source"}}"""),
            new("update_smartsheet", """{"docid":"doc","info":{"block_id":"block","title":"新数据表"}}""",
                """{"errcode":0,"info":{"block_id":"block","title":"新数据表","sheet_id":"sheet","ss_docid":"source"}}"""),
            new("delete_smartsheet", """{"docid":"doc","block_id":"block"}"""));
        using var http = new HttpClient(handler);
        var service = CreateService(http);

        var dataSource = await service.GetDataSourceAsync(new() { DocId = "doc" });
        Assert.Equal("source", dataSource.SmartSheetDocId);
        var added = await service.AddDataTableAsync(new() { DocId = "doc", Info = new() { Title = "数据表", AfterId = "before" } });
        var table = Assert.IsType<SmartDocumentDataTableInfo>(added.Info);
        Assert.Equal("block", table.BlockId);
        Assert.Equal("sheet", table.SheetId);
        Assert.Equal("source", table.SmartSheetDocId);

        var updated = await service.UpdateDataTableAsync(new() { DocId = "doc", Info = new() { BlockId = table.BlockId, Title = "新数据表" } });
        Assert.Equal("新数据表", updated.Info?.Title);
        await service.DeleteDataTableAsync(new() { DocId = "doc", BlockId = table.BlockId });
        handler.AssertComplete();
    }

    [Fact]
    public async Task Publishing_PreservesVisibilityFieldsAndPublicationMetadata()
    {
        using var handler = new SmartDocumentHandler(
            new("publish", """{"docid":"doc"}""",
                """{"errcode":0,"share_code":"share","publish_url":"https://doc.weixin.qq.com/smartdoc/p/share","version":2,"publish_time":1710000000,"publish_doc_title":"发布标题"}"""),
            new("publish_setting",
                """{"docid":"doc","publish_range":4,"auth_list":[{"type":1,"userid":"user"},{"type":2,"departmentid":42}]}"""),
            new("cancel_publish", """{"docid":"doc"}"""));
        using var http = new HttpClient(handler);
        var service = CreateService(http);

        var published = await service.PublishAsync(new() { DocId = "doc" });
        Assert.Equal("share", published.ShareCode);
        Assert.Equal("https://doc.weixin.qq.com/smartdoc/p/share", published.PublishUrl);
        Assert.Equal(2UL, published.Version);
        Assert.Equal(1710000000UL, published.PublishTime);
        Assert.Equal("发布标题", published.PublishDocTitle);

        await service.UpdatePublishSettingsAsync(new()
        {
            DocId = "doc",
            PublishRange = SmartDocumentPublishRange.SelectedMembers,
            AuthList =
            [
                new() { Type = SmartDocumentAudienceMemberType.User, UserId = "user" },
                new() { Type = SmartDocumentAudienceMemberType.Department, DepartmentId = 42 }
            ]
        });
        await service.CancelPublishAsync(new DocIdRequest { DocId = "doc" });
        handler.AssertComplete();
    }

    [Fact]
    public async Task TransientRetry_AppliesToPageReadButDoesNotReplayDataSourceCreation()
    {
        const string request = """{"docid":"doc"}""";
        using var handler = new SmartDocumentHandler(
            new("get_page_hierarchy", request, Status: HttpStatusCode.ServiceUnavailable),
            new("get_page_hierarchy", request, """{"errcode":0,"pages":[]}"""),
            new("get_smartsheet_info", request, Status: HttpStatusCode.ServiceUnavailable));
        using var http = new HttpClient(handler);
        var service = CreateService(http);

        Assert.Empty((await service.GetPageHierarchyAsync(new() { DocId = "doc" })).Pages!);
        var error = await Assert.ThrowsAsync<HttpRequestException>(() => service.GetDataSourceAsync(new() { DocId = "doc" }));
        Assert.Equal(HttpStatusCode.ServiceUnavailable, error.StatusCode);
        handler.AssertComplete();
    }

    private static SmartDocumentService CreateService(HttpClient http)
    {
        var options = new WecomOptions
        {
            CorpId = "corp",
            CorpSecret = "secret",
            BaseUrl = "https://example.test",
            RetryOptions = new TencentRetryOptions { MaxRetries = 1, InitialDelay = TimeSpan.Zero, MaxDelay = TimeSpan.Zero }
        };
        var provider = new AccessTokenProvider(options, http);
        provider.SetToken("smartdoc-token");
        return new SmartDocumentService(new WecomHttpClient(http, provider, options));
    }

    private sealed record ExpectedCall(
        string Route,
        string Request,
        string Response = """{"errcode":0,"errmsg":"ok"}""",
        HttpStatusCode Status = HttpStatusCode.OK);

    private sealed class SmartDocumentHandler(params ExpectedCall[] calls) : HttpMessageHandler
    {
        private int _next;

        internal void AssertComplete() => Assert.Equal(calls.Length, _next);

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Assert.True(_next < calls.Length, $"Unexpected call to {request.RequestUri}");
            var expected = calls[_next++];
            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal($"/cgi-bin/wedoc/smartdoc/{expected.Route}", request.RequestUri!.AbsolutePath);
            Assert.Equal("?access_token=smartdoc-token", request.RequestUri.Query);
            var body = await request.Content!.ReadAsStringAsync(cancellationToken);
            Assert.True(JsonNode.DeepEquals(JsonNode.Parse(expected.Request), JsonNode.Parse(body)), body);
            return new HttpResponseMessage(expected.Status)
            {
                Content = new StringContent(expected.Response, Encoding.UTF8, "application/json")
            };
        }
    }
}
