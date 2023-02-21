namespace GitHubSettingsSync.Repositories.Entities;

/// <summary>
/// リクエスト情報を表すクラスです。
/// </summary>
public interface IRequest : IAggregateRoot
{
    /// <summary>
    /// オーナー名。
    /// </summary>
    string Owner { get; init; }

    /// <summary>
    /// リポジトリ名。
    /// </summary>
    string Name { get; init; }
}

/// <summary>
/// リクエスト情報を表すクラスです。
/// </summary>
/// <typeparam name="T">設定クラスの型。</typeparam>
public interface IRequest<T> : IRequest
{
    /// <summary>
    /// 設定。
    /// </summary>
    T Settings { get; init; }
}
