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
    public Task UpdateAsync(BranchRequest<GitHubBranchProtection> request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        Updating();

        return _gitHubClient.UpdateBranchProtectionAsync(request.Owner, request.Name, request.Branch, request.Settings, cancellationToken);
    }

    /// <inheritdoc/>
    public Task DeleteAsync(BranchRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        Deleting();

        return _gitHubClient.DeleteBranchProtectionAsync(request.Owner, request.Name, request.Branch, cancellationToken);
    }

    [LoggerMessage(EventId = 1100, Level = LogLevel.Debug, Message = "Starting, Update branch protection settings.")]
    partial void Updating();

    [LoggerMessage(EventId = 1200, Level = LogLevel.Debug, Message = "Deleting, Delete branch protection settings.")]
    partial void Deleting();
}
