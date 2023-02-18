using System.Text.Json.Serialization;

namespace GitHubSettingsSync.Repositories.Entities;

/// <summary>
/// ステータスチェックに関するGitHubブランチ保護の設定を表す構造体です。
/// </summary>
/// <param name="Strict">マージする前にブランチを最新にする必要があるかどうか。</param>
/// <param name="Contexts">合格する必要があるステータスチェックのリスト。</param>
public sealed record GitHubBranchProtectionRequiredStatusChecks(
    [property: JsonPropertyName("strict")] bool Strict = false,
    [property: JsonPropertyName("contexts")] IReadOnlyList<string>? Contexts = null);
