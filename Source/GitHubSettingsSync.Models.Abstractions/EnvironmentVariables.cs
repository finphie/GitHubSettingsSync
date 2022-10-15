﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace GitHubSettingsSync.Models;

/// <summary>
/// 環境変数
/// </summary>
[SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1206:Declaration keywords should follow order", Justification = "StyleCop.Analyzersの不具合。https://github.com/DotNetAnalyzers/StyleCopAnalyzers/issues/3527")]
public sealed record EnvironmentVariables
{
    /// <summary>
    /// <see cref="EnvironmentVariables"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    public EnvironmentVariables()
    {
    }

    /// <summary>
    /// トークンを取得または設定します。
    /// </summary>
    /// <value>
    /// GitHubの個人用アクセストークンを返します。
    /// </value>
    [Required]
    [ConfigurationKeyName("GITHUB_TOKEN")]
    public required string GitHubToken { get; init; }

    /// <summary>
    /// GitHub APIのURLを取得または設定します。
    /// </summary>
    /// <value>
    /// 「GITHUB_API_URL」環境変数を返します。
    /// </value>
    [ConfigurationKeyName("GITHUB_API_URL")]
    public string? GitHubApiUrl { get; init; }

    /// <summary>
    /// GitHubオーナー名を取得または設定します。
    /// </summary>
    /// <value>
    /// 「GITHUB_REPOSITORY_OWNER」環境変数を返します。
    /// </value>
    [ConfigurationKeyName("GITHUB_REPOSITORY_OWNER")]
    public string? GitHubRepositoryOwner { get; init; }
}
