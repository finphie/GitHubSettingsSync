using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Repositories;

/// <summary>
/// GitHubリポジトリ設定に関する操作を定義するインターフェイスです。
/// </summary>
public interface IGitHubRepositoryRepository : IUpdateRepository<Request<GitHubRepository>>
{
}
