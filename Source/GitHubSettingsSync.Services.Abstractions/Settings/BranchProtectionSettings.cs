using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Settings;

/// <inheritdoc cref="GitHubBranchProtection"/>
public sealed record BranchProtectionSettings(
    bool EnforceAdmins = false,
    bool RequiredLinearHistory = false,
    bool AllowForcePushes = false,
    bool AllowDeletions = false,
    bool RequiredConversationResolution = false,
    BranchProtectionRequiredReviewsSettings? RequiredReviews = null);
