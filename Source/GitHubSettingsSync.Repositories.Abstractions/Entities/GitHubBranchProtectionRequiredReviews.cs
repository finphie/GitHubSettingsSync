namespace GitHubSettingsSync.Repositories.Entities;

/// <summary>
/// レビューに関するGitHubブランチ保護の設定を表すクラスです。
/// </summary>
/// <param name="DismissStaleReviews">新しいコミットがプッシュされたときに、承認済みのレビューを却下するかどうか。</param>
/// <param name="RequireCodeOwnerReviews">コード所有者のレビューが必須かどうか。</param>
/// <param name="RequiredApprovingReviewCount"> プルリクエストの承認に必要なレビュアーの数。</param>
public sealed record GitHubBranchProtectionRequiredReviews(
    bool DismissStaleReviews = false,
    bool RequireCodeOwnerReviews = false,
    int RequiredApprovingReviewCount = 1);
