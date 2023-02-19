using System.Text.Json.Serialization;

namespace GitHubSettingsSync.Repositories.Entities;

/// <summary>
/// GitHubブランチ保護に関する設定を表すクラスです。
/// </summary>
/// <param name="EnforceAdmins">管理者にも適用するかどうか。</param>
/// <param name="RequiredLinearHistory">直線状の履歴を必須にするかどうか。</param>
/// <param name="AllowForcePushes">強制プッシュを許可するかどうか。</param>
/// <param name="AllowDeletions">プッシュアクセス権を持つユーザーが、保護されたブランチを削除できるようにするかどうか。</param>
/// <param name="RequiredConversationResolution">マージ前にコメントの解決を必須にするかどうか。</param>
/// <param name="RequiredStatusChecks">ステータスチェックに関するブランチ保護の設定。</param>
/// <param name="RequiredReviews">レビューに関するブランチ保護の設定。</param>
/// <param name="Restrictions">保護されたブランチにプッシュできる人のリスト。このプロパティは使用していませんが、GitHub APIリクエストの際に必要です。</param>
public sealed record GitHubBranchProtection(
    [property: JsonPropertyName("enforce_admins")] bool EnforceAdmins = false,
    [property: JsonPropertyName("required_linear_history")] bool? RequiredLinearHistory = null,
    [property: JsonPropertyName("allow_force_pushes")] bool? AllowForcePushes = null,
    [property: JsonPropertyName("allow_deletions")] bool? AllowDeletions = null,
    [property: JsonPropertyName("required_conversation_resolution")] bool? RequiredConversationResolution = null,
    [property: JsonPropertyName("required_status_checks"), JsonIgnore(Condition = JsonIgnoreCondition.Never)] GitHubBranchProtectionRequiredStatusChecks? RequiredStatusChecks = null,
    [property: JsonPropertyName("required_pull_request_reviews"), JsonIgnore(Condition = JsonIgnoreCondition.Never)] GitHubBranchProtectionRequiredReviews? RequiredReviews = null,
    [property: JsonPropertyName("restrictions"), JsonIgnore(Condition = JsonIgnoreCondition.Never), Obsolete("このプロパティは使用できません。", true)] object? Restrictions = null);
