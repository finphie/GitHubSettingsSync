using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Entities;

/// <inheritdoc cref="GitHubRepository.MergeCommitMessage"/>
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
