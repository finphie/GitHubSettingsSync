using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Settings;

/// <inheritdoc cref="GitHubRepository.SquashMergeCommitTitle"/>
public enum SquashMergeCommitTitleType
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
    /// コミットが1つだけの場合はコミットのタイトル。
    /// 複数のコミットがある場合はプルリクエストのタイトル。
    /// </summary>
    CommitOrPullRequestTitle
}
