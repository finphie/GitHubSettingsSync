using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Entities;

/// <summary>
/// <inheritdoc cref="GitHubRepository.MergeCommitTitle"/>
/// </summary>
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
