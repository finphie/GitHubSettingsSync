namespace GitHubSettingsSync.Repositories;

/// <summary>
/// Repositoryインターフェイスです。
/// </summary>
/// <typeparam name="T">集約ルートの型。</typeparam>
public interface IRepository<T>
    where T : notnull, IAggregateRoot
{
}
