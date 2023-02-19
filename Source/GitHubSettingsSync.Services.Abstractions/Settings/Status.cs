namespace GitHubSettingsSync.Services.Settings;

/// <summary>
/// ステータス。
/// </summary>
public enum Status
{
    /// <summary>
    /// 変更なし。
    /// </summary>
    Unchanged,

    /// <summary>
    /// 有効。
    /// </summary>
    Enabled,

    /// <summary>
    /// 無効。
    /// </summary>
    Disabled
}
