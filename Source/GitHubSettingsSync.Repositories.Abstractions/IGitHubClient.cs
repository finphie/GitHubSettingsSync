﻿namespace GitHubSettingsSync.Repositories;

/// <summary>
/// GitHub APIのクライアントに関するインターフェイスです。
/// </summary>
public interface IGitHubClient
{
    /// <summary>
    /// GitHubリポジトリに関する設定を更新します。
    /// </summary>
    /// <param name="owner">オーナー。</param>
    /// <param name="name">リポジトリ名。</param>
    /// <param name="settings">GitHubリポジトリに関する設定。</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン。</param>
    /// <remarks>
    /// 詳しくは、<a href="https://docs.github.com/rest/repos/repos">APIドキュメント</a>を参照。
    /// </remarks>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="owner"/>または<paramref name="name"/>、<paramref name="settings"/>がnullです。</exception>
    /// <exception cref="ArgumentException"><paramref name="owner"/>または<paramref name="name"/>が空です。</exception>
    Task UpdateRepositoryAsync(string owner, string name, GitHubRepositorySettings settings, CancellationToken cancellationToken = default);

    /// <summary>
    /// GitHubブランチ保護に関する設定を更新します。
    /// </summary>
    /// <param name="owner">オーナー。</param>
    /// <param name="name">リポジトリ名。</param>
    /// <param name="branch">ブランチ。</param>
    /// <param name="settings">GitHubブランチ保護に関する設定。</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン。</param>
    /// <remarks>
    /// 詳しくは、<a href="https://docs.github.com/rest/branches/branches">APIドキュメント</a>を参照。
    /// </remarks>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="owner"/>または<paramref name="name"/>、<paramref name="branch"/>、<paramref name="settings"/>がnullです。</exception>
    /// <exception cref="ArgumentException"><paramref name="owner"/>または<paramref name="name"/>、<paramref name="branch"/>が空です。</exception>
    Task UpdateBranchProtectionAsync(string owner, string name, string branch, GitHubBranchProtectionSettings settings, CancellationToken cancellationToken = default);
}
