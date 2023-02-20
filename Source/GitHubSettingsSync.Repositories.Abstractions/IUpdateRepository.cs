﻿using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Repositories;

/// <summary>
/// 更新関連のRepositoryインターフェイスです。
/// </summary>
/// <inheritdoc cref="IRepository{T}"/>
public interface IUpdateRepository<T> : IRepository<T>
    where T : notnull, Request<T>
{
    /// <summary>
    /// 指定されたリクエスト情報で更新します。
    /// </summary>
    /// <param name="request">リクエスト情報。</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン。</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="request"/>がnullです。</exception>
    Task UpdateAsync(T request, CancellationToken cancellationToken = default);
}
