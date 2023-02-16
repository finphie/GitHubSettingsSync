using CommunityToolkit.Diagnostics;
using UnitGenerator;

namespace GitHubSettingsSync.Repositories;

/// <summary>
/// プルリクエストの承認に必要なレビュアーの数。
/// </summary>
[UnitOf(typeof(int), UnitGenerateOptions.Validate | UnitGenerateOptions.JsonConverter)]
public readonly partial struct RequiredApprovingReviewCount
{
    private partial void Validate() => Guard.IsInRange(value, 1, 7);
}
