using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Settings;

/// <summary>
/// マージにおけるコミットタイトル・メッセージの種類。
/// </summary>
/// <param name="Title"><inheritdoc cref="GitHubRepository.MergeCommitTitle" path="/summary"/></param>
/// <param name="Message"><inheritdoc cref="GitHubRepository.MergeCommitMessage" path="/summary"/></param>
public sealed record MergeCommit(
    MergeCommitTitleType Title = MergeCommitTitleType.Unchanged,
    MergeCommitMessageType Message = MergeCommitMessageType.Unchanged);
