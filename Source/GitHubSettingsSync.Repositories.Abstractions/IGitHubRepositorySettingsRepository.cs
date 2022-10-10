namespace GitHubSettingsSync.Repositories;

/// <summary>
/// GitHubリポジトリ設定に関する操作を定義するインターフェイスです。
/// </summary>
public interface IGitHubRepositorySettingsRepository : IRepository<RepositoryInformation<GitHubRepositorySettings>>
{
}
