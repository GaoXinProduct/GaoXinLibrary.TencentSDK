using System.Net;
using System.Text.Json;
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.OperationLog;
using GaoXinLibrary.TencentSDK.Wecom.Models.Security;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class WecomSecurityTests
{
    [Fact]
    public async Task FileOperationRecords_UsesTimeRangeAndCursorAndReadsRecordList()
    {
        var (result, body) = await VerifyRequestAsync(
            client => client.Security.GetFileOperationRecordsAsync(new GetFileOperationRecordsRequest
            {
                StartTime = 1788164400,
                EndTime = 1788164500,
                UserIdList = ["employee"],
                Operation = new FileOperation { Type = 103, Source = 401 },
                Cursor = "previous",
                Limit = 50
            }),
            HttpMethod.Post, "/cgi-bin/security/get_file_oper_record",
            """
            {
              "errcode": 0,
              "has_more": true,
              "next_cursor": "next",
              "record_list": [
                {
                  "time": 1788164413, "userid": "employee", "operation": {"type": 103, "source": 401},
                  "file_info": "report.pdf", "file_size": 3000000000, "device_code": "device-1"
                },
                {
                  "time": 1788164420, "external_user": {"type": 2, "name": "guest"},
                  "operation": {"type": 10001}, "applicant_name": "employee"
                }
              ]
            }
            """);

        Assert.Equal(1788164400, body.GetProperty("start_time").GetInt64());
        Assert.Equal(1788164500, body.GetProperty("end_time").GetInt64());
        Assert.Equal("employee", body.GetProperty("userid_list")[0].GetString());
        Assert.Equal(103, body.GetProperty("operation").GetProperty("type").GetInt32());
        Assert.Equal("previous", body.GetProperty("cursor").GetString());
        Assert.Equal(50, body.GetProperty("limit").GetInt32());
        Assert.True(result.HasMore);
        Assert.Equal("next", result.NextCursor);
        Assert.Collection(result.RecordList!,
            record =>
            {
                Assert.Equal("device-1", record.DeviceCode);
                Assert.Equal(3000000000L, record.FileSize);
                Assert.Equal(401, record.Operation!.Source);
            },
            record => Assert.Equal("guest", record.ExternalUser!.Name));
    }

    [Fact]
    public async Task LegacyFileLeakPrevention_RequestsTheLatestDay()
    {
        var (result, body) = await VerifyRequestAsync(
            client => client.Security.GetFileLeakPreventionAsync(),
            HttpMethod.Post, "/cgi-bin/security/get_file_oper_record",
            """{"errcode":0,"record_list":[{"time":1788164413,"file_info":"report.pdf"}],"rule_list":[{"rule_id":8}]}""");

        var startTime = body.GetProperty("start_time").GetInt64();
        var endTime = body.GetProperty("end_time").GetInt64();
        Assert.Equal(86400L, endTime - startTime);
        Assert.False(body.TryGetProperty("cursor", out _));
        Assert.Equal("report.pdf", Assert.Single(result.RecordList!).FileInfo);
        Assert.Equal(8, Assert.Single(result.RuleList!).RuleId);
    }

    [Theory]
    [InlineData(-1L, 1L)]
    [InlineData(2L, 1L)]
    [InlineData(1L, 1209602L)]
    public async Task FileOperationRecords_RejectsInvalidRangesBeforeSending(long startTime, long endTime)
    {
        using var handler = new SecurityHandler("{}");
        using var httpClient = new HttpClient(handler);
        using var client = CreateClient(httpClient);

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
            client.Security.GetFileOperationRecordsAsync(new GetFileOperationRecordsRequest
            {
                StartTime = startTime,
                EndTime = endTime
            }));

        Assert.Null(handler.RequestUri);
    }

    [Fact]
    public async Task DeviceByUser_UsesLastLoginUserIdAndDefaultDeviceType()
    {
        var request = JsonSerializer.Deserialize<GetDeviceInfoRequest>("""{"userid":"employee"}""");
        Assert.NotNull(request);

        var (result, body) = await VerifyRequestAsync(
            client => client.Security.GetDeviceInfoAsync(request),
            HttpMethod.Post, "/cgi-bin/security/trustdevice/get_by_user",
            """{"errcode":0,"device_list":[{"device_code":"device-1","system":"Windows","pc_name":"Office-PC","last_login_userid":"employee","status":5}]}""");

        Assert.Equal("employee", body.GetProperty("last_login_userid").GetString());
        Assert.Equal(1, body.GetProperty("type").GetInt32());
        Assert.False(body.TryGetProperty("userid", out _));
        var device = Assert.Single(result.DeviceList!);
        Assert.Equal("Windows", device.System);
        Assert.Equal("Office-PC", device.PcName);
        Assert.Equal("employee", device.LastLoginUserId);
    }

    [Fact]
    public async Task ImportTrustedDevices_PreservesPerDeviceOutcomes()
    {
        var (result, body) = await VerifyRequestAsync(
            client => client.Security.ImportTrustedDevicesAsync(new ImportTrustedDevicesRequest
            {
                DeviceList =
                [
                    new TrustedDeviceRegistration { System = "Windows", MacAddresses = ["02:00:00:00:00:01"] },
                    new TrustedDeviceRegistration { System = "Mac", SequenceNumber = "mac-001" }
                ]
            }),
            HttpMethod.Post, "/cgi-bin/security/trustdevice/import",
            """{"errcode":0,"result":[{"device_index":1,"device_code":"device-1","status":1},{"device_index":2,"duplicated_device_code":"device-2","status":2}]}""");

        var devices = body.GetProperty("device_list");
        Assert.Equal("02:00:00:00:00:01", devices[0].GetProperty("mac_addr")[0].GetString());
        Assert.Equal("mac-001", devices[1].GetProperty("seq_no").GetString());
        Assert.False(devices[1].TryGetProperty("mac_addr", out _));
        Assert.Collection(result.Results!,
            device => Assert.Equal("device-1", device.DeviceCode),
            device =>
            {
                Assert.Equal(2, device.DeviceIndex);
                Assert.Equal(2, device.Status);
                Assert.Equal("device-2", device.DuplicatedDeviceCode);
            });
    }

    [Fact]
    public async Task ListTrustedDevices_RoundTripsCursor()
    {
        var (result, body) = await VerifyRequestAsync(
            client => client.Security.ListTrustedDevicesAsync(new ListTrustedDevicesRequest
            {
                Type = 2,
                Cursor = "previous",
                Limit = 10
            }),
            HttpMethod.Post, "/cgi-bin/security/trustdevice/list",
            """{"errcode":0,"next_cursor":"next","device_list":[{"device_code":"device-1","system":"Mac","seq_no":"mac-001"}]}""");

        Assert.Equal(2, body.GetProperty("type").GetInt32());
        Assert.Equal("previous", body.GetProperty("cursor").GetString());
        Assert.Equal(10, body.GetProperty("limit").GetInt32());
        Assert.Equal("next", result.NextCursor);
        Assert.Equal("mac-001", Assert.Single(result.DeviceList!).SequenceNumber);
    }

    [Fact]
    public async Task DeleteTrustedDevices_SendsTypeAndDeviceCodeList()
    {
        var (_, body) = await VerifyRequestAsync(
            client => client.Security.DeleteTrustedDevicesAsync(new DeleteTrustedDevicesRequest
            {
                Type = 1,
                DeviceCodeList = ["device-1", "device-2"]
            }),
            HttpMethod.Post, "/cgi-bin/security/trustdevice/delete", """{"errcode":0}""");

        Assert.Equal(1, body.GetProperty("type").GetInt32());
        Assert.Equal("device-2", body.GetProperty("device_code_list")[1].GetString());
    }

    [Theory]
    [InlineData(true, "/cgi-bin/security/trustdevice/approve")]
    [InlineData(false, "/cgi-bin/security/trustdevice/reject")]
    public async Task DeviceApproval_PreservesSuccessfulAndFailedDeviceCodes(bool approve, string path)
    {
        var request = new TrustedDeviceApprovalRequest { DeviceCodeList = ["device-1", "device-2"] };
        var (result, body) = await VerifyRequestAsync(
            client => approve ? client.Security.ApproveTrustedDevicesAsync(request) : client.Security.RejectTrustedDevicesAsync(request),
            HttpMethod.Post, path,
            """{"errcode":0,"success_list":["device-1"],"fail_list":["device-2"]}""");

        Assert.Equal(2, body.GetProperty("device_code_list").GetArrayLength());
        Assert.Equal("device-1", Assert.Single(result.SuccessList!));
        Assert.Equal("device-2", Assert.Single(result.FailList!));
    }

    [Fact]
    public async Task ScreenOperationRecords_RoundTripsPaginationAndDeviceDetails()
    {
        var (result, body) = await VerifyRequestAsync(
            client => client.Security.GetScreenOperationRecordsAsync(new GetScreenOperationRecordsRequest
            {
                StartTime = 1788164400,
                EndTime = 1788164500,
                DepartmentIdList = [2],
                ScreenshotType = 6,
                Cursor = "previous"
            }),
            HttpMethod.Post, "/cgi-bin/security/get_screen_oper_record",
            """
            {
              "errcode":0, "has_more":true, "next_cursor":"next",
              "record_list":[
                {"time":1788164413,"userid":"employee","department_id":2,"screen_shot_type":6,
                 "screen_shot_content":"other","operation_type":2,
                 "device_info":{"platform":"Mac","device_code":"device-1","mac":{"seq_no":"mac-001"}}}
              ]
            }
            """);

        Assert.Equal(2, body.GetProperty("department_id_list")[0].GetInt64());
        Assert.Equal(6, body.GetProperty("screen_shot_type").GetInt32());
        Assert.Equal("previous", body.GetProperty("cursor").GetString());
        Assert.True(result.HasMore);
        Assert.Equal("next", result.NextCursor);
        var record = Assert.Single(result.RecordList!);
        Assert.Equal(2, record.OperationType);
        Assert.Equal("Mac", record.DeviceInfo!.Platform);
        Assert.Equal("mac-001", record.DeviceInfo.Mac!.SequenceNumber);
    }

    [Fact]
    public async Task ServerDomainIp_ParsesBothDomainAndIpEntries()
    {
        var (result, body) = await VerifyRequestAsync(
            client => client.Security.GetServerDomainIpAsync(),
            HttpMethod.Get, "/cgi-bin/security/get_server_domain_ip",
            """
            {
              "errcode":0,
              "domain_list":[{"domain":"api.example.test","universal_domian":"example.test","port":[443,80],"is_necessary":1}],
              "ip_list":[{"ip":"192.0.2.1","protocol":"TCP","port":[443],"is_necessary":0}]
            }
            """);

        Assert.Equal(JsonValueKind.Undefined, body.ValueKind);
        var domain = Assert.Single(result.DomainList!);
        Assert.Equal("example.test", domain.UniversalDomain);
        Assert.Equal([443, 80], domain.PortList!);
        Assert.Equal(1, domain.IsNecessary);
        var ip = Assert.Single(result.IpList!);
        Assert.Equal("192.0.2.1", ip.Ip);
        Assert.Equal("TCP", ip.Protocol);
    }

    [Theory]
    [InlineData(false, "/cgi-bin/security/member_oper_log/list", null)]
    [InlineData(true, "/cgi-bin/security/admin_oper_log/list", 2)]
    public async Task OperationLogs_RoundTripFiltersAndRecordList(bool administrator, string path, int? detailType)
    {
        var request = new GetOperationLogRequest
        {
            StartTime = 1724256000,
            EndTime = 1724860799,
            UserId = "employee",
            OperateType = 1,
            Cursor = "previous",
            Limit = 10
        };
        var response = administrator
            ? """{"errcode":0,"has_more":true,"next_cursor":"next","record_list":[{"userid":"employee","time":1724256100,"oper_type":1,"detail_type":2,"detail_info":"update","ip":"192.0.2.1"}]}"""
            : """{"errcode":0,"has_more":true,"next_cursor":"next","record_list":[{"userid":"employee","time":1724256100,"oper_type":1,"detail_info":"update","ip":"192.0.2.1"}]}""";

        var (result, body) = await VerifyRequestAsync(
            client => administrator
                ? client.OperationLog.GetAdminOperationRecordAsync(request)
                : client.OperationLog.GetUserOperationRecordAsync(request),
            HttpMethod.Post, path, response);

        Assert.Equal(1724256000, body.GetProperty("start_time").GetInt64());
        Assert.Equal(1724860799, body.GetProperty("end_time").GetInt64());
        Assert.Equal("employee", body.GetProperty("userid").GetString());
        Assert.Equal(1, body.GetProperty("oper_type").GetInt32());
        Assert.Equal("previous", body.GetProperty("cursor").GetString());
        Assert.Equal(10, body.GetProperty("limit").GetInt32());
        Assert.True(result.HasMore);
        Assert.Equal("next", result.NextCursor);
        var record = Assert.Single(result.OperationRecords!);
        Assert.Equal("employee", record.UserId);
        Assert.Equal(1724256100, record.OperateTime);
        Assert.Equal(1, record.OperateType);
        Assert.Equal("update", record.Data);
        Assert.Equal("192.0.2.1", record.Ip);
        Assert.Equal(detailType, record.DetailType);
    }

    [Fact]
    public void OperationLogs_ReadLegacySerializedResponse()
    {
        var result = JsonSerializer.Deserialize<GetOperationLogResponse>(
            """{"errcode":0,"operation_records":[{"userid":"employee","operatetime":1724256100,"operatetype":2,"data":"legacy"}]}""");

        Assert.NotNull(result);
        var record = Assert.Single(result.OperationRecords!);
        Assert.Equal(1724256100, record.OperateTime);
        Assert.Equal(2, record.OperateType);
        Assert.Equal("legacy", record.Data);

        var serialized = JsonSerializer.SerializeToElement(result);
        Assert.False(serialized.TryGetProperty("operation_records", out _));
        var serializedRecord = serialized.GetProperty("record_list")[0];
        Assert.Equal(2, serializedRecord.GetProperty("oper_type").GetInt32());
        Assert.False(serializedRecord.TryGetProperty("operatetype", out _));
    }

    private static async Task<(T Result, JsonElement Body)> VerifyRequestAsync<T>(
        Func<WecomClient, Task<T>> call, HttpMethod method, string path, string response)
    {
        using var handler = new SecurityHandler(response);
        using var httpClient = new HttpClient(handler);
        using var client = CreateClient(httpClient);

        var result = await call(client);

        Assert.Equal(method, handler.Method);
        Assert.NotNull(handler.RequestUri);
        Assert.Equal(path, handler.RequestUri.AbsolutePath);
        Assert.Equal("?access_token=test-token", handler.RequestUri.Query);
        return (result, handler.Body);
    }

    private static WecomClient CreateClient(HttpClient httpClient)
    {
        var client = WecomClient.Create(new WecomOptions
        {
            CorpId = "corp",
            CorpSecret = "test-secret",
            BaseUrl = "https://example.test"
        }, httpClient);
        client.SetAccessToken("test-token");
        return client;
    }

    private sealed class SecurityHandler(string response) : HttpMessageHandler
    {
        public HttpMethod? Method { get; private set; }
        public Uri? RequestUri { get; private set; }
        public JsonElement Body { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Method = request.Method;
            RequestUri = request.RequestUri;
            if (request.Content is not null)
            {
                using var body = JsonDocument.Parse(await request.Content.ReadAsStringAsync(cancellationToken));
                Body = body.RootElement.Clone();
            }

            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(response) };
        }
    }
}
