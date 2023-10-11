using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;

namespace GitHubSettingsSync.Models;

/// <summary>
/// 環境変数を表すクラスです。
/// </summary>
public sealed record EnvironmentVariables
{
    /// <summary>
    /// トークンを取得または設定します。
    /// </summary>
    /// <value>
    /// GitHubの個人用アクセストークンを返します。
    /// </value>
    /// <remarks>
    /// initアクセサにするとソースジェネレーター使用時、バインドされないので注意する。
    /// </remarks>
    [Required]
    [ConfigurationKeyName("GITHUB_TOKEN")]
    public required string GitHubToken { get; set; }

    /// <summary>
    /// GitHub APIのURLを取得または設定します。
    /// </summary>
    /// <value>
    /// 「GITHUB_API_URL」環境変数を返します。
    /// </value>
    /// <remarks>
    /// initアクセサにするとソースジェネレーター使用時、バインドされないので注意する。
    /// </remarks>
    [ConfigurationKeyName("GITHUB_API_URL")]
    public Uri? GitHubApiUrl { get; set; }

    /// <summary>
    /// GitHubオーナー名を取得または設定します。
    /// </summary>
    /// <value>
    /// 「GITHUB_REPOSITORY_OWNER」環境変数を返します。
    /// </value>
    /// <remarks>
    /// initアクセサにするとソースジェネレーター使用時、バインドされないので注意する。
    /// </remarks>
    [ConfigurationKeyName("GITHUB_REPOSITORY_OWNER")]
    public string? GitHubRepositoryOwner { get; set; }
}
