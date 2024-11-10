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
    /// <summary>
    /// リポジトリの設定を更新します。
    /// </summary>
    /// <param name="repository">-r, "owner/repo" format repository name.</param>
    /// <param name="hasIssues">Whether to enable issues.</param>
    /// <param name="hasProjects">Whether to enable Projects.</param>
    /// <param name="hasWiki">Whether to enable Wiki.</param>
    /// <param name="hasDiscussions">Whether to enable Discussions.</param>
    /// <param name="allowMergeCommit">Whether to allow merge commits.</param>
    /// <param name="allowSquashMerge">Whether to allow squash merges.</param>
    /// <param name="allowRebaseMerge">Whether to allow rebase merges.</param>
    /// <param name="allowAutoMerge">Whether to allow auto merges.</param>
    /// <param name="deleteBranchOnMerge">Whether to delete the branch after merging.</param>
    /// <param name="allowUpdateBranch">Whether to allow branch updates.</param>
    /// <param name="mergeCommitTitle">The title of the merge commit.</param>
    /// <param name="mergeCommitMessage">The message of the merge commit.</param>
    /// <param name="squashMergeCommitTitle">The title of the squash merge commit.</param>
    /// <param name="squashMergeCommitMessage">The message of the squash merge commit.</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    public static Task RepositoryAsync(
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

        return client.Repositories.UpdateAsync(repositoryOwner, repositoryName, settings);
    }

    /// <summary>
    /// ブランチ保護の設定を更新します。
    /// </summary>
    /// <param name="repository">-r, "owner/repo" format repository name.</param>
    /// <param name="branch">Branch name.</param>
    /// <param name="enforceAdmins">Whether to enforce for administrators.</param>
    /// <param name="requiredLinearHistory">Whether to require linear history.</param>
    /// <param name="allowForcePushes">Whether to allow force pushes.</param>
    /// <param name="allowDeletions">Whether to allow users with push access to delete the protected branch.</param>
    /// <param name="requiredConversationResolution">Whether to require conversation resolution before merging.</param>
    /// <param name="dismissStaleReviews">Whether to dismiss stale reviews when new commits are pushed.</param>
    /// <param name="requireCodeOwnerReviews">Whether to require code owner reviews.</param>
    /// <param name="requiredApprovingReviewCount">The number of reviewers required to approve a pull request.</param>
    /// <param name="requireLastPushApproval">Whether to require approval from someone other than the person who pushed the latest commit.</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    public static Task BranchProtectionAsync(
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

        return client.Branches.BranchProtection.UpdateAsync(repositoryOwner, repositoryName, branch, settings);
    }
}
