using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Entities;

/// <summary>
/// <inheritdoc cref="GitHubRepository.SquashMergeCommitTitle"/>
/// </summary>
public enum SquashMergeCommitTitleType
{
    /// <summary>
    /// プルリクエストのタイトル。
    /// </summary>
    PullRequestTitle,

    /// <summary>
    /// コミットが1つだけの場合はコミットのタイトル。
    /// 複数のコミットがある場合はプルリクエストのタイトル。
    /// </summary>
    CommitOrPullRequestTitle
}
