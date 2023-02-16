using System.Text.Json.Serialization;

namespace GitHubSettingsSync.Repositories;

/// <summary>
/// GitHubブランチ保護に関する設定を表す構造体です。
/// </summary>
/// <param name="EnforceAdmins">管理者にも適用するかどうか。</param>
/// <param name="RequiredLinearHistory">直線状の履歴を必須にするかどうか。</param>
/// <param name="AllowForcePushes">強制プッシュを許可するかどうか。</param>
/// <param name="AllowDeletions">プッシュアクセス権を持つユーザーが、保護されたブランチを削除できるようにするかどうか。</param>
/// <param name="RequiredConversationResolution">マージ前にコメントの解決を必須にするかどうか。</param>
/// <param name="RequiredStatusChecks">ステータスチェックに関するブランチ保護の設定。</param>
/// <param name="RequiredReviews">レビューに関するブランチ保護の設定。</param>
public sealed record GitHubBranchProtectionSettings(
    [property: JsonPropertyName("enforce_admins")] bool EnforceAdmins = false,
    [property: JsonPropertyName("required_linear_history")] bool RequiredLinearHistory = false,
    [property: JsonPropertyName("allow_force_pushes")] bool AllowForcePushes = false,
    [property: JsonPropertyName("allow_deletions")] bool AllowDeletions = false,
    [property: JsonPropertyName("required_conversation_resolution")] bool RequiredConversationResolution = false,
    [property: JsonPropertyName("required_status_checks")] GitHubBranchProtectionRequiredStatusChecksSettings? RequiredStatusChecks = null,
    [property: JsonPropertyName("required_pull_request_reviews")] GitHubBranchProtectionRequiredReviewsSettings? RequiredReviews = null);
