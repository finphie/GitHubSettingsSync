﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using GitHubSettingsSync;
using GitHubSettingsSync.Extensions;
using GitHubSettingsSync.Models;
using GitHubSettingsSync.Repositories;
using GitHubSettingsSync.Services;
using GitHubSettingsSync.Services.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

var builder = ConsoleApp.CreateBuilder(args)
    .ConfigureHostConfiguration(static x => x.AddEnvironmentVariables())
    .ConfigureLogging(static logging =>
    {
        logging.ClearProviders();
        logging.AddSimpleConsole(static options =>
        {
            options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
            options.UseUtcTimestamp = true;
        });
    })
    .ConfigureServices(static (context, services) =>
    {
        Bind(services, context.Configuration);

        services.AddHttpClient<IGitHubClient, GitHubClient>(static (provider, client) =>
        {
            var environments = provider.GetRequiredService<IOptions<EnvironmentVariables>>().Value;
            var url = string.IsNullOrEmpty(environments.GitHubApiUrl)
                ? new Uri("https://api.github.com/")
                : new Uri(new(environments.GitHubApiUrl), new Uri("/api/v3/", UriKind.Relative));

            client.BaseAddress = url;
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            client.DefaultRequestHeaders.Add("User-Agent", nameof(GitHubSettingsSync));
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {environments.GitHubToken}");
            client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
        });

        // Models
        services.AddSingleton<IUpdateGitHubSettings, UpdateGitHubSettings>();

        // Services
        services.AddSingleton<IUpdateGitHubRepositorySettingsService, UpdateGitHubRepositorySettingsService>();
        services.AddSingleton<IUpdateGitHubBranchProtectionSettingsService, UpdateGitHubBranchProtectionSettingsService>();

        // Repositories
        services.AddSingleton<IGitHubRepositoryRepository, GitHubRepositoryRepository>();
        services.AddSingleton<IGitHubRepositoryBranchProtectionRepository, GitHubRepositoryBranchProtectionRepository>();
    });

var app = builder.Build();
app.AddRootCommand(CommandAsync);
app.Run();

[UnconditionalSuppressMessage("Trimming", "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code", Justification = "警告を無効にしても問題ない。")]
[UnconditionalSuppressMessage("AOT", "IL3050:Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.", Justification = "警告を無効にしても問題ない。")]
static void Bind(IServiceCollection services, IConfiguration configuration)
{
    // 環境変数
    services.AddOptions<EnvironmentVariables>()
        .Bind(configuration)
        .ValidateDataAnnotations();
}

