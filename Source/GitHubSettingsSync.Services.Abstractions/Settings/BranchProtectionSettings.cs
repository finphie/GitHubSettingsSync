using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Settings;

/// <inheritdoc cref="GitHubBranchProtection"/>
public sealed record BranchProtectionSettings(
    bool EnforceAdmins = false,
    Status RequiredLinearHistory = Status.Unchanged,
    Status AllowForcePushes = Status.Unchanged,
    Status AllowDeletions = Status.Unchanged,
    Status RequiredConversationResolution = Status.Unchanged,
    BranchProtectionRequiredReviewsSettings? RequiredReviews = null);
