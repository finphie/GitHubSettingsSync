using GitHubSettingsSync.Repositories;

namespace GitHubSettingsSync.Services;

/// <summary>
/// GitHubブランチ保護設定の更新に関するインターフェイスです。
/// </summary>
public interface IUpdateGitHubBranchProtectionSettingsService
{
    /// <summary>
    /// GitHubブランチ保護の設定を更新します。
    /// </summary>
    /// <param name="repositoryName">リポジトリ名。</param>
    /// <param name="branch">ブランチ名。</param>
    /// <param name="settings">GitHubブランチ保護に関する設定。</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン。</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="repositoryName"/>または<paramref name="branch"/>がnullです。</exception>
    /// <exception cref="ArgumentException"><paramref name="repositoryName"/>または<paramref name="branch"/>が空です。</exception>
    ValueTask ExecuteAsync(string repositoryName, string branch, GitHubBranchProtectionSettings settings, CancellationToken cancellationToken = default);
}
