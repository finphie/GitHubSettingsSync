using GitHubSettingsSync.Repositories.Extensions;
using Microsoft.Extensions.Logging;
using Octokit;

namespace GitHubSettingsSync.Repositories;

/// <summary>
/// GitHubリポジトリ設定に関する操作を行うクラスです。
/// </summary>
public sealed partial class GitHubRepositorySettingsRepository : IGitHubRepositorySettingsRepository
{
    readonly ILogger<GitHubRepositorySettingsRepository> _logger;
    readonly IGitHubClient _gitHubClient;

    /// <summary>
    /// <see cref="GitHubRepositorySettingsRepository"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー。</param>
    /// <param name="gitHubClient">GitHubクライアント。</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>または<paramref name="gitHubClient"/>がnullです。</exception>
    public GitHubRepositorySettingsRepository(ILogger<GitHubRepositorySettingsRepository> logger, IGitHubClient gitHubClient)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(gitHubClient);

        _logger = logger;
        _gitHubClient = gitHubClient;
    }

    /// <inheritdoc/>
    public Task Update(RepositoryInformation<GitHubRepositorySettings> item, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(item);

        Updating();

        var update = item.Settings.ToRepositoryUpdate();
        return _gitHubClient.Repository.Edit(item.Owner, item.Name, update);
    }

    [LoggerMessage(EventId = 1001, Level = LogLevel.Information, Message = "Updating repository options.")]
    partial void Updating();
}
