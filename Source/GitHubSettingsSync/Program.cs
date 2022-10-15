using System.ComponentModel.DataAnnotations;
using GitHubSettingsSync.Models;
using GitHubSettingsSync.Repositories;
using GitHubSettingsSync.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Octokit;
using Octokit.Internal;

var builder = ConsoleApp.CreateBuilder(args)
    .ConfigureHostConfiguration(static config => config.AddEnvironmentVariables())
    .ConfigureServices(static (context, services) =>
    {
        // Logging
        services.AddLogging();

        // Library
        services.AddSingleton<IGitHubClient, GitHubClient>(static provider =>
        {
            var environments = provider.GetRequiredService<IOptions<EnvironmentVariables>>().Value;
            var credentials = new Credentials(environments.GitHubToken);
            var header = new ProductHeaderValue("GitHubSettingsSync");
            var store = new InMemoryCredentialStore(credentials);

            return string.IsNullOrEmpty(environments.GitHubApiUrl)
                ? new(header, store)
                : new(header, store, new(environments.GitHubApiUrl));
        });

        // 環境変数
        services.AddOptions<EnvironmentVariables>()
            .Bind(context.Configuration)
            .ValidateDataAnnotations();

        // Models
        services.AddSingleton<IUpdateGitHubSettings, UpdateGitHubSettings>();

        // Services
        services.AddSingleton<IUpdateGitHubRepositorySettingsService, UpdateGitHubRepositorySettingsService>();
        services.AddSingleton<IUpdateGitHubBranchProtectionSettingsService, UpdateGitHubBranchProtectionSettingsService>();

        // Repositories
        services.AddSingleton<IGitHubRepositorySettingsRepository, GitHubRepositorySettingsRepository>();
        services.AddSingleton<IGitHubRepositoryBranchProtectionSettingsRepository, GitHubRepositoryBranchProtectionSettingsRepository>();
    });

var app = builder.Build();
app.AddRootCommand(CommandAsync);
app.Run();

static async ValueTask<int> CommandAsync(
    ConsoleAppContext context,
    IUpdateGitHubSettings github,
    [Option("r", "カンマ・半角スペース・改行区切りにしたリポジトリ名のリスト。")] string repositories,
    [Option("i", "Issuesを有効にするかどうか。")] bool hasIssues = true,
    [Option("p", "Projectsを有効にするかどうか。")] bool hasProjects = true,
    [Option("w", "Wikiを有効にするかどうか。")] bool hasWiki = true,
    [Option("amc", "「Create a merge commit」を有効にするか。")] bool allowMergeCommit = true,
    [Option("arm", "「Rebase and Merge」を有効にするか。")] bool allowRebaseMerge = true,
    [Option("asm", "「Squash Merge」を有効にするかどうか。")] bool allowSquashMerge = true,
    [Option("aam", "自動マージ機能を有効にするか。")] bool allowAutoMerge = false,
    [Option("db", "プルリクエストマージ時に、ブランチを自動的に削除するかどうか。")] bool deleteBranchOnMerge = false,
    [Option("aub", "「Update branch」を有効にするかどうか。")] bool allowUpdateBranch = false,
    [Option("bp", "[ブランチ保護]ブランチ保護を有効にするかどうか。")] bool branchProtection = false,
    [Option("bp-n", "[ブランチ保護]ブランチ名。")] string branchProtectionName = "main",
    [Option("bp-ea", "[ブランチ保護]管理者にも適用するか。")] bool branchProtectionEnforceAdmins = false,
    [Option("bp-rlh", "[ブランチ保護]直線状の履歴を必須にするかどうか。")] bool branchProtectionRequiredLinearHistory = false,
    [Option("bp-afp", "[ブランチ保護]強制プッシュを許可するかどうか。")] bool branchProtectionAllowForcePushes = false,
    [Option("bp-ad", "[ブランチ保護]プッシュアクセス権を持つユーザーが、保護されたブランチを削除できるようにするかどうか。")] bool branchProtectionAllowDeletions = false,
    [Option("bp-rcr", "[ブランチ保護]マージ前にコメントの解決を必須にするかどうか。")] bool branchProtectionRequiredConversationResolution = false,
    [Option("bp-rsc-s", "[ブランチ保護][ステータスチェック]マージする前にブランチを最新にする必要があるかどうか。")] bool branchProtectionRequiredStatusChecksStrict = false,
    [Option("bp-rsc-c", "[ブランチ保護][ステータスチェック]合格する必要があるステータスチェックのリスト。")] string[]? branchProtectionRequiredStatusChecksContexts = null,
    [Option("bp-rr", "[ブランチ保護][レビュー]レビューを必須にするかどうか。")] bool branchProtectionRequiredReviews = false,
    [Option("bp-rr-dsr", "[ブランチ保護][レビュー]新しいコミットがプッシュされたときに、承認済みのレビューを却下するかどうか。")] bool branchProtectionRequiredReviewsDismissStaleReviews = false,
    [Option("bp-rr-rcor", "[ブランチ保護][レビュー]コード所有者のレビューが必須かどうか。")] bool branchProtectionRequiredReviewsRequireCodeOwnerReviews = false,
    [Option("bp-rr-rarc", "[ブランチ保護][レビュー]プルリクエストの承認に必要なレビュアーの数。")][Range(1, 6)] int branchProtectionRequiredReviewsRequiredApprovingReviewCount = 1)
{
    var repositoryList = repositories
        .TrimStart('[')
        .TrimEnd(']')
        .Split(new[] { ",", " ", "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

    var settings = new GitHubSettings
    {
        Repository = new()
        {
            HasIssues = hasIssues,
            HasProjects = hasProjects,
            HasWiki = hasWiki,
            AllowMergeCommit = allowMergeCommit,
            AllowRebaseMerge = allowRebaseMerge,
            AllowSquashMerge = allowSquashMerge,
            AllowAutoMerge = allowAutoMerge,
            DeleteBranchOnMerge = deleteBranchOnMerge,
            AllowUpdateBranch = allowUpdateBranch
        },
        Branch = branchProtectionName,
        BranchProtection = !branchProtection ? null : new()
        {
            EnforceAdmins = branchProtectionEnforceAdmins,
            RequiredLinearHistory = branchProtectionRequiredLinearHistory,
            AllowForcePushes = branchProtectionAllowForcePushes,
            AllowDeletions = branchProtectionAllowDeletions,
            RequiredConversationResolution = branchProtectionRequiredConversationResolution,
            RequiredStatusChecks = branchProtectionRequiredStatusChecksContexts is null ? null : new()
            {
                Strict = branchProtectionRequiredStatusChecksStrict,
                Contexts = branchProtectionRequiredStatusChecksContexts
            },
            RequiredReviews = !branchProtectionRequiredReviews ? null : new()
            {
                DismissStaleReviews = branchProtectionRequiredReviewsDismissStaleReviews,
                RequireCodeOwnerReviews = branchProtectionRequiredReviewsRequireCodeOwnerReviews,
                RequiredApprovingReviewCount = new(branchProtectionRequiredReviewsRequiredApprovingReviewCount)
            }
        }
    };

    await github.ExecuteAsync(repositoryList, settings, context.CancellationToken).ConfigureAwait(false);

    return github.IsError ? -1 : 0;
}
