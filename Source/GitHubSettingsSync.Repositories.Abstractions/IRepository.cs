namespace GitHubSettingsSync.Repositories;

/// <summary>
/// Repositoryインターフェイスです。
/// </summary>
/// <typeparam name="T">集約ルートの型。</typeparam>
public interface IRepository<T>
    where T : notnull, IAggregateRoot
{
    /// <summary>
    /// 指定されたアイテムで更新します。
    /// </summary>
    /// <param name="item">アイテム。</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン。</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="item"/>がnullです。</exception>
    Task UpdateAsync(T item, CancellationToken cancellationToken = default);
}
