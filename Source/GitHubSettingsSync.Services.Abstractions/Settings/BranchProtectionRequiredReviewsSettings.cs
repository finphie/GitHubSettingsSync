﻿using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Settings;

/// <inheritdoc cref="GitHubBranchProtectionRequiredReviews"/>
public sealed record BranchProtectionRequiredReviewsSettings(
    bool DismissStaleReviews = false,
    bool RequireCodeOwnerReviews = false,
    int RequiredApprovingReviewCount = 1);