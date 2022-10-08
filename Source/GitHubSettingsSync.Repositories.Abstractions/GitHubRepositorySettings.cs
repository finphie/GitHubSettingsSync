namespace GitHubSettingsSync.Repositories;

/// <summary>
/// GitHubリポジトリに関する設定を表す構造体です。
/// </summary>
public readonly record struct GitHubRepositorySettings
{
    /// <summary>
    /// Issuesを有効にするかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="null"/>（指定なし）です。
    /// </value>
    public bool? HasIssues { get; init; }

    /// <summary>
    /// Projectsを有効にするかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="null"/>（指定なし）です。
    /// </value>
    public bool? HasProjects { get; init; }

    /// <summary>
    /// Wikiを有効にするかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="null"/>（指定なし）です。
    /// </value>
    public bool? HasWiki { get; init; }

    /// <summary>
    /// 「Create a merge commit」を有効にするかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="null"/>（指定なし）です。
    /// </value>
    public bool? AllowMergeCommit { get; init; }

    /// <summary>
    /// 「Rebase and Merge」を有効にするかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="null"/>（指定なし）です。
    /// </value>
    public bool? AllowRebaseMerge { get; init; }

    /// <summary>
    /// 「Squash Merge」を有効にするかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="null"/>（指定なし）です。
    /// </value>
    public bool? AllowSquashMerge { get; init; }

    /// <summary>
    /// 自動マージ機能を有効にするかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="null"/>（指定なし）です。
    /// </value>
    public bool? AllowAutoMerge { get; init; }

    /// <summary>
    /// プルリクエストマージ時に、ブランチを自動的に削除するかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="null"/>（指定なし）です。
    /// </value>
    public bool? DeleteBranchOnMerge { get; init; }

    /// <summary>
    /// 「Update branch」を有効にするかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="null"/>（指定なし）です。
    /// </value>
    public bool? AllowUpdateBranch { get; init; }
}
