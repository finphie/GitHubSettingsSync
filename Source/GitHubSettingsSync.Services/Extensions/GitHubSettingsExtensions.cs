﻿using GitHubSettingsSync.Repositories.Entities;
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
    public static GitHubRepository ToEntity(this RepositorySettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        var entity = new GitHubRepository(
            HasIssues: settings.HasIssues.ToBoolean(),
            HasProjects: settings.HasProjects.ToBoolean(),
            HasWiki: settings.HasWiki.ToBoolean(),
            AllowRebaseMerge: settings.AllowRebaseMerge.ToBoolean(),
            AllowAutoMerge: settings.AllowAutoMerge.ToBoolean(),
            DeleteBranchOnMerge: settings.DeleteBranchOnMerge.ToBoolean(),
            AllowUpdateBranch: settings.AllowUpdateBranch.ToBoolean());

        if (settings.MergeCommit is not null)
        {
            entity = entity with
            {
                AllowMerge = true,
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
    public static GitHubBranchProtection ToEntity(this BranchProtectionSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        return new(
            EnforceAdmins: settings.EnforceAdmins,
            RequiredLinearHistory: settings.RequiredLinearHistory,
            AllowForcePushes: settings.AllowForcePushes,
            AllowDeletions: settings.AllowDeletions,
            RequiredConversationResolution: settings.RequiredConversationResolution,
            RequiredStatusChecks: null,
            RequiredReviews: settings.RequiredReviews?.ToEntity());
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
