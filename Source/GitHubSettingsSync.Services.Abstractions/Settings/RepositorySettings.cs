using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Services.Settings;

/// <inheritdoc cref="GitHubRepository"/>
/// <param name="MergeCommit"><inheritdoc cref="Settings.MergeCommit" path="/summary"/></param>
/// <param name="SquashMergeCommit"><inheritdoc cref="Settings.SquashMergeCommit" path="/summary"/></param>
public sealed record RepositorySettings(
    Status HasIssues = Status.Unchanged,
    Status HasProjects = Status.Unchanged,
    Status HasWiki = Status.Unchanged,
    MergeCommit? MergeCommit = null,
    SquashMergeCommit? SquashMergeCommit = null,
    Status AllowRebaseMerge = Status.Unchanged,
    Status AllowAutoMerge = Status.Unchanged,
    Status DeleteBranchOnMerge = Status.Unchanged,
    Status AllowUpdateBranch = Status.Unchanged);
