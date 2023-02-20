using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Repositories;

/// <summary>
/// 削除関連のRepositoryインターフェイスです。
/// </summary>
/// <typeparam name="T">リクエスト情報を表すクラスの型。</typeparam>
public interface IDeleteRepository<T> : IRepository<T>
    where T : notnull, IRequest
{
    /// <summary>
    /// 指定されたリクエスト情報で削除処理を実行します。
    /// </summary>
    /// <param name="request">リクエスト情報。</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン。</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="request"/>がnullです。</exception>
    Task DeleteAsync(T request, CancellationToken cancellationToken = default);
}
