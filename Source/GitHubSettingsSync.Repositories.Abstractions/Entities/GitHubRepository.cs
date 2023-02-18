using System.Text.Json.Serialization;

namespace GitHubSettingsSync.Repositories.Entities;

/// <summary>
/// GitHubリポジトリに関する設定を表す構造体です。
/// </summary>
/// <param name="HasIssues">Issuesを有効にするかどうか。</param>
/// <param name="HasProjects">Projectsを有効にするかどうか。</param>
/// <param name="HasWiki">Wikiを有効にするかどうか。</param>
/// <param name="AllowMergeCommit">「Create a merge commit」を有効にするかどうか。</param>
/// <param name="AllowRebaseMerge">「Rebase and Merge」を有効にするかどうか。</param>
/// <param name="AllowSquashMerge">「Squash Merge」を有効にするかどうか。</param>
/// <param name="AllowAutoMerge">自動マージ機能を有効にするかどうか。</param>
/// <param name="DeleteBranchOnMerge">プルリクエストマージ時に、ブランチを自動的に削除するかどうか。</param>
/// <param name="AllowUpdateBranch">「Update branch」を有効にするかどうか。</param>
/// <param name="MergeCommitTitle"><inheritdoc cref="MergeCommitTitleType" path="/summary"/></param>
/// <param name="MergeCommitMessage"><inheritdoc cref="MergeCommitMessageType" path="/summary"/></param>
/// <param name="SquashMergeCommitTitle"><inheritdoc cref="SquashMergeCommitTitleType" path="/summary"/></param>
/// <param name="SquashMergeCommitMessage"><inheritdoc cref="SquashMergeCommitMessageType" path="/summary"/></param>
public sealed record GitHubRepository(
    [property: JsonPropertyName("has_issues")] bool? HasIssues = null,
    [property: JsonPropertyName("has_projects")] bool? HasProjects = null,
    [property: JsonPropertyName("has_wiki")] bool? HasWiki = null,
    [property: JsonPropertyName("allow_merge_commit")] bool? AllowMergeCommit = null,
    [property: JsonPropertyName("allow_rebase_merge")] bool? AllowRebaseMerge = null,
    [property: JsonPropertyName("allow_squash_merge")] bool? AllowSquashMerge = null,
    [property: JsonPropertyName("allow_auto_merge")] bool? AllowAutoMerge = null,
    [property: JsonPropertyName("delete_branch_on_merge")] bool? DeleteBranchOnMerge = null,
    [property: JsonPropertyName("allow_update_branch")] bool? AllowUpdateBranch = null,
    [property: JsonPropertyName("merge_commit_title")] string? MergeCommitTitle = null,
    [property: JsonPropertyName("merge_commit_message")] string? MergeCommitMessage = null,
    [property: JsonPropertyName("squash_merge_commit_title")] string? SquashMergeCommitTitle = null,
    [property: JsonPropertyName("squash_merge_commit_message")] string? SquashMergeCommitMessage = null);
