using Octokit;

namespace GitHubSettingsSync.Repositories.Extensions;

/// <summary>
/// 設定関連の拡張メソッドを集めたクラスです。
/// </summary>
static class SettingsExtensions
{
    /// <summary>
    /// <see cref="GitHubRepositorySettings"/>構造体から<see cref="RepositoryUpdate"/>クラスを生成します。
    /// </summary>
    /// <param name="settings">設定</param>
    /// <returns><see cref="RepositoryUpdate"/>クラスのインスタンスを返します。</returns>
    public static RepositoryUpdate ToRepositoryUpdate(this in GitHubRepositorySettings settings)
    {
        return new RepositoryUpdate
        {
            HasIssues = settings.HasIssues,
            HasProjects = settings.HasProjects,
            HasWiki = settings.HasWiki,
            AllowMergeCommit = settings.AllowMergeCommit,
            AllowRebaseMerge = settings.AllowRebaseMerge,
            AllowSquashMerge = settings.AllowSquashMerge,
            AllowAutoMerge = settings.AllowAutoMerge,
            DeleteBranchOnMerge = settings.DeleteBranchOnMerge,
            AllowUpdateBranch = settings.AllowUpdateBranch
        };
    }

    /// <summary>
    /// <see cref="GitHubBranchProtectionSettings"/>構造体から<see cref="BranchProtectionSettingsUpdate"/>クラスを生成します。
    /// </summary>
    /// <param name="settings">ブランチ保護の設定。</param>
    /// <returns><see cref="BranchProtectionSettingsUpdate"/>クラスのインスタンスを返します。</returns>
    public static BranchProtectionSettingsUpdate ToBranchProtectionSettingsUpdate(this in GitHubBranchProtectionSettings settings)
    {
        return new(
            settings.RequiredStatusChecks is { } nonNullStatusChecksSettings ? new(nonNullStatusChecksSettings.Strict, nonNullStatusChecksSettings.Contexts) : null,
            settings.RequiredReviews is { } nonNullReviewsSettings ? new(nonNullReviewsSettings.DismissStaleReviews, nonNullReviewsSettings.RequireCodeOwnerReviews, nonNullReviewsSettings.RequiredApprovingReviewCount.Value) : null,
            null,
            settings.EnforceAdmins,
            settings.RequiredLinearHistory,
            settings.AllowForcePushes,
            settings.AllowDeletions,
            false,
            settings.RequiredConversationResolution);
    }
}
