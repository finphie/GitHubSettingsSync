namespace GitHubSettingsSync.Repositories.Entities;

/// <summary>
/// リクエスト情報を表すクラスです。
/// </summary>
/// <param name="Owner">オーナー名。</param>
/// <param name="Name">リポジトリ名。</param>
public record Request(string Owner, string Name) : IRequest;

/// <summary>
/// リクエスト情報を表すクラスです。
/// </summary>
/// <typeparam name="T">設定クラスの型。</typeparam>
/// <param name="Owner">オーナー名。</param>
/// <param name="Name">リポジトリ名。</param>
/// <param name="Settings">設定。</param>
public sealed record Request<T>(string Owner, string Name, T Settings) : Request(Owner, Name), IRequest<T>
    where T : notnull;
