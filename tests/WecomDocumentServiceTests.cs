using System.Net;
using System.Text;
using System.Text.Json;
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Document;
using GaoXinLibrary.TencentSDK.Wecom.Services;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class WecomDocumentServiceTests
{
    [Fact]
    public async Task GetPermissionAsync_ReturnsRulesMembersAndSecuritySettings()
    {
        var handler = new DocumentHandler("""
            {
                "errcode": 0,
                "access_rule": { "enable_corp_internal": true, "ban_share_external": false },
                "secure_setting": {
                    "enable_readonly_copy": false,
                    "watermark": { "margin_type": 2, "show_visitor_name": true }
                },
                "doc_member_list": [{ "type": 1, "tmp_external_userid": "external", "auth": 1 }],
                "co_auth_list": [{ "type": 2, "departmentid": 4294967296, "auth": 1 }]
            }
            """);
        using var httpClient = new HttpClient(handler);
        using var client = CreateClient(httpClient);

        var response = await client.Document.GetDocPermissionAsync(new DocIdRequest { DocId = "doc-1" });

        Assert.True(response.AccessRule?.EnableCorpInternal);
        Assert.False(response.AccessRule?.BanShareExternal);
        Assert.False(response.SecureSetting?.EnableReadonlyCopy);
        Assert.True(response.SecureSetting?.Watermark?.ShowVisitorName);
        Assert.Equal("external", Assert.Single(response.DocMemberList!).TmpExternalUserId);
        Assert.Equal(4294967296UL, Assert.Single(response.CoAuthList!).DepartmentId);
        var request = Assert.Single(handler.Requests);
        Assert.Equal("/cgi-bin/wedoc/doc_get_auth", request.Path);
        Assert.Equal("doc-1", request.Body.GetProperty("docid").GetString());
    }

    [Fact]
    public async Task ModifyPermissionsAsync_SendsPartialRulesAndSeparateMemberLists()
    {
        var handler = new DocumentHandler(Ok, Ok, Ok);
        using var httpClient = new HttpClient(handler);
        using var client = CreateClient(httpClient);

        await client.Document.ModifyDocJoinRuleAsync(new ModifyDocJoinRuleRequest
        {
            DocId = "doc-1",
            EnableCorpExternal = false,
            UpdateCoAuthList = true,
            CoAuthList = []
        });
        await client.Document.ModifyDocMembersAsync(new ModifyDocMembersRequest
        {
            DocId = "doc-1",
            UpdateFileMemberList = [new DocMemberPermission { UserId = "author", Auth = 7 }],
            DeleteFileMemberList = [new DocMemberReference { TmpExternalUserId = "external" }]
        });
        await client.Document.ModifyDocSecuritySettingsAsync(new ModifyDocSecuritySettingsRequest
        {
            DocId = "doc-1",
            EnableReadonlyCopy = false,
            Watermark = new DocWatermark { ShowVisitorName = false, ShowText = true, Text = "Draft" }
        });

        Assert.Collection(handler.Requests,
            rule =>
            {
                Assert.Equal("/cgi-bin/wedoc/mod_doc_join_rule", rule.Path);
                Assert.Equal("doc-1", rule.Body.GetProperty("docid").GetString());
                Assert.False(rule.Body.GetProperty("enable_corp_external").GetBoolean());
                Assert.True(rule.Body.GetProperty("update_co_auth_list").GetBoolean());
                Assert.Equal(0, rule.Body.GetProperty("co_auth_list").GetArrayLength());
                Assert.False(rule.Body.TryGetProperty("enable_corp_internal", out _));
            },
            members =>
            {
                Assert.Equal("/cgi-bin/wedoc/mod_doc_member", members.Path);
                var updated = members.Body.GetProperty("update_file_member_list")[0];
                Assert.Equal(1, updated.GetProperty("type").GetInt32());
                Assert.Equal("author", updated.GetProperty("userid").GetString());
                Assert.Equal(7, updated.GetProperty("auth").GetInt32());
                var deleted = members.Body.GetProperty("del_file_member_list")[0];
                Assert.Equal("external", deleted.GetProperty("tmp_external_userid").GetString());
                Assert.False(deleted.TryGetProperty("auth", out _));
            },
            security =>
            {
                Assert.Equal("/cgi-bin/wedoc/mod_doc_safty_setting", security.Path);
                Assert.False(security.Body.GetProperty("enable_readonly_copy").GetBoolean());
                var watermark = security.Body.GetProperty("watermark");
                Assert.False(watermark.GetProperty("show_visitor_name").GetBoolean());
                Assert.Equal("Draft", watermark.GetProperty("text").GetString());
            });
    }

    [Theory]
    [InlineData(null, 3)]
    [InlineData(11, 11)]
    public async Task ManageDocumentAsync_UsesCorrectCreateRenameAndShareFields(int? configuredDocType, int expectedDocType)
    {
        var handler = new DocumentHandler("""{"errcode":0,"docid":"doc-1"}""", Ok,
            """{"errcode":0,"share_url":"https://doc.weixin.qq.com/share/test"}""");
        using var httpClient = new HttpClient(handler);
        using var client = CreateClient(httpClient);

        var createRequest = new CreateDocRequest
        {
            DocName = "Original",
            SpaceId = "space-1",
            FolderId = "folder-2",
            AdminUsers = ["author"]
        };
        if (configuredDocType is int docType)
            createRequest.DocType = docType;

        var document = await client.Document.CreateDocAsync(createRequest);
        await client.Document.RenameDocAsync(new RenameDocRequest { DocId = "doc-1", DocName = "Updated" });
        var share = await client.Document.GetDocShareLinkAsync(new ShareDocRequest { DocId = "doc-1" });

        Assert.Equal("doc-1", document.DocId);
        Assert.Equal("https://doc.weixin.qq.com/share/test", share.ShareUrl);
        Assert.Collection(handler.Requests,
            create =>
            {
                Assert.Equal("/cgi-bin/wedoc/create_doc", create.Path);
                Assert.Equal(expectedDocType, create.Body.GetProperty("doc_type").GetInt32());
                Assert.Equal("space-1", create.Body.GetProperty("spaceid").GetString());
                Assert.Equal("folder-2", create.Body.GetProperty("fatherid").GetString());
                Assert.Equal("author", create.Body.GetProperty("admin_users")[0].GetString());
                Assert.False(create.Body.TryGetProperty("folderId", out _));
            },
            rename =>
            {
                Assert.Equal("/cgi-bin/wedoc/rename_doc", rename.Path);
                Assert.Equal("Updated", rename.Body.GetProperty("new_name").GetString());
                Assert.False(rename.Body.TryGetProperty("doc_name", out _));
            },
            link =>
            {
                Assert.Equal("/cgi-bin/wedoc/doc_share", link.Path);
                Assert.Equal("doc-1", link.Body.GetProperty("docid").GetString());
                Assert.False(link.Body.TryGetProperty("userid_list", out _));
            });
    }

    [Fact]
    public async Task UploadMediaAsync_EncodesFileBytesInJson()
    {
        var handler = new DocumentHandler(
            """{"errcode":0,"url":"https://example.test/image","width":"12","height":16,"size":3}""",
            """{"errcode":0,"file_url":"https://example.test/file"}""");
        using var httpClient = new HttpClient(handler);
        using var client = CreateClient(httpClient);

        var image = await client.Document.UploadDocImageAsync(new UploadDocImageRequest
        {
            DocId = "doc-1",
            Content = [0x00, 0x01, 0xff]
        });
        var file = await client.Document.UploadDocFileAsync(new UploadDocFileRequest
        {
            DocId = "doc-1",
            FileName = "报告.txt",
            Content = [0xff, 0x01]
        });

        Assert.Equal("https://example.test/image", image.Url);
        Assert.Equal(12, image.Width);
        Assert.Equal("https://example.test/file", file.FileUrl);
        Assert.Collection(handler.Requests,
            uploadImage =>
            {
                Assert.Equal("/cgi-bin/wedoc/image_upload", uploadImage.Path);
                Assert.Equal("AAH/", uploadImage.Body.GetProperty("base64_content").GetString());
            },
            uploadFile =>
            {
                Assert.Equal("/cgi-bin/wedoc/file_upload", uploadFile.Path);
                Assert.Equal("报告.txt", uploadFile.Body.GetProperty("file_name").GetString());
                Assert.Equal("/wE=", uploadFile.Body.GetProperty("file_base64_content").GetString());
            });
    }

    [Fact]
    public async Task UploadFileInPartsAsync_UsesUploadKeyAndReturnsFileLink()
    {
        var handler = new DocumentHandler("""{"errcode":0,"hit_exist":false,"upload_key":"upload-key"}""", Ok,
            """{"errcode":0,"file_url":"https://example.test/chunked-file"}""",
            """{"errcode":0,"hit_exist":true,"file_url":"https://example.test/chunked-file"}""");
        using var httpClient = new HttpClient(handler);
        using var client = CreateClient(httpClient);
        var initRequest = new InitDocFileUploadRequest
        {
            DocId = "doc-1",
            FileName = "file.txt",
            Size = DocumentService.FileUploadBlockSize + 3,
            BlockSha = ["first", "last"]
        };

        var init = await client.Document.InitDocFileUploadAsync(initRequest);
        Assert.False(init.HitExist);
        var key = Assert.IsType<string>(init.UploadKey);
        await client.Document.UploadDocFilePartAsync(new UploadDocFilePartRequest
        {
            UploadKey = key,
            Index = 2,
            Content = [0x01, 0x02, 0x03]
        });
        var finish = await client.Document.FinishDocFileUploadAsync(new FinishDocFileUploadRequest { UploadKey = key });
        var existing = await client.Document.InitDocFileUploadAsync(initRequest);

        Assert.Equal("https://example.test/chunked-file", finish.FileUrl);
        Assert.True(existing.HitExist);
        Assert.Equal(finish.FileUrl, existing.FileUrl);
        Assert.Null(existing.UploadKey);
        Assert.Collection(handler.Requests,
            start =>
            {
                Assert.Equal("/cgi-bin/wedoc/file_upload_init", start.Path);
                Assert.Equal("doc-1", start.Body.GetProperty("docid").GetString());
                Assert.Equal(initRequest.Size, start.Body.GetProperty("size").GetUInt64());
                Assert.Equal("last", start.Body.GetProperty("block_sha")[1].GetString());
            },
            part =>
            {
                Assert.Equal("/cgi-bin/wedoc/file_upload_part", part.Path);
                Assert.Equal("upload-key", part.Body.GetProperty("upload_key").GetString());
                Assert.Equal(2, part.Body.GetProperty("index").GetInt32());
                Assert.Equal("AQID", part.Body.GetProperty("file_base64_content").GetString());
            },
            end =>
            {
                Assert.Equal("/cgi-bin/wedoc/file_upload_finish", end.Path);
                Assert.Equal("upload-key", end.Body.GetProperty("upload_key").GetString());
            },
            instant => Assert.Equal("/cgi-bin/wedoc/file_upload_init", instant.Path));
    }

    [Fact]
    public async Task UploadInvalidFilePart_FailsBeforeSending()
    {
        var handler = new DocumentHandler();
        using var httpClient = new HttpClient(handler);
        using var client = CreateClient(httpClient);

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
            client.Document.UploadDocFilePartAsync(new UploadDocFilePartRequest { Index = 0 }));
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
            client.Document.UploadDocFilePartAsync(new UploadDocFilePartRequest
            {
                Index = 1,
                Content = new byte[DocumentService.FileUploadBlockSize + 1]
            }));

        Assert.Empty(handler.Requests);
    }

    private const string Ok = """{"errcode":0,"errmsg":"ok"}""";

    private static WecomClient CreateClient(HttpClient httpClient)
        => WecomClient.Create(new WecomOptions
        {
            CorpId = "test-corp",
            CorpSecret = "test-secret",
            BaseUrl = "https://example.test"
        }, httpClient);

    private sealed record DocumentRequest(string Path, JsonElement Body);

    private sealed class DocumentHandler(params string[] responses) : HttpMessageHandler
    {
        public List<DocumentRequest> Requests { get; } = [];

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
        {
            var uri = request.RequestUri!;
            if (uri.AbsolutePath == "/cgi-bin/gettoken")
            {
                Assert.Equal(HttpMethod.Get, request.Method);
                return JsonResponse("""{"errcode":0,"access_token":"token","expires_in":7200}""");
            }

            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal("?access_token=token", uri.Query);
            var content = Assert.IsAssignableFrom<HttpContent>(request.Content);
            Assert.Equal("application/json", content.Headers.ContentType?.MediaType);
            using var body = JsonDocument.Parse(await content.ReadAsStringAsync(ct));
            var response = JsonResponse(responses[Requests.Count]);
            Requests.Add(new DocumentRequest(uri.AbsolutePath, body.RootElement.Clone()));
            return response;
        }

        private static HttpResponseMessage JsonResponse(string json)
            => new(HttpStatusCode.OK) { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }
}
