namespace GitHubSettingsSync.Services.Settings;

/// <summary>
/// GitHubリポジトリに関する設定を表すクラスです。
/// </summary>
/// <param name="HasIssues">Issuesを有効にするかどうか。</param>
/// <param name="HasProjects">Projectsを有効にするかどうか。</param>
/// <param name="HasWiki">Wikiを有効にするかどうか。</param>
/// <param name="MergeCommit">マージにおけるコミットタイトル・メッセージの種類。</param>
/// <param name="SquashMergeCommit">スカッシュマージにおけるコミットメッセージの種類。</param>
/// <param name="AllowRebaseMerge">「Rebase and Merge」を有効にするかどうか。</param>
/// <param name="AllowAutoMerge">自動マージ機能を有効にするかどうか。</param>
/// <param name="DeleteBranchOnMerge">プルリクエストマージ時に、ブランチを自動的に削除するかどうか。</param>
/// <param name="AllowUpdateBranch">「Update branch」を有効にするかどうか。</param>
public sealed record RepositorySettings(
    Status HasIssues = Status.Unchanged,
    Status HasProjects = Status.Unchanged,
    Status HasWiki = Status.Unchanged,
    MergeCommit? MergeCommit = null,
    SquashMergeCommit? SquashMergeCommit = null,
    Status AllowRebaseMerge = Status.Unchanged,
    Status AllowAutoMerge = Status.Unchanged,
    Status DeleteBranchOnMerge = Status.Unchanged,
    Status AllowUpdateBranch = Status.Unchanged);
