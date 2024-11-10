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
    /// Updates repository settings.
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
    /// <param name="mergeCommitTitle">
    /// The title of the merge commit.
    /// Depending on the value, there are restrictions on specifying "--merge-commit-message".
    /// For PullRequestTitle, specify PullRequestBody or Blank.
    /// For MergeMessage, specify PullRequestTitle.
    /// </param>
    /// <param name="mergeCommitMessage">
    /// The message of the merge commit.
    /// Depending on the value, there are restrictions on specifying "--merge-commit-title".
    /// For PullRequestTitle, specify MergeMessage.
    /// For PullRequestBody or Blank, specify PullRequestTitle.
    /// </param>
    /// <param name="squashMergeCommitTitle">
    /// The title of the squash merge commit.
    /// Depending on the value, there are restrictions on specifying "--squash-merge-commit-message".
    /// For PullRequestTitle, specify PullRequestBody, CommitMessages, or Blank.
    /// For CommitOrPullRequestTitle, specify CommitMessages.
    /// </param>
    /// <param name="squashMergeCommitMessage">
    /// The message of the squash merge commit.
    /// Depending on the value, there are restrictions on specifying "--squash-merge-commit-title".
    /// For PullRequestBody or Blank, specify PullRequestTitle.
    /// For CommitMessages, specify PullRequestTitle or CommitOrPullRequestTitle.
    /// </param>
    /// <param name="secretScanning">Whether to enable secret scanning.</param>
    /// <param name="secretScanningPushProtection">Whether to enable secret scanning push protection.</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    public static Task UpdateRepositoryAsync(
        string repository,
        bool hasIssues = true,
        bool hasProjects = true,
        bool hasWiki = true,
        bool hasDiscussions = true,
        bool allowMergeCommit = true,
        bool allowSquashMerge = true,
        bool allowRebaseMerge = true,
        bool allowAutoMerge = false,
        bool deleteBranchOnMerge = false,
        bool allowUpdateBranch = false,
        MergeCommitTitle mergeCommitTitle = MergeCommitTitle.MergeMessage,
        MergeCommitMessage mergeCommitMessage = MergeCommitMessage.PullRequestTitle,
        SquashMergeCommitTitle squashMergeCommitTitle = SquashMergeCommitTitle.CommitOrPullRequestTitle,
        SquashMergeCommitMessage squashMergeCommitMessage = SquashMergeCommitMessage.CommitMessages,
        bool secretScanning = false,
        bool secretScanningPushProtection = false)
    {
        ArgumentException.ThrowIfNullOrEmpty(repository);

        var (repositoryOwner, repositoryName) = RepositoryHelper.GetRepositoryOwnerAndName(repository);
        var token = GitHubEnvironment.GetGitHubToken();

        var client = GitHubClient.Create(token);
        var settings = new Repository
        {
            SecurityAndAnalysis = new()
            {
                SecretScanning = new()
                {
                    Status = secretScanning ? Status.Enabled : Status.Disabled
                },
                SecretScanningPushProtection = new()
                {
                    Status = secretScanningPushProtection ? Status.Enabled : Status.Disabled
                }
            },
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
    /// Updates branch protection settings.
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
    public static Task UpdateBranchProtectionAsync(
        string repository,
        string branch,
        bool enforceAdmins = false,
        bool requiredLinearHistory = false,
        bool allowForcePushes = false,
        bool allowDeletions = false,
        bool requiredConversationResolution = false,
        bool dismissStaleReviews = false,
        bool requireCodeOwnerReviews = false,
        int requiredApprovingReviewCount = 0,
        bool requireLastPushApproval = false)
    {
        ArgumentException.ThrowIfNullOrEmpty(repository);
        ArgumentException.ThrowIfNullOrEmpty(branch);

        var (repositoryOwner, repositoryName) = RepositoryHelper.GetRepositoryOwnerAndName(repository);
        var token = GitHubEnvironment.GetGitHubToken();

        var client = GitHubClient.Create(token);
        var settings = new BranchProtection
        {
            EnforceAdmins = enforceAdmins,
            RequiredLinearHistory = requiredLinearHistory,
            AllowForcePushes = allowForcePushes,
            AllowDeletions = allowDeletions,
            RequiredConversationResolution = requiredConversationResolution,
            RequiredPullRequestReviews = new()
            {
                DismissStaleReviews = dismissStaleReviews,
                RequireCodeOwnerReviews = requireCodeOwnerReviews,
                RequiredApprovingReviewCount = requiredApprovingReviewCount,
                RequireLastPushApproval = requireLastPushApproval
            }
        };

        return client.Branches.BranchProtection.UpdateAsync(repositoryOwner, repositoryName, branch, settings);
    }

    /// <summary>
    /// Deletes branch protection settings.
    /// </summary>
    /// <param name="repository">-r, "owner/repo" format repository name.</param>
    /// <param name="branch">Branch name.</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    public static Task DeleteBranchProtectionAsync(string repository, string branch)
    {
        ArgumentException.ThrowIfNullOrEmpty(repository);
        ArgumentException.ThrowIfNullOrEmpty(branch);

        var (repositoryOwner, repositoryName) = RepositoryHelper.GetRepositoryOwnerAndName(repository);
        var token = GitHubEnvironment.GetGitHubToken();
        var client = GitHubClient.Create(token);

        return client.Branches.BranchProtection.DeleteAsync(repositoryOwner, repositoryName, branch);
    }
}
