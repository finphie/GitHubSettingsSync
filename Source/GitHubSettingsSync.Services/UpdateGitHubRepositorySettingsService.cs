using GitHubSettingsSync.Repositories;
using Microsoft.Extensions.Logging;

namespace GitHubSettingsSync.Services;

/// <summary>
/// GitHubリポジトリ設定の更新を行うクラスです。
/// </summary>
public sealed partial class UpdateGitHubRepositorySettingsService : IUpdateGitHubRepositorySettingsService
{
    readonly ILogger<UpdateGitHubRepositorySettingsService> _logger;
    readonly IGitHubRepositorySettingsRepository _gitHub;

    /// <summary>
    /// <see cref="UpdateGitHubRepositorySettingsService"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー。</param>
    /// <param name="gitHub">GitHubリポジトリ設定の操作を行うクラスのインスタンス。</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>または<paramref name="gitHub"/>がnullです。</exception>
    public UpdateGitHubRepositorySettingsService(ILogger<UpdateGitHubRepositorySettingsService> logger, IGitHubRepositorySettingsRepository gitHub)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(gitHub);

        _logger = logger;
        _gitHub = gitHub;
    }

    /// <inheritdoc/>
    public async ValueTask ExecuteAsync(string owner, string repositoryName, GitHubRepositorySettings settings, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(owner);
        ArgumentException.ThrowIfNullOrEmpty(repositoryName);
        ArgumentNullException.ThrowIfNull(settings);

        Starting();

        try
        {
            await _gitHub.Update(new(owner, repositoryName, settings), cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Error(ex);
            throw;
        }
    }

    [LoggerMessage(EventId = 1000, Level = LogLevel.Information, Message = $"{nameof(UpdateGitHubRepositorySettingsService)} is starting.")]
    partial void Starting();

    [LoggerMessage(EventId = 9000, Level = LogLevel.Error)]
    partial void Error(Exception ex);
}
