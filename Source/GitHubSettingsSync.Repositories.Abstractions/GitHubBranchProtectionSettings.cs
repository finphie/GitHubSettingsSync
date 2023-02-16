using System.Text.Json.Serialization;

namespace GitHubSettingsSync.Repositories;

/// <summary>
/// GitHubブランチ保護に関する設定を表す構造体です。
/// </summary>
public sealed record GitHubBranchProtectionSettings
{
    /// <summary>
    /// 管理者にも適用するかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="false"/>です。
    /// </value>
    [JsonPropertyName("enforce_admins")]
    public bool EnforceAdmins { get; init; }

    /// <summary>
    /// 直線状の履歴を必須にするかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="false"/>です。
    /// </value>
    [JsonPropertyName("required_linear_history")]
    public bool RequiredLinearHistory { get; init; }

    /// <summary>
    /// 強制プッシュを許可するかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="false"/>です。
    /// </value>
    [JsonPropertyName("allow_force_pushes")]
    public bool AllowForcePushes { get; init; }

    /// <summary>
    /// プッシュアクセス権を持つユーザーが、保護されたブランチを削除できるようにするかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="false"/>です。
    /// </value>
    [JsonPropertyName("allow_deletions")]
    public bool AllowDeletions { get; init; }

    /// <summary>
    /// マージ前にコメントの解決を必須にするかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="false"/>です。
    /// </value>
    [JsonPropertyName("required_conversation_resolution")]
    public bool RequiredConversationResolution { get; init; }

    /// <summary>
    /// ステータスチェックに関するブランチ保護の設定を取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="null"/>（指定なし）です。
    /// </value>
    [JsonPropertyName("required_status_checks")]
    public GitHubBranchProtectionRequiredStatusChecksSettings? RequiredStatusChecks { get; init; }

    /// <summary>
    /// レビューに関するブランチ保護の設定を取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="null"/>（指定なし）です。
    /// </value>
    [JsonPropertyName("required_pull_request_reviews")]
    public GitHubBranchProtectionRequiredReviewsSettings? RequiredReviews { get; init; }
}
