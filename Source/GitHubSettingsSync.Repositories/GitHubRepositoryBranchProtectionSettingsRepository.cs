using GitHubSettingsSync.Repositories.Extensions;
using Microsoft.Extensions.Logging;
using Octokit;

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
    public Task Update(BranchInformation<GitHubBranchProtectionSettings> item, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(item);

        Updating();

        var update = item.Settings.ToBranchProtectionSettingsUpdate();
        return _gitHubClient.Repository.Branch.UpdateBranchProtection(item.Owner, item.Name, item.Branch, update);
    }

    [LoggerMessage(EventId = 1001, Level = LogLevel.Information, Message = "Updating branch protection options.")]
    partial void Updating();
}
