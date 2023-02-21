namespace GitHubSettingsSync.Services.Settings;

/// <summary>
/// マージにおけるコミットタイトルの種類。
/// </summary>
public enum MergeCommitTitleType
{
    /// <summary>
    /// 変更なし。
    /// </summary>
    Unchanged,

    /// <summary>
    /// プルリクエストのタイトル。
    /// </summary>
    PullRequestTitle,

    /// <summary>
    /// マージメッセージのデフォルトのタイトル。
    /// </summary>
    /// <remarks>
    /// <example>
    /// Merge pull request #123 from branch-name
    /// </example>
    /// </remarks>
    MergeMessage
}
