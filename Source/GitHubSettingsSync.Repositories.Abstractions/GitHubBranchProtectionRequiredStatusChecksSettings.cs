namespace GitHubSettingsSync.Repositories;

/// <summary>
/// ステータスチェックに関するGitHubブランチ保護の設定を表す構造体です。
/// </summary>
public readonly record struct GitHubBranchProtectionRequiredStatusChecksSettings
{
    /// <summary>
    /// マージする前にブランチを最新にする必要があるかどうかを取得または設定します。
    /// </summary>
    /// <value>
    /// デフォルトは<see langword="false"/>です。
    /// </value>
    public bool Strict { get; init; }

    /// <summary>
    /// 合格する必要があるステータスチェックのリストを取得または設定します。
    /// </summary>
    public IReadOnlyList<string> Contexts { get; init; }
}
