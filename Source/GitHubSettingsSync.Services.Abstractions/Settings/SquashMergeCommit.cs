using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Settings;

/// <summary>
/// スカッシュマージにおけるコミットタイトル・メッセージの種類。
/// </summary>
/// <param name="Title"><inheritdoc cref="GitHubRepository.SquashMergeCommitTitle" path="/summary"/></param>
/// <param name="Message"><inheritdoc cref="GitHubRepository.SquashMergeCommitMessage" path="/summary"/></param>
public sealed record SquashMergeCommit(
    SquashMergeCommitTitleType Title = SquashMergeCommitTitleType.Unchanged,
    SquashMergeCommitMessageType Message = SquashMergeCommitMessageType.Unchanged);
