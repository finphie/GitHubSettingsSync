namespace GitHubSettingsSync.Services.Settings;

/// <summary>
/// マージにおけるコミットタイトル・メッセージの種類。
/// </summary>
/// <param name="Title">マージにおけるコミットタイトルの種類。</param>
/// <param name="Message">マージにおけるコミットメッセージの種類。</param>
public sealed record MergeCommit(
    MergeCommitTitleType Title = MergeCommitTitleType.Unchanged,
    MergeCommitMessageType Message = MergeCommitMessageType.Unchanged);
