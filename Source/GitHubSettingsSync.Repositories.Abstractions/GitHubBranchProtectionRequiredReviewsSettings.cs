using System.Text.Json.Serialization;

namespace GitHubSettingsSync.Repositories;

/// <summary>
/// レビューに関するGitHubブランチ保護の設定を表す構造体です。
/// </summary>
/// <param name="DismissStaleReviews">新しいコミットがプッシュされたときに、承認済みのレビューを却下するかどうか。</param>
/// <param name="RequireCodeOwnerReviews">コード所有者のレビューが必須かどうか。</param>
/// <param name="RequiredApprovingReviewCount"> プルリクエストの承認に必要なレビュアーの数。デフォルトは1人。</param>
public sealed record GitHubBranchProtectionRequiredReviewsSettings(
    [property: JsonPropertyName("dismiss_stale_reviews")] bool DismissStaleReviews = false,
    [property: JsonPropertyName("require_code_owner_reviews")] bool RequireCodeOwnerReviews = false,
    RequiredApprovingReviewCount RequiredApprovingReviewCount = default)
{
    /// <summary>
    /// <inheritdoc cref="GitHubBranchProtectionRequiredReviewsSettings(bool, bool, RequiredApprovingReviewCount)" path="/param[@name='RequiredApprovingReviewCount']"/>
    /// </summary>
    [JsonPropertyName("required_approving_review_count")]
    public RequiredApprovingReviewCount RequiredApprovingReviewCount { get; init; } = RequiredApprovingReviewCount == default ? new(1) : RequiredApprovingReviewCount;
}
