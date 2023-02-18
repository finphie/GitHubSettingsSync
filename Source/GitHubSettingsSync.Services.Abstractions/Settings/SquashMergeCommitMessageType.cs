using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Settings;

/// <inheritdoc cref="GitHubRepository.SquashMergeCommitMessage"/>
public enum SquashMergeCommitMessageType
{
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
