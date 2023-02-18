using System.Text.Json.Serialization;

namespace GitHubSettingsSync.Repositories.Entities;

/// <summary>
/// レビューに関するGitHubブランチ保護の設定を表す構造体です。
/// </summary>
/// <param name="DismissStaleReviews">新しいコミットがプッシュされたときに、承認済みのレビューを却下するかどうか。</param>
/// <param name="RequireCodeOwnerReviews">コード所有者のレビューが必須かどうか。</param>
/// <param name="RequiredApprovingReviewCount"> プルリクエストの承認に必要なレビュアーの数。</param>
public sealed record GitHubBranchProtectionRequiredReviews(
    [property: JsonPropertyName("dismiss_stale_reviews")] bool DismissStaleReviews = false,
    [property: JsonPropertyName("require_code_owner_reviews")] bool RequireCodeOwnerReviews = false,
    [property: JsonPropertyName("required_approving_review_count")] int RequiredApprovingReviewCount = 1);
