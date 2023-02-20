﻿namespace GitHubSettingsSync.Repositories.Entities;

/// <summary>
/// リポジトリ情報を表すクラスです。
/// </summary>
/// <typeparam name="T">設定の型。</typeparam>
/// <param name="Owner">オーナー名。</param>
/// <param name="Name">リポジトリ名。</param>
/// <param name="Settings">設定。</param>
public record Request<T>(string Owner, string Name, T Settings) : IAggregateRoot
    where T : notnull;
