using GitHubSettingsSync.Repositories.Entities;
using GitHubSettingsSync.Services.Settings;

namespace GitHubSettingsSync.Services.Extensions;

/// <summary>
/// GitHub設定関連の拡張メソッドです。
/// </summary>
static class GitHubSettingsExtensions
{
    /// <summary>
    /// GitHub APIリクエスト時に必要となるクラスのインスタンスを取得します。
    /// </summary>
    /// <param name="settings">GitHubリポジトリに関する設定。</param>
    /// <returns>リポジトリに関する設定を表すクラスのインスタンスを返します。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="settings"/>がnullです。</exception>
    internal static GitHubRepository ToEntity(this RepositorySettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        var entity = new GitHubRepository(
            HasIssues: settings.HasIssues.ToBoolean(),
            HasProjects: settings.HasProjects.ToBoolean(),
            HasWiki: settings.HasWiki.ToBoolean(),
            HasDiscussions: settings.HasDiscussions.ToBoolean(),
            AllowRebaseMerge: settings.AllowRebaseMerge.ToBoolean(),
            AllowAutoMerge: settings.AllowAutoMerge.ToBoolean(),
            DeleteBranchOnMerge: settings.DeleteBranchOnMerge.ToBoolean(),
            AllowUpdateBranch: settings.AllowUpdateBranch.ToBoolean());

        if (settings.MergeCommit is not null)
        {
            entity = entity with
            {
                AllowMergeCommit = true,
                MergeCommitTitle = settings.MergeCommit.Title.GetName(),
                MergeCommitMessage = settings.MergeCommit.Message.GetName()
            };
        }

        if (settings.SquashMergeCommit is not null)
        {
            entity = entity with
            {
                AllowSquashMerge = true,
                SquashMergeCommitTitle = settings.SquashMergeCommit.Title.GetName(),
                SquashMergeCommitMessage = settings.SquashMergeCommit.Message.GetName()
            };
        }

        return entity;
    }

    /// <summary>
    /// GitHub APIリクエスト時に必要となるクラスのインスタンスを取得します。
    /// </summary>
    /// <param name="settings">GitHubブランチ保護に関する設定。</param>
    /// <returns>ブランチ保護に関する設定を表すクラスのインスタンスを返します。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="settings"/>がnullです。</exception>
    internal static GitHubBranchProtection ToEntity(this BranchProtectionSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        return new(
            EnforceAdmins: settings.EnforceAdmins,
            RequiredLinearHistory: settings.RequiredLinearHistory.ToBoolean(),
            AllowForcePushes: settings.AllowForcePushes.ToBoolean(),
            AllowDeletions: settings.AllowDeletions.ToBoolean(),
            RequiredConversationResolution: settings.RequiredConversationResolution.ToBoolean(),
            RequiredStatusChecks: null,
            RequiredPullRequestReviews: settings.RequiredReviews?.ToEntity());
    }

    static GitHubBranchProtectionRequiredReviews ToEntity(this BranchProtectionRequiredReviewsSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        return new(
            DismissStaleReviews: settings.DismissStaleReviews,
            RequireCodeOwnerReviews: settings.RequireCodeOwnerReviews,
            RequiredApprovingReviewCount: settings.RequiredApprovingReviewCount);
    }

    static bool? ToBoolean(this Status status)
    {
        return status switch
        {
            Status.Unchanged => null,
            Status.Enabled => true,
            Status.Disabled => false,
            _ => null,
        };
    }

    static string? GetName(this SquashMergeCommitTitleType value)
    {
        return value switch
        {
            SquashMergeCommitTitleType.Unchanged => null,
            SquashMergeCommitTitleType.PullRequestTitle => "PR_TITLE",
            SquashMergeCommitTitleType.CommitOrPullRequestTitle => "COMMIT_OR_PR_TITLE",
            _ => null
        };
    }

    static string? GetName(this SquashMergeCommitMessageType value)
    {
        return value switch
        {
            SquashMergeCommitMessageType.Unchanged => null,
            SquashMergeCommitMessageType.PullRequestBody => "PR_BODY",
            SquashMergeCommitMessageType.CommitMessages => "COMMIT_MESSAGES",
            SquashMergeCommitMessageType.Blank => "BLANK",
            _ => null
        };
    }

    static string? GetName(this MergeCommitTitleType value)
    {
        return value switch
        {
            MergeCommitTitleType.Unchanged => null,
            MergeCommitTitleType.PullRequestTitle => "PR_TITLE",
            MergeCommitTitleType.MergeMessage => "MERGE_MESSAGE",
            _ => null
        };
    }

    static string? GetName(this MergeCommitMessageType value)
    {
        return value switch
        {
            MergeCommitMessageType.Unchanged => null,
            MergeCommitMessageType.PullRequestTitle => "PR_TITLE",
            MergeCommitMessageType.PullRequestBody => "PR_BODY",
            MergeCommitMessageType.Blank => "BLANK",
            _ => null
        };
    }
}
