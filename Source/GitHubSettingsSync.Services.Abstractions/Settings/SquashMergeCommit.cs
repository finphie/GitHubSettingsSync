namespace GitHubSettingsSync.Services.Settings;

/// <summary>
/// スカッシュマージにおけるコミットタイトル・メッセージの種類。
/// </summary>
/// <param name="Title">スカッシュマージにおけるコミットタイトルの種類。</param>
/// <param name="Message">スカッシュマージにおけるコミットメッセージの種類。</param>
public sealed record SquashMergeCommit(
    SquashMergeCommitTitleType Title = SquashMergeCommitTitleType.Unchanged,
    SquashMergeCommitMessageType Message = SquashMergeCommitMessageType.Unchanged);
