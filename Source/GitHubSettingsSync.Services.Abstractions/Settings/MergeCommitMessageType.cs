namespace GitHubSettingsSync.Services.Settings;

/// <summary>
/// マージにおけるコミットメッセージの種類。
/// </summary>
public enum MergeCommitMessageType
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
    /// プルリクエストの本文。
    /// </summary>
    PullRequestBody,

    /// <summary>
    /// 空白のコミットメッセージ。
    /// </summary>
    Blank
}
