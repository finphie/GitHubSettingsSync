using GitHubSettingsSync.Repositories;
using GitHubSettingsSync.Repositories.Entities;
using GitHubSettingsSync.Services.Extensions;
using GitHubSettingsSync.Services.Settings;
using Microsoft.Extensions.Logging;

namespace GitHubSettingsSync.Services;

/// <summary>
/// GitHubリポジトリ設定の更新を行うクラスです。
/// </summary>
public sealed partial class UpdateGitHubRepositorySettingsService : IUpdateGitHubRepositorySettingsService
{
    readonly ILogger<UpdateGitHubRepositorySettingsService> _logger;
    readonly IGitHubRepositoryRepository _gitHub;

    /// <summary>
    /// <see cref="UpdateGitHubRepositorySettingsService"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー。</param>
    /// <param name="gitHub">GitHubリポジトリ設定の操作を行うクラスのインスタンス。</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>または<paramref name="gitHub"/>がnullです。</exception>
    public UpdateGitHubRepositorySettingsService(ILogger<UpdateGitHubRepositorySettingsService> logger, IGitHubRepositoryRepository gitHub)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(gitHub);

        _logger = logger;
        _gitHub = gitHub;
    }

    /// <inheritdoc/>
    public async ValueTask ExecuteAsync(string owner, string repositoryName, RepositorySettings settings, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(owner);
        ArgumentException.ThrowIfNullOrEmpty(repositoryName);
        ArgumentNullException.ThrowIfNull(settings);

        Starting();

        var item = new Request<GitHubRepository>(owner, repositoryName, settings.ToEntity());

        try
        {
            await _gitHub.UpdateAsync(item, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Error(ex);
            throw;
        }
    }

    [LoggerMessage(EventId = 1000, Level = LogLevel.Debug, Message = $"{nameof(UpdateGitHubRepositorySettingsService)} is starting.")]
    partial void Starting();

    [LoggerMessage(EventId = 9000, Level = LogLevel.Error)]
    partial void Error(Exception ex);
}
