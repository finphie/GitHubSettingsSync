using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Repositories;

/// <summary>
/// GitHub APIのクライアントに関するインターフェイスです。
/// </summary>
public interface IGitHubClient
{
    /// <summary>
    /// GitHubリポジトリに関する設定を更新します。
    /// </summary>
    /// <param name="owner">オーナー名。</param>
    /// <param name="name">リポジトリ名。</param>
    /// <param name="entity">GitHubリポジトリに関する設定。</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン。</param>
    /// <remarks>
    /// 詳しくは、<a href="https://docs.github.com/rest/repos/repos">APIドキュメント</a>を参照してください。
    /// </remarks>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="owner"/>または<paramref name="name"/>、<paramref name="entity"/>がnullです。</exception>
    /// <exception cref="ArgumentException"><paramref name="owner"/>または<paramref name="name"/>が空です。</exception>
    /// <exception cref="HttpRequestException">HTTPリクエストに失敗しました。</exception>
    Task UpdateRepositoryAsync(string owner, string name, GitHubRepository entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// GitHubブランチ保護に関する設定を更新します。
    /// </summary>
    /// <param name="owner">オーナー名。</param>
    /// <param name="name">リポジトリ名。</param>
    /// <param name="branch">ブランチ名。</param>
    /// <param name="entity">GitHubブランチ保護に関する設定。</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン。</param>
    /// <remarks>
    /// 詳しくは、<a href="https://docs.github.com/rest/branches/branches">APIドキュメント</a>を参照してください。
    /// </remarks>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="owner"/>または<paramref name="name"/>、<paramref name="branch"/>、<paramref name="entity"/>がnullです。</exception>
    /// <exception cref="ArgumentException"><paramref name="owner"/>または<paramref name="name"/>、<paramref name="branch"/>が空です。</exception>
    /// <exception cref="HttpRequestException">HTTPリクエストに失敗しました。</exception>
    Task UpdateBranchProtectionAsync(string owner, string name, string branch, GitHubBranchProtection entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// GitHubブランチ保護に関する設定を削除します。
    /// </summary>
    /// <param name="owner">オーナー名。</param>
    /// <param name="name">リポジトリ名。</param>
    /// <param name="branch">ブランチ名。</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン。</param>
    /// <remarks>
    /// 詳しくは、<a href="https://docs.github.com/rest/branches/branches">APIドキュメント</a>を参照してください。
    /// </remarks>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="owner"/>または<paramref name="name"/>、<paramref name="branch"/>がnullです。</exception>
    /// <exception cref="ArgumentException"><paramref name="owner"/>または<paramref name="name"/>、<paramref name="branch"/>が空です。</exception>
    /// <exception cref="HttpRequestException">HTTPリクエストに失敗しました。</exception>
    Task DeleteBranchProtectionAsync(string owner, string name, string branch, CancellationToken cancellationToken = default);
}
