using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Settings;

/// <inheritdoc cref="GitHubRepository.MergeCommitTitle"/>
public enum MergeCommitTitleType
{
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
