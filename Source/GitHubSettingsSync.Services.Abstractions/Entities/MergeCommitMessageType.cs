using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Entities;

/// <summary>
/// <inheritdoc cref="GitHubRepository.MergeCommitMessage"/>
/// </summary>
public enum MergeCommitMessageType
{
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
