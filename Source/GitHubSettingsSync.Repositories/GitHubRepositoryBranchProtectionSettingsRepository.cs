using Microsoft.Extensions.Logging;

namespace GitHubSettingsSync.Repositories;

/// <summary>
/// GitHubブランチ保護設定に関する操作を行うクラスです。
/// </summary>
public sealed partial class GitHubRepositoryBranchProtectionSettingsRepository : IGitHubRepositoryBranchProtectionSettingsRepository
{
    readonly ILogger<GitHubRepositoryBranchProtectionSettingsRepository> _logger;
    readonly IGitHubClient _gitHubClient;

    /// <summary>
    /// <see cref="GitHubRepositoryBranchProtectionSettingsRepository"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー。</param>
    /// <param name="gitHubClient">GitHubクライアント。</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>または<paramref name="gitHubClient"/>がnullです。</exception>
    public GitHubRepositoryBranchProtectionSettingsRepository(ILogger<GitHubRepositoryBranchProtectionSettingsRepository> logger, IGitHubClient gitHubClient)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(gitHubClient);

        _logger = logger;
        _gitHubClient = gitHubClient;
    }

    /// <inheritdoc/>
    public Task UpdateAsync(BranchInformation<GitHubBranchProtectionSettings> item, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(item);

        Updating();

        return _gitHubClient.UpdateBranchProtectionAsync(item.Owner, item.Name, item.Branch, item.Settings, cancellationToken);
    }

    [LoggerMessage(EventId = 1001, Level = LogLevel.Debug, Message = "Starting, Update branch protection settings.")]
    partial void Updating();
}
