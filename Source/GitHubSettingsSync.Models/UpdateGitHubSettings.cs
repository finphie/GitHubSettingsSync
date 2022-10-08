using GitHubSettingsSync.Services;
using Microsoft.Extensions.Logging;

namespace GitHubSettingsSync.Models;

/// <summary>
/// GitHub設定の更新を行うクラスです。
/// </summary>
public sealed partial class UpdateGitHubSettings : IUpdateGitHubSettings
{
    readonly ILogger<UpdateGitHubSettings> _logger;
    readonly IUpdateGitHubRepositorySettingsService _repositorySettingsService;
    readonly IUpdateGitHubBranchProtectionSettingsService _branchProtectionSettingsService;

    /// <summary>
    /// <see cref="UpdateGitHubSettings"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー。</param>
    /// <param name="repositorySettingsService">GitHub設定の操作を行うクラスのインスタンス。</param>
    /// <param name="branchProtectionSettingsService">GitHubブランチ保護設定の操作を行うクラスのインスタンス。</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>または<paramref name="repositorySettingsService"/>、<paramref name="branchProtectionSettingsService"/>がnullです。</exception>
    public UpdateGitHubSettings(ILogger<UpdateGitHubSettings> logger, IUpdateGitHubRepositorySettingsService repositorySettingsService, IUpdateGitHubBranchProtectionSettingsService branchProtectionSettingsService)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(repositorySettingsService);
        ArgumentNullException.ThrowIfNull(branchProtectionSettingsService);

        _logger = logger;
        _repositorySettingsService = repositorySettingsService;
        _branchProtectionSettingsService = branchProtectionSettingsService;
    }

    /// <inheritdoc/>
    public bool IsError { get; private set; }

    /// <inheritdoc/>
    public async ValueTask ExecuteAsync(IEnumerable<string> repositoryNames, GitHubSettings settings, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(repositoryNames);

        Starting();

        foreach (var repositoryName in repositoryNames)
        {
            GitHubActionsCommand.GroupStart(repositoryName);

            try
            {
                await _repositorySettingsService.ExecuteAsync(repositoryName, settings.Repository, cancellationToken).ConfigureAwait(false);

                if (settings.BranchProtection is { } branchProtection)
                {
                    await _branchProtectionSettingsService.ExecuteAsync(repositoryName, settings.Branch, branchProtection, cancellationToken).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Error(ex);
                IsError = true;
            }
            finally
            {
                GitHubActionsCommand.GroupEnd();
            }
        }
    }

    [LoggerMessage(EventId = 1000, Level = LogLevel.Information, Message = $"{nameof(UpdateGitHubSettings)} is starting.")]
    partial void Starting();

    [LoggerMessage(EventId = 9000, Level = LogLevel.Error)]
    partial void Error(Exception ex);
}
