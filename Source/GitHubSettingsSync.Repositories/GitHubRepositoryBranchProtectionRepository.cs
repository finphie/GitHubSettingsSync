using GitHubSettingsSync.Repositories.Entities;
using Microsoft.Extensions.Logging;

namespace GitHubSettingsSync.Repositories;

/// <summary>
/// GitHubブランチ保護設定に関する操作を行うクラスです。
/// </summary>
public sealed partial class GitHubRepositoryBranchProtectionRepository : IGitHubRepositoryBranchProtectionRepository
{
    readonly ILogger<GitHubRepositoryBranchProtectionRepository> _logger;
    readonly IGitHubClient _gitHubClient;

    /// <summary>
    /// <see cref="GitHubRepositoryBranchProtectionRepository"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー。</param>
    /// <param name="gitHubClient">GitHubクライアント。</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>または<paramref name="gitHubClient"/>がnullです。</exception>
    public GitHubRepositoryBranchProtectionRepository(ILogger<GitHubRepositoryBranchProtectionRepository> logger, IGitHubClient gitHubClient)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(gitHubClient);

        _logger = logger;
        _gitHubClient = gitHubClient;
    }

    /// <inheritdoc/>
    public Task UpdateAsync(BranchInformation<GitHubBranchProtection> item, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(item);

        Updating();

        return _gitHubClient.UpdateBranchProtectionAsync(item.Owner, item.Name, item.Branch, item.Settings, cancellationToken);
    }

    [LoggerMessage(EventId = 1001, Level = LogLevel.Debug, Message = "Starting, Update branch protection settings.")]
    partial void Updating();
}
