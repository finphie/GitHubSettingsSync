using GitHubSettingsSync.Models.Helpers;
using GitHubSettingsSync.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GitHubSettingsSync.Models;

/// <summary>
/// GitHub設定の更新を行うクラスです。
/// </summary>
public sealed partial class UpdateGitHubSettings : IUpdateGitHubSettings
{
    readonly ILogger<UpdateGitHubSettings> _logger;
    readonly EnvironmentVariables _settings;
    readonly IUpdateGitHubRepositorySettingsService _repositorySettingsService;
    readonly IUpdateGitHubBranchProtectionSettingsService _branchProtectionSettingsService;

    /// <summary>
    /// <see cref="UpdateGitHubSettings"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー。</param>
    /// <param name="settings">環境変数。</param>
    /// <param name="repositorySettingsService">GitHub設定の操作を行うクラスのインスタンス。</param>
    /// <param name="branchProtectionSettingsService">GitHubブランチ保護設定の操作を行うクラスのインスタンス。</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>または<paramref name="settings"/>、<paramref name="repositorySettingsService"/>、<paramref name="branchProtectionSettingsService"/>がnullです。</exception>
    public UpdateGitHubSettings(ILogger<UpdateGitHubSettings> logger, IOptions<EnvironmentVariables> settings, IUpdateGitHubRepositorySettingsService repositorySettingsService, IUpdateGitHubBranchProtectionSettingsService branchProtectionSettingsService)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(settings);
        ArgumentNullException.ThrowIfNull(repositorySettingsService);
        ArgumentNullException.ThrowIfNull(branchProtectionSettingsService);

        _logger = logger;
        _settings = settings.Value;
        _repositorySettingsService = repositorySettingsService;
        _branchProtectionSettingsService = branchProtectionSettingsService;
    }

    /// <inheritdoc/>
    public bool IsError { get; private set; }

    /// <inheritdoc/>
    public async ValueTask ExecuteAsync(IEnumerable<string> repositories, GitHubSettings settings, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(repositories);

        Starting();

        foreach (var repository in repositories)
        {
            if (string.IsNullOrEmpty(repository))
            {
                continue;
            }

            var (owner, repositoryName) = GitHubRepositoryHelper.GetOwnerAndRepositoryName(repository, _settings.GitHubRepositoryOwner);
            GitHubActionsCommand.GroupStart($"{owner}/{repositoryName}");

            try
            {
                await _repositorySettingsService.ExecuteAsync(owner, repositoryName, settings.Repository, cancellationToken).ConfigureAwait(false);

                if (settings.BranchProtection is { } branchProtection)
                {
                    await _branchProtectionSettingsService.ExecuteAsync(owner, repositoryName, settings.Branch, branchProtection, cancellationToken).ConfigureAwait(false);
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
