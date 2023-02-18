using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Entities;

/// <inheritdoc cref="GitHubBranchProtectionRequiredReviews"/>
public sealed record GitHubBranchProtectionRequiredReviewsSettings(
    bool DismissStaleReviews = false,
    bool RequireCodeOwnerReviews = false,
    int RequiredApprovingReviewCount = 1);
