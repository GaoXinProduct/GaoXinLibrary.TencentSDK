namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// API 模式智能机器人可调用的文档工具名称常量
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101468"/></para>
/// </summary>
public static class DocToolNames
{
    #region 文档操作

    /// <summary>创建文档/收集表/智能表格</summary>
    public const string CreateDoc = "create_doc";

    /// <summary>编辑文档内容</summary>
    public const string EditDocContent = "edit_doc_content";

    /// <summary>获取文档基本信息</summary>
    public const string GetDocBaseInfo = "get_doc_base_info";

    #endregion
    #region 智能表格 - 记录操作

    /// <summary>添加智能表格记录</summary>
    public const string SmartSheetAddRecords = "smartsheet_add_records";

    /// <summary>获取智能表格记录</summary>
    public const string SmartSheetGetRecords = "smartsheet_get_records";

    /// <summary>更新智能表格记录</summary>
    public const string SmartSheetUpdateRecords = "smartsheet_update_records";

    /// <summary>删除智能表格记录</summary>
    public const string SmartSheetDeleteRecords = "smartsheet_delete_records";

    #endregion
    #region 智能表格 - 字段操作

    /// <summary>添加智能表格字段</summary>
    public const string SmartSheetAddFields = "smartsheet_add_fields";

    /// <summary>获取智能表格字段</summary>
    public const string SmartSheetGetFields = "smartsheet_get_fields";

    /// <summary>更新智能表格字段</summary>
    public const string SmartSheetUpdateFields = "smartsheet_update_fields";

    /// <summary>删除智能表格字段</summary>
    public const string SmartSheetDeleteFields = "smartsheet_delete_fields";
    #endregion
}
