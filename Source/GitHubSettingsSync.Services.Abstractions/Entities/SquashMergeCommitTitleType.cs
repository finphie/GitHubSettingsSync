using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Entities;

/// <inheritdoc cref="GitHubRepository.SquashMergeCommitTitle"/>
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
