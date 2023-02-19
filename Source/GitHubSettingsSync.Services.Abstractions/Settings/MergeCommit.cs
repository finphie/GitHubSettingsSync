using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Settings;

/// <summary>
/// マージにおけるコミットタイトル・メッセージの種類。
/// </summary>
/// <param name="MergeCommitTitle"><inheritdoc cref="GitHubRepository.MergeCommitTitle" path="/summary"/></param>
/// <param name="MergeCommitMessage"><inheritdoc cref="GitHubRepository.MergeCommitMessage" path="/summary"/></param>
public sealed record MergeCommit(
    MergeCommitTitleType MergeCommitTitle = MergeCommitTitleType.Unchanged,
    MergeCommitMessageType MergeCommitMessage = MergeCommitMessageType.Unchanged);
