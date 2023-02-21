namespace GitHubSettingsSync.Services.Settings;

/// <summary>
/// GitHubブランチ保護に関する設定を表すクラスです。
/// </summary>
/// <param name="EnforceAdmins">管理者にも適用するかどうか。</param>
/// <param name="RequiredLinearHistory">直線状の履歴を必須にするかどうか。</param>
/// <param name="AllowForcePushes">強制プッシュを許可するかどうか。</param>
/// <param name="AllowDeletions">プッシュアクセス権を持つユーザーが、保護されたブランチを削除できるようにするかどうか。</param>
/// <param name="RequiredConversationResolution">マージ前にコメントの解決を必須にするかどうか。</param>
/// <param name="RequiredReviews">レビューに関するブランチ保護の設定。</param>
public sealed record BranchProtectionSettings(
    bool EnforceAdmins = false,
    Status RequiredLinearHistory = Status.Unchanged,
    Status AllowForcePushes = Status.Unchanged,
    Status AllowDeletions = Status.Unchanged,
    Status RequiredConversationResolution = Status.Unchanged,
    BranchProtectionRequiredReviewsSettings? RequiredReviews = null);
