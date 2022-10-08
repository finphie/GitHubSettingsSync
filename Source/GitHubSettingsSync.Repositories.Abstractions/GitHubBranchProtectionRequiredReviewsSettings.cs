namespace GitHubSettingsSync.Repositories;

/// <summary>
/// レビューに関するGitHubブランチ保護の設定を表す構造体です。
/// </summary>
public readonly record struct GitHubBranchProtectionRequiredReviewsSettings
{
    /// <summary>
    /// <see cref="GitHubBranchProtectionRequiredReviewsSettings"/>構造体の新しいインスタンスを初期化します。
    /// </summary>
    public GitHubBranchProtectionRequiredReviewsSettings()
    {
    }

    /// <summary>
    /// 新しいコミットがプッシュされたときに、承認済みのレビューを却下するかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="false"/>です。
    /// </value>
    public bool DismissStaleReviews { get; init; }

    /// <summary>
    /// コード所有者のレビューが必須かどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="false"/>です。
    /// </value>
    public bool RequireCodeOwnerReviews { get; init; }

    /// <summary>
    /// プルリクエストの承認に必要なレビュアーの数を取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは1人です。
    /// </value>
    public RequiredApprovingReviewCount RequiredApprovingReviewCount { get; init; } = RequiredApprovingReviewCount.Default;
}
