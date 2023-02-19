using System.Diagnostics.CodeAnalysis;
using GitHubSettingsSync.Services.Settings;

namespace GitHubSettingsSync.Models;

/// <summary>
/// GitHub設定を表す構造体です。
/// </summary>
[SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1206:Declaration keywords should follow order", Justification = "StyleCop.Analyzersの不具合。https://github.com/DotNetAnalyzers/StyleCopAnalyzers/issues/3527")]
public sealed record GitHubSettings
{
    /// <summary>
    /// GitHubリポジトリに関する設定を表す構造体のインスタンスを取得または設定します。
    /// </summary>
    public required RepositorySettings Repository { get; init; }

    /// <summary>
    /// ブランチ名を取得または設定します。
    /// </summary>
    public required string Branch { get; init; }

    /// <summary>
    /// GitHubブランチ保護に関する設定を表す構造体のインスタンスを取得または設定します。
    /// </summary>
    public required BranchProtectionSettings? BranchProtection { get; init; }
}
