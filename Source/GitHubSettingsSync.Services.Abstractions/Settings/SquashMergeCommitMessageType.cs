namespace GitHubSettingsSync.Services.Settings;

/// <summary>
/// スカッシュマージにおけるコミットメッセージの種類。
/// </summary>
public enum SquashMergeCommitMessageType
{
    /// <summary>
    /// 変更なし。
    /// </summary>
    Unchanged,

    /// <summary>
    /// プルリクエストの本文。
    /// </summary>
    PullRequestBody,

    /// <summary>
    /// ブランチのコミットメッセージ。
    /// </summary>
    CommitMessages,

    /// <summary>
    /// 空白のコミットメッセージ。
    /// </summary>
    Blank
}
