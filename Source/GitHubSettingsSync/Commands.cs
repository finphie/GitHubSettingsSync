using FToolkit.Helpers.GitHub;
using FToolkit.Net.GitHub.Client;
using FToolkit.Net.GitHub.Client.Branches.BranchProtection;
using FToolkit.Net.GitHub.Client.Repositories;

namespace GitHubSettingsSync;

/// <summary>
/// コマンドを提供します。
/// </summary>
static class Commands
{
    public static async Task RepositoryAsync(
        string repository,
        bool? hasIssues = null,
        bool? hasProjects = null,
        bool? hasWiki = null,
        bool? hasDiscussions = null,
        bool? allowMergeCommit = null,
        bool? allowSquashMerge = null,
        bool? allowRebaseMerge = null,
        bool? allowAutoMerge = null,
        bool? deleteBranchOnMerge = null,
        bool? allowUpdateBranch = null,
        MergeCommitTitle? mergeCommitTitle = null,
        MergeCommitMessage? mergeCommitMessage = null,
        SquashMergeCommitTitle? squashMergeCommitTitle = null,
        SquashMergeCommitMessage? squashMergeCommitMessage = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(repository);

        var (repositoryOwner, repositoryName) = RepositoryHelper.GetRepositoryOwnerAndName(repository);
        var token = GitHubEnvironment.GetGitHubToken();

        var client = GitHubClient.Create(token);
        var settings = new Repository
        {
            HasIssues = hasIssues,
            HasProjects = hasProjects,
            HasWiki = hasWiki,
            HasDiscussions = hasDiscussions,
            AllowMergeCommit = allowMergeCommit,
            AllowSquashMerge = allowSquashMerge,
            AllowRebaseMerge = allowRebaseMerge,
            AllowAutoMerge = allowAutoMerge,
            DeleteBranchOnMerge = deleteBranchOnMerge,
            AllowUpdateBranch = allowUpdateBranch,
            MergeCommitTitle = mergeCommitTitle,
            MergeCommitMessage = mergeCommitMessage,
            SquashMergeCommitTitle = squashMergeCommitTitle,
            SquashMergeCommitMessage = squashMergeCommitMessage
        };

        await client.Repositories.UpdateAsync(repositoryOwner, repositoryName, settings)
            .ConfigureAwait(false);
    }

    public static async Task BranchProtectionAsync(
        string repository,
        string branch,
        bool? enforceAdmins = null,
        bool? requiredLinearHistory = null,
        bool? allowForcePushes = null,
        bool? allowDeletions = null,
        bool? requiredConversationResolution = null,
        bool? dismissStaleReviews = null,
        bool? requireCodeOwnerReviews = null,
        int? requiredApprovingReviewCount = null,
        bool? requireLastPushApproval = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(repository);
        ArgumentException.ThrowIfNullOrEmpty(branch);

        var (repositoryOwner, repositoryName) = RepositoryHelper.GetRepositoryOwnerAndName(repository);
        var token = GitHubEnvironment.GetGitHubToken();

        var client = GitHubClient.Create(token);

        var requiredPullRequestReviews = dismissStaleReviews is null && requireCodeOwnerReviews is null && requiredApprovingReviewCount is null && requireLastPushApproval is null
            ? null
            : new RequiredPullRequestReviews
            {
                DismissStaleReviews = dismissStaleReviews,
                RequireCodeOwnerReviews = requireCodeOwnerReviews,
                RequiredApprovingReviewCount = requiredApprovingReviewCount,
                RequireLastPushApproval = requireLastPushApproval
            };
        var settings = new BranchProtection
        {
            EnforceAdmins = enforceAdmins,
            RequiredLinearHistory = requiredLinearHistory,
            AllowForcePushes = allowForcePushes,
            AllowDeletions = allowDeletions,
            RequiredConversationResolution = requiredConversationResolution,
            RequiredPullRequestReviews = requiredPullRequestReviews
        };

        await client.Branches.BranchProtection.UpdateAsync(repositoryOwner, repositoryName, branch, settings)
            .ConfigureAwait(false);
    }
}
