using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Repositories;

/// <summary>
/// GitHubブランチ保護設定に関する操作を定義するインターフェイスです。
/// </summary>
public interface IGitHubRepositoryBranchProtectionRepository : IUpdateRepository<BranchRequest<GitHubBranchProtection>>
{
}
