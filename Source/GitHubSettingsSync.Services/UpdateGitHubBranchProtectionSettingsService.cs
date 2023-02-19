using GitHubSettingsSync.Repositories;
using GitHubSettingsSync.Repositories.Entities;
using GitHubSettingsSync.Services.Extensions;
using GitHubSettingsSync.Services.Settings;
using Microsoft.Extensions.Logging;

namespace GitHubSettingsSync.Services;

/// <summary>
/// GitHubブランチ保護設定の更新を行うクラスです。
/// </summary>
public sealed partial class UpdateGitHubBranchProtectionSettingsService : IUpdateGitHubBranchProtectionSettingsService
{
    readonly ILogger<UpdateGitHubBranchProtectionSettingsService> _logger;
    readonly IGitHubRepositoryBranchProtectionRepository _gitHub;

    /// <summary>
    /// <see cref="UpdateGitHubBranchProtectionSettingsService"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー。</param>
    /// <param name="gitHub">GitHubブランチ保護設定の操作を行うクラスのインスタンス。</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>または<paramref name="gitHub"/>がnullです。</exception>
    public UpdateGitHubBranchProtectionSettingsService(ILogger<UpdateGitHubBranchProtectionSettingsService> logger, IGitHubRepositoryBranchProtectionRepository gitHub)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(gitHub);

        _logger = logger;
        _gitHub = gitHub;
    }

    /// <inheritdoc/>
    public async ValueTask ExecuteAsync(string owner, string repositoryName, string branch, BranchProtectionSettings settings, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(repositoryName);
        ArgumentException.ThrowIfNullOrEmpty(branch);
        ArgumentNullException.ThrowIfNull(settings);

        Starting();

        var item = new BranchInformation<GitHubBranchProtection>(owner, repositoryName, branch, settings.ToEntity());

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

    [LoggerMessage(EventId = 1000, Level = LogLevel.Debug, Message = $"{nameof(UpdateGitHubBranchProtectionSettingsService)} is starting.")]
    partial void Starting();

    [LoggerMessage(EventId = 9000, Level = LogLevel.Error)]
    partial void Error(Exception ex);
}
