﻿using GitHubSettingsSync.Repositories.Entities;
using Microsoft.Extensions.Logging;

namespace GitHubSettingsSync.Repositories;

/// <summary>
/// GitHubリポジトリ設定に関する操作を行うクラスです。
/// </summary>
public sealed partial class GitHubRepositoryRepository : IGitHubRepositoryRepository
{
    readonly ILogger<GitHubRepositoryRepository> _logger;
    readonly IGitHubClient _gitHubClient;

    /// <summary>
    /// <see cref="GitHubRepositoryRepository"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー。</param>
    /// <param name="gitHubClient">GitHubクライアント。</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>または<paramref name="gitHubClient"/>がnullです。</exception>
    public GitHubRepositoryRepository(ILogger<GitHubRepositoryRepository> logger, IGitHubClient gitHubClient)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(gitHubClient);

        _logger = logger;
        _gitHubClient = gitHubClient;
    }

    /// <inheritdoc/>
    public Task UpdateAsync(RepositoryInformation<GitHubRepository> item, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(item);

        Updating();

        return _gitHubClient.UpdateRepositoryAsync(item.Owner, item.Name, item.Settings, cancellationToken);
    }

    [LoggerMessage(EventId = 1001, Level = LogLevel.Debug, Message = "Starting, Update repository settings.")]
    partial void Updating();
}