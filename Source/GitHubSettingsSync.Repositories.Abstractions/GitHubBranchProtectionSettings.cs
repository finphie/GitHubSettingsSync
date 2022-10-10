namespace GitHubSettingsSync.Repositories;

/// <summary>
/// GitHubブランチ保護に関する設定を表す構造体です。
/// </summary>
public readonly record struct GitHubBranchProtectionSettings
{
    /// <summary>
    /// 管理者にも適用するかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="false"/>です。
    /// </value>
    public bool EnforceAdmins { get; init; }

    /// <summary>
    /// 直線状の履歴を必須にするかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="false"/>です。
    /// </value>
    public bool RequiredLinearHistory { get; init; }

    /// <summary>
    /// 強制プッシュを許可するかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="false"/>です。
    /// </value>
    public bool AllowForcePushes { get; init; }

    /// <summary>
    /// プッシュアクセス権を持つユーザーが、保護されたブランチを削除できるようにするかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="false"/>です。
    /// </value>
    public bool AllowDeletions { get; init; }

    /// <summary>
    /// マージ前にコメントの解決を必須にするかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="false"/>です。
    /// </value>
    public bool RequiredConversationResolution { get; init; }

    /// <summary>
    /// ステータスチェックに関するブランチ保護の設定を取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="null"/>（指定なし）です。
    /// </value>
    public GitHubBranchProtectionRequiredStatusChecksSettings? RequiredStatusChecks { get; init; }

    /// <summary>
    /// レビューに関するブランチ保護の設定を取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="null"/>（指定なし）です。
    /// </value>
    public GitHubBranchProtectionRequiredReviewsSettings? RequiredReviews { get; init; }
}
