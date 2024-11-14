using FToolkit.Net.GitHub.Client.Repositories;

namespace GitHubSettingsSync.Settings;

/// <summary>
/// GitHubに関する設定を表すクラスです。
/// </summary>
/// <param name="Repository">リポジトリに関する設定</param>
/// <param name="Branches">ブランチに関する設定</param>
sealed record GitHubSettings(Repository Repository, IReadOnlyList<Branch> Branches);
