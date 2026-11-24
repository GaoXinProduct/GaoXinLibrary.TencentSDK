using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;
using GaoXinLibrary.TencentSDK.Wecom.Models.Calendar.Expansion;
using GaoXinLibrary.TencentSDK.Wecom.Services;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class WecomMediaCalendarTests
{
    [Fact]
    public async Task DownloadTempMediaAsync_ContinuesWithRangesAfterLargeFileResponse()
    {
        const int maxRangeLength = 20 * 1024 * 1024;
        var firstChunk = Enumerable.Range(0, 16).Select(value => (byte)value).ToArray();
        byte[] lastChunk = [16, 17, 18, 19];
        var largeFileError = new TrackingContent(Encoding.UTF8.GetBytes("""{"errcode":830002,"errmsg":"range required"}"""));
        largeFileError.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var firstContent = new TrackingContent(firstChunk);
        var lastContent = new TrackingContent(lastChunk);
        var ranges = new List<RangeItemHeaderValue?>();
        using var http = new HttpClient(new DelegateHandler((request, _) =>
        {
            Assert.Equal(HttpMethod.Get, request.Method);
            Assert.Equal("/cgi-bin/media/get", request.RequestUri!.AbsolutePath);
            Assert.Contains("media_id=media%2B%26id", request.RequestUri.Query);
            var range = request.Headers.Range?.Ranges.Single();
            ranges.Add(range);
            return Task.FromResult(ranges.Count switch
            {
                1 => new HttpResponseMessage(HttpStatusCode.OK) { Content = largeFileError },
                2 => Partial(firstContent, 0, 15, 20),
                3 => Partial(lastContent, 16, 19, 20),
                _ => throw new InvalidOperationException("Unexpected request")
            });
        }));
        using var client = CreateClient(http);
        using var destination = new MemoryStream();

        await client.Media.DownloadTempMediaAsync("media+&id", destination);

        Assert.Equal(firstChunk.Concat(lastChunk), destination.ToArray());
        Assert.True(destination.CanWrite);
        Assert.Collection(ranges,
            range => Assert.Null(range),
            range => Assert.Equal(new RangeItemHeaderValue(0, maxRangeLength - 1), range),
            range => Assert.Equal(new RangeItemHeaderValue(16, 16 + maxRangeLength - 1), range));
        Assert.True(largeFileError.IsDisposed);
        Assert.True(firstContent.IsDisposed);
        Assert.True(lastContent.IsDisposed);
    }

    [Fact]
    public async Task DownloadTempMediaRangeAsync_ReturnsInclusiveRangeAndRejectsOutOfOrderContent()
    {
        byte[] bytes = [4, 5, 6, 7];
        var expected = new TrackingContent(bytes);
        var misaligned = new TrackingContent(bytes);
        var calls = 0;
        using var http = new HttpClient(new DelegateHandler((request, _) =>
        {
            Assert.Equal("bytes=4-7", request.Headers.Range?.ToString());
            return Task.FromResult(++calls == 1
                ? Partial(expected, 4, 7, 10)
                : Partial(misaligned, 0, 3, 10));
        }));
        using var client = CreateClient(http);
        using var destination = new MemoryStream();

        var actual = await client.Media.DownloadTempMediaRangeAsync("media", destination, 4, 4);
        var error = await Assert.ThrowsAsync<TencentException>(() =>
            client.Media.DownloadTempMediaRangeAsync("media", destination, 4, 4));

        Assert.Equal(4, actual.Start);
        Assert.Equal(7, actual.End);
        Assert.Equal(10, actual.TotalLength);
        Assert.Equal(bytes, destination.ToArray());
        Assert.Contains("Content-Range", error.Message);
        Assert.True(expected.IsDisposed);
        Assert.True(misaligned.IsDisposed);
    }

    [Fact]
    public async Task DownloadTempMediaAsync_StreamsJsonAttachmentsWithoutParsingThemAsApiErrors()
    {
        const string fileJson = """{"errcode":40014,"errmsg":"file payload"}""";
        using var destination = new MemoryStream();
        var content = new DirectCopyContent(destination, Encoding.UTF8.GetBytes(fileJson));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "asset.json" };
        using var http = new HttpClient(new DelegateHandler((request, _) =>
        {
            Assert.Equal("/cgi-bin/media/get", request.RequestUri!.AbsolutePath);
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = content });
        }));
        using var client = CreateClient(http);

        await client.Media.DownloadTempMediaAsync("json-asset", destination);

        Assert.Equal(fileJson, Encoding.UTF8.GetString(destination.ToArray()));
        Assert.True(content.IsDisposed);
        Assert.True(destination.CanWrite);
    }

    [Fact]
    public async Task GetJsSdkVoiceAsync_RefreshesRejectedTokenBeforeReadingBinaryContent()
    {
        var calls = 0;
        byte[] voice = [1, 2, 3, 4];
        using var http = new HttpClient(new DelegateHandler((request, _) =>
        {
            switch (++calls)
            {
                case 1:
                    Assert.Equal("/cgi-bin/media/get/jssdk", request.RequestUri!.AbsolutePath);
                    Assert.Contains("access_token=token", request.RequestUri.Query);
                    return Task.FromResult(Json("""{"errcode":40014,"errmsg":"invalid access_token"}"""));
                case 2:
                    Assert.Equal("/cgi-bin/gettoken", request.RequestUri!.AbsolutePath);
                    return Task.FromResult(Json("""{"errcode":0,"access_token":"fresh+token","expires_in":7200}"""));
                case 3:
                    Assert.Equal("/cgi-bin/media/get/jssdk", request.RequestUri!.AbsolutePath);
                    Assert.Contains("access_token=fresh%2Btoken", request.RequestUri.Query);
                    return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(voice) });
                default:
                    throw new InvalidOperationException("Unexpected request");
            }
        }));
        using var client = CreateClient(http);

        Assert.Equal(voice, await client.Media.GetJsSdkVoiceAsync("voice"));
        Assert.Equal(3, calls);
    }

    [Fact]
    public async Task UploadTempMediaAsync_ReusesMultipartAfterTokenRejectionOnLegacyTransport()
    {
        var uploads = new List<byte[]>();
        using var rawHttp = new HttpClient(new DelegateHandler(async (request, ct) =>
        {
            Assert.Equal("files.example.test", request.RequestUri!.Host);
            if (request.RequestUri.AbsolutePath == "/cgi-bin/gettoken")
                return Json("""{"errcode":0,"access_token":"fresh","expires_in":7200}""");

            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal("/cgi-bin/media/upload", request.RequestUri.AbsolutePath);
            Assert.Contains("type=file", request.RequestUri.Query);
            Assert.Contains(uploads.Count == 0 ? "access_token=old" : "access_token=fresh", request.RequestUri.Query);
            Assert.Equal("multipart/form-data", request.Content!.Headers.ContentType?.MediaType);
            var body = await request.Content.ReadAsByteArrayAsync(ct);
            Assert.Contains("name=\"media\"; filename=\"报告.txt\"; filelength=3\r\n", Encoding.UTF8.GetString(body));
            uploads.Add(body);
            return uploads.Count == 1
                ? Json("""{"errcode":40014,"errmsg":"invalid access_token"}""")
                : Json("""{"errcode":0,"media_id":"uploaded"}""");
        }));
        using var appHttp = new HttpClient(new DelegateHandler((_, _) => throw new InvalidOperationException("Unexpected app request")));
        var appOptions = Options();
        var appTransport = new WecomHttpClient(appHttp, new AccessTokenProvider(appOptions, appHttp), appOptions);
        var mediaTokenProvider = new AccessTokenProvider(Options("https://files.example.test"), rawHttp);
        mediaTokenProvider.SetToken("old");
        var media = new MediaService(appTransport, mediaTokenProvider, rawHttp, "https://files.example.test/");

        Assert.Equal("uploaded", await media.UploadTempMediaAsync("file", "报告.txt", new byte[] { 1, 2, 3 }));
        Assert.Equal(2, uploads.Count);
        Assert.Equal(uploads[0], uploads[1]);
    }

    [Fact]
    public async Task CalendarListEntryPoints_SendOnlyCanonicalPaginationFields()
    {
        var offsets = new List<int>();
        using var http = new HttpClient(new DelegateHandler(async (request, ct) =>
        {
            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal("/cgi-bin/oa/schedule/get_by_calendar", request.RequestUri!.AbsolutePath);
            using var doc = JsonDocument.Parse(await request.Content!.ReadAsStringAsync(ct));
            var body = doc.RootElement;
            Assert.Equal("calendar-id", body.GetProperty("cal_id").GetString());
            Assert.Equal(12, body.GetProperty("limit").GetInt32());
            Assert.Equal(3, body.EnumerateObject().Count());
            offsets.Add(body.GetProperty("offset").GetInt32());
            return offsets.Count == 1
                ? Json("""{"errcode":0,"schedule_list":[{"schedule_id":"item-id"}]}""")
                : Json("""{"errcode":0,"schedule_list":[]}""");
        }));
        using var client = CreateClient(http);
#pragma warning disable CS0618
        var legacy = new GetScheduleListRequest { CalId = "calendar-id", Offset = 0, Limit = 12, StartTime = 500 };
#pragma warning restore CS0618

        Assert.Equal("item-id", Assert.Single(await client.Calendar.GetScheduleListAsync(legacy)).ScheduleId);
        Assert.Empty(await client.Calendar.GetScheduleByCalendarAsync(
            new GetScheduleByCalendarRequest { CalId = "calendar-id", Offset = 12, Limit = 12 }));
        Assert.Equal(new[] { 0, 12 }, offsets);
    }

    [Fact]
    public async Task GetScheduleDetailAsync_UsesTheDocumentedIdList()
    {
        using var http = new HttpClient(new DelegateHandler(async (request, ct) =>
        {
            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal("/cgi-bin/oa/schedule/get", request.RequestUri!.AbsolutePath);
            using var doc = JsonDocument.Parse(await request.Content!.ReadAsStringAsync(ct));
            var field = Assert.Single(doc.RootElement.EnumerateObject());
            Assert.Equal("schedule_id_list", field.Name);
            Assert.Equal("item-id", Assert.Single(field.Value.EnumerateArray()).GetString());
            return Json("""{"errcode":0,"schedule_list":[{"schedule_id":"item-id"}]}""");
        }));
        using var client = CreateClient(http);

        var schedule = Assert.Single(await client.Calendar.GetScheduleDetailAsync(
            new GetScheduleDetailRequest { ScheduleId = "item-id" }));
        Assert.Equal("item-id", schedule.ScheduleId);
    }

    private static WecomClient CreateClient(HttpClient http)
    {
        var client = WecomClient.Create(Options(), http);
        client.SetAccessToken("token");
        return client;
    }

    private static WecomOptions Options(string baseUrl = "https://wecom.example.test")
        => new() { CorpId = "corp", CorpSecret = "secret", BaseUrl = baseUrl };

    private static HttpResponseMessage Json(string value) => new(HttpStatusCode.OK)
    {
        Content = new StringContent(value, Encoding.UTF8, "application/json")
    };

    private static HttpResponseMessage Partial(HttpContent content, long from, long to, long total)
    {
        content.Headers.ContentRange = new ContentRangeHeaderValue(from, to, total);
        return new HttpResponseMessage(HttpStatusCode.PartialContent) { Content = content };
    }

    private sealed class DelegateHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> action) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => action(request, cancellationToken);
    }

    private sealed class TrackingContent(byte[] bytes) : ByteArrayContent(bytes)
    {
        public bool IsDisposed { get; private set; }

        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
            base.Dispose(disposing);
        }
    }

    private sealed class DirectCopyContent(Stream expectedDestination, byte[] bytes) : HttpContent
    {
        public bool IsDisposed { get; private set; }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
        {
            Assert.Same(expectedDestination, stream);
            return stream.WriteAsync(bytes).AsTask();
        }

        protected override bool TryComputeLength(out long length)
        {
            length = bytes.Length;
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
            base.Dispose(disposing);
        }
    }
}
