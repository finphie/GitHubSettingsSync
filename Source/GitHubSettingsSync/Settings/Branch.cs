using FToolkit.Net.GitHub.Client.Branches.BranchProtection;

namespace GitHubSettingsSync.Settings;

/// <summary>
/// ブランチに関する設定を表すクラスです。
/// </summary>
/// <param name="Name">ブランチ名</param>
/// <param name="BranchProtection">ブランチ保護に関する設定</param>
sealed record Branch(string Name, BranchProtection BranchProtection);
