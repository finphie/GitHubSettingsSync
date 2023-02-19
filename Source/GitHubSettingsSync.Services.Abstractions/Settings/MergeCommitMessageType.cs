using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Settings;

/// <inheritdoc cref="GitHubRepository.MergeCommitMessage"/>
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
