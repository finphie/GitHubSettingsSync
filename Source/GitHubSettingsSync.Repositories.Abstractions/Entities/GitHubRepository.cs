namespace GitHubSettingsSync.Repositories.Entities;

/// <summary>
/// GitHubリポジトリに関する設定を表すクラスです。
/// </summary>
/// <param name="HasIssues">Issuesを有効にするかどうか。</param>
/// <param name="HasProjects">Projectsを有効にするかどうか。</param>
/// <param name="HasWiki">Wikiを有効にするかどうか。</param>
/// <param name="HasDiscussions">Discussionsを有効にするかどうか。</param>
/// <param name="AllowMergeCommit">「Create a merge commit」を有効にするかどうか。</param>
/// <param name="AllowSquashMerge">「Squash Merge」を有効にするかどうか。</param>
/// <param name="AllowRebaseMerge">「Rebase and Merge」を有効にするかどうか。</param>
/// <param name="AllowAutoMerge">自動マージ機能を有効にするかどうか。</param>
/// <param name="DeleteBranchOnMerge">プルリクエストマージ時に、ブランチを自動的に削除するかどうか。</param>
/// <param name="AllowUpdateBranch">「Update branch」を有効にするかどうか。</param>
/// <param name="MergeCommitTitle">マージにおけるコミットタイトルの種類。</param>
/// <param name="MergeCommitMessage">マージにおけるコミットメッセージの種類。</param>
/// <param name="SquashMergeCommitTitle">スカッシュマージにおけるコミットタイトルの種類。</param>
/// <param name="SquashMergeCommitMessage">スカッシュマージにおけるコミットメッセージの種類。</param>
public sealed record GitHubRepository(
    bool? HasIssues = null,
    bool? HasProjects = null,
    bool? HasWiki = null,
    bool? HasDiscussions = null,
    bool? AllowMergeCommit = null,
    bool? AllowSquashMerge = null,
    bool? AllowRebaseMerge = null,
    bool? AllowAutoMerge = null,
    bool? DeleteBranchOnMerge = null,
    bool? AllowUpdateBranch = null,
    string? MergeCommitTitle = null,
    string? MergeCommitMessage = null,
    string? SquashMergeCommitTitle = null,
    string? SquashMergeCommitMessage = null);
