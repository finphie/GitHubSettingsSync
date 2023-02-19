using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Settings;

/// <summary>
/// スカッシュマージにおけるコミットタイトル・メッセージの種類。
/// </summary>
/// <param name="SquashMergeCommitTitle"><inheritdoc cref="GitHubRepository.SquashMergeCommitTitle" path="/summary"/></param>
/// <param name="SquashMergeCommitMessage"><inheritdoc cref="GitHubRepository.SquashMergeCommitMessage" path="/summary"/></param>
public sealed record SquashMergeCommit(
    SquashMergeCommitTitleType SquashMergeCommitTitle = SquashMergeCommitTitleType.Unchanged,
    SquashMergeCommitMessageType SquashMergeCommitMessage = SquashMergeCommitMessageType.Unchanged);
