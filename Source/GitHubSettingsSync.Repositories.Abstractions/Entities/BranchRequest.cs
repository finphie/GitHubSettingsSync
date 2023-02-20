namespace GitHubSettingsSync.Repositories.Entities;

/// <inheritdoc cref="Request{T}" />
/// <summary>
/// ブランチ情報を表すクラスです。
/// </summary>
/// <param name="Branch">ブランチ名。</param>
public sealed record BranchRequest<T>(string Owner, string Name, string Branch, T Settings) : Request<T>(Owner, Name, Settings)
    where T : notnull;
