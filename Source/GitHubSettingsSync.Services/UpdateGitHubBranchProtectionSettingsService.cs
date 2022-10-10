using GitHubSettingsSync.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GitHubSettingsSync.Services;

/// <summary>
/// GitHubブランチ保護設定の更新を行うクラスです。
/// </summary>
public sealed partial class UpdateGitHubBranchProtectionSettingsService : IUpdateGitHubBranchProtectionSettingsService
{
    readonly ILogger<UpdateGitHubBranchProtectionSettingsService> _logger;
    readonly EnvironmentVariables _settings;
    readonly IGitHubRepositoryBranchProtectionSettingsRepository _gitHub;

    /// <summary>
    /// <see cref="UpdateGitHubBranchProtectionSettingsService"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー。</param>
    /// <param name="settings">環境変数。</param>
    /// <param name="gitHub">GitHubブランチ保護設定の操作を行うクラスのインスタンス。</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>または<paramref name="settings"/>、<paramref name="gitHub"/>がnullです。</exception>
    public UpdateGitHubBranchProtectionSettingsService(ILogger<UpdateGitHubBranchProtectionSettingsService> logger, IOptions<EnvironmentVariables> settings, IGitHubRepositoryBranchProtectionSettingsRepository gitHub)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(settings);
        ArgumentNullException.ThrowIfNull(gitHub);

        _logger = logger;
        _settings = settings.Value;
        _gitHub = gitHub;
    }

    /// <inheritdoc/>
    public async ValueTask ExecuteAsync(string repositoryName, string branch, GitHubBranchProtectionSettings settings, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(repositoryName);
        ArgumentException.ThrowIfNullOrEmpty(branch);

        Starting();

        try
        {
            await _gitHub.Update(new(_settings.GitHubRepositoryOwner, repositoryName, branch, settings), cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Error(ex);
            throw;
        }
    }

    [LoggerMessage(EventId = 1000, Level = LogLevel.Information, Message = $"{nameof(UpdateGitHubBranchProtectionSettingsService)} is starting.")]
    partial void Starting();

    [LoggerMessage(EventId = 9000, Level = LogLevel.Error)]
    partial void Error(Exception ex);
}
