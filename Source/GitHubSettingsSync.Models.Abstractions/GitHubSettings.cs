using GitHubSettingsSync.Services.Settings;

namespace GitHubSettingsSync.Models;

/// <summary>
/// GitHub設定を表すクラスです。
/// </summary>
public sealed record GitHubSettings
{
    /// <summary>
    /// GitHubリポジトリに関する設定を表すクラスのインスタンスを取得または設定します。
    /// </summary>
    public required RepositorySettings Repository { get; init; }

    /// <summary>
    /// ブランチ名を取得または設定します。
    /// </summary>
    public required string Branch { get; init; }

    /// <summary>
    /// GitHubブランチ保護の設定有無を取得または設定します。
    /// </summary>
    public required bool IsBranchProtection { get; init; }

    /// <summary>
    /// GitHubブランチ保護に関する設定を表すクラスのインスタンスを取得または設定します。
    /// </summary>
    public required BranchProtectionSettings? BranchProtection { get; init; }
}
