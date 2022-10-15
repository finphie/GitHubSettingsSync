using GitHubSettingsSync.Repositories;

namespace GitHubSettingsSync.Services;

/// <summary>
/// GitHubリポジトリ設定の更新に関するインターフェイスです。
/// </summary>
public interface IUpdateGitHubRepositorySettingsService
{
    /// <summary>
    /// GitHubリポジトリの設定を更新します。
    /// </summary>
    /// <param name="owner">オーナー名。</param>
    /// <param name="repositoryName">リポジトリ名。</param>
    /// <param name="settings">GitHubリポジトリに関する設定。</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン。</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="owner"/>または<paramref name="repositoryName"/>がnullです。</exception>
    /// <exception cref="ArgumentException"><paramref name="owner"/>または<paramref name="repositoryName"/>が空です。</exception>
    ValueTask ExecuteAsync(string owner, string repositoryName, GitHubRepositorySettings settings, CancellationToken cancellationToken = default);
}
