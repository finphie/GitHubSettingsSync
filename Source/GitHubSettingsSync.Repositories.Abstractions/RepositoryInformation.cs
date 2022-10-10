namespace GitHubSettingsSync.Repositories;

/// <summary>
/// リポジトリ情報を表すクラスです。
/// </summary>
/// <typeparam name="T">設定の型。</typeparam>
/// <param name="Owner">オーナー。</param>
/// <param name="Name">リポジトリ名。</param>
/// <param name="Settings">設定。</param>
public record RepositoryInformation<T>(string Owner, string Name, T Settings) : IAggregateRoot
    where T : notnull;