static async ValueTask<int> CommandAsync(
    ConsoleAppContext context,
    IUpdateGitHubSettings gitHub,
    [Option("r", "カンマ・半角スペース・改行区切りにしたリポジトリ名のリスト。")] string repositories,
    [Option("i", "Issuesを有効にするかどうか。")] BooleanParameter hasIssues = BooleanParameter.Unchanged,
    [Option("p", "Projectsを有効にするかどうか。")] BooleanParameter hasProjects = BooleanParameter.Unchanged,
    [Option("w", "Wikiを有効にするかどうか。")] BooleanParameter hasWiki = BooleanParameter.Unchanged,
    [Option("d", "Discussionsを有効にするかどうか。")] BooleanParameter hasDiscussions = BooleanParameter.Unchanged,
    [Option("amc", "「Create a merge commit」を有効にするか。")] BooleanParameter allowMergeCommit = BooleanParameter.Unchanged,
    [Option("asm", "「Squash Merge」を有効にするかどうか。")] BooleanParameter allowSquashMerge = BooleanParameter.Unchanged,
    [Option("arm", "「Rebase and Merge」を有効にするか。")] BooleanParameter allowRebaseMerge = BooleanParameter.Unchanged,
    [Option("aam", "自動マージ機能を有効にするか。")] BooleanParameter allowAutoMerge = BooleanParameter.Unchanged,
    [Option("db", "プルリクエストマージ時に、ブランチを自動的に削除するかどうか。")] BooleanParameter deleteBranchOnMerge = BooleanParameter.Unchanged,
    [Option("aub", "「Update branch」を有効にするかどうか。")] BooleanParameter allowUpdateBranch = BooleanParameter.Unchanged,
    [Option("mct", "マージにおけるコミットタイトルの種類。")] MergeCommitTitleType mergeCommitTitle = MergeCommitTitleType.Unchanged,
    [Option("mcm", "マージにおけるコミットメッセージの種類。")] MergeCommitMessageType mergeCommitMessage = MergeCommitMessageType.Unchanged,
    [Option("smct", "スカッシュマージにおけるコミットタイトルの種類。")] SquashMergeCommitTitleType squashMergeCommitTitle = SquashMergeCommitTitleType.Unchanged,
    [Option("smcm", "スカッシュマージにおけるコミットメッセージの種類。")] SquashMergeCommitMessageType squashMergeCommitMessage = SquashMergeCommitMessageType.Unchanged,
    [Option("bp", "[ブランチ保護]ブランチ保護を有効にするかどうか。")] BooleanParameter branchProtection = BooleanParameter.Unchanged,
    [Option("bp-n", "[ブランチ保護]ブランチ名。")] string branchProtectionName = "main",
    [Option("bp-ea", "[ブランチ保護]管理者にも適用するか。")] bool branchProtectionEnforceAdmins = false,
    [Option("bp-rlh", "[ブランチ保護]直線状の履歴を必須にするかどうか。")] BooleanParameter branchProtectionRequiredLinearHistory = BooleanParameter.Unchanged,
    [Option("bp-afp", "[ブランチ保護]強制プッシュを許可するかどうか。")] BooleanParameter branchProtectionAllowForcePushes = BooleanParameter.Unchanged,
    [Option("bp-ad", "[ブランチ保護]プッシュアクセス権を持つユーザーが、保護されたブランチを削除できるようにするかどうか。")] BooleanParameter branchProtectionAllowDeletions = BooleanParameter.Unchanged,
    [Option("bp-rcr", "[ブランチ保護]マージ前にコメントの解決を必須にするかどうか。")] BooleanParameter branchProtectionRequiredConversationResolution = BooleanParameter.Unchanged,
    [Option("bp-rr", "[ブランチ保護][レビュー]レビューを必須にするかどうか。")] bool branchProtectionRequiredReviews = false,
    [Option("bp-rr-dsr", "[ブランチ保護][レビュー]新しいコミットがプッシュされたときに、承認済みのレビューを却下するかどうか。")] bool branchProtectionRequiredReviewsDismissStaleReviews = false,
    [Option("bp-rr-rcor", "[ブランチ保護][レビュー]コード所有者のレビューが必須かどうか。")] bool branchProtectionRequiredReviewsRequireCodeOwnerReviews = false,
    [Option("bp-rr-rarc", "[ブランチ保護][レビュー]プルリクエストの承認に必要なレビュアーの数。")][Range(1, 6)] int branchProtectionRequiredReviewsRequiredApprovingReviewCount = 1)
{
    var repositoryList = repositories
        .TrimStart('[')
        .TrimEnd(']')
#pragma warning disable CA1861 // 引数として定数配列を使用しない
        .Split(new[] { ',', ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
#pragma warning restore CA1861 // 引数として定数配列を使用しない

    var settings = new GitHubSettings
    {
        Repository = new()
        {
            HasIssues = hasIssues.ToStatus(),
            HasProjects = hasProjects.ToStatus(),
            HasWiki = hasWiki.ToStatus(),
            HasDiscussions = hasDiscussions.ToStatus(),
            MergeCommit = allowMergeCommit == BooleanParameter.True ? new(mergeCommitTitle, mergeCommitMessage) : null,
            SquashMergeCommit = allowSquashMerge == BooleanParameter.True ? new(squashMergeCommitTitle, squashMergeCommitMessage) : null,
            AllowRebaseMerge = allowRebaseMerge.ToStatus(),
            AllowAutoMerge = allowAutoMerge.ToStatus(),
            DeleteBranchOnMerge = deleteBranchOnMerge.ToStatus(),
            AllowUpdateBranch = allowUpdateBranch.ToStatus(),
        },
        Branch = branchProtectionName,
        IsBranchProtection = branchProtection != BooleanParameter.Unchanged,
        BranchProtection = branchProtection != BooleanParameter.True ? null : new()
        {
            EnforceAdmins = branchProtectionEnforceAdmins,
            RequiredLinearHistory = branchProtectionRequiredLinearHistory.ToStatus(),
            AllowForcePushes = branchProtectionAllowForcePushes.ToStatus(),
            AllowDeletions = branchProtectionAllowDeletions.ToStatus(),
            RequiredConversationResolution = branchProtectionRequiredConversationResolution.ToStatus(),
            RequiredReviews = !branchProtectionRequiredReviews ? null : new()
            {
                DismissStaleReviews = branchProtectionRequiredReviewsDismissStaleReviews,
                RequireCodeOwnerReviews = branchProtectionRequiredReviewsRequireCodeOwnerReviews,
                RequiredApprovingReviewCount = branchProtectionRequiredReviewsRequiredApprovingReviewCount
            }
        }
    };

    await gitHub.ExecuteAsync(repositoryList, settings, context.CancellationToken).ConfigureAwait(false);

    return gitHub.IsError ? -1 : 0;
}
