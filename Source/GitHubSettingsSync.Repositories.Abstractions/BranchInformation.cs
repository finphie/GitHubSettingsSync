namespace GitHubSettingsSync.Repositories;

/// <summary>
/// ブランチ情報を表すクラスです。
/// </summary>
/// <typeparam name="T">設定の型。</typeparam>
/// <param name="Owner">オーナー。</param>
/// <param name="Name">リポジトリ名。</param>
/// <param name="Branch">ブランチ名。</param>
/// <param name="Settings">設定。</param>
public sealed record BranchInformation<T>(string Owner, string Name, string Branch, T Settings) : RepositoryInformation<T>(Owner, Name, Settings)
    where T : notnull;
