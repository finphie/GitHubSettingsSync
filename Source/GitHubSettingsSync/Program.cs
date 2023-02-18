using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using GitHubSettingsSync.Models;
using GitHubSettingsSync.Repositories;
using GitHubSettingsSync.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

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
            client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/vnd.github.v3+json");
            client.DefaultRequestHeaders.Add(HeaderNames.UserAgent, nameof(GitHubSettingsSync));
            client.DefaultRequestHeaders.Add(HeaderNames.Authorization, $"Bearer {environments.GitHubToken}");
            client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
        });

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
            RequiredReviews = !branchProtectionRequiredReviews ? null : new()
            {
                DismissStaleReviews = branchProtectionRequiredReviewsDismissStaleReviews,
                RequireCodeOwnerReviews = branchProtectionRequiredReviewsRequireCodeOwnerReviews,
                RequiredApprovingReviewCount = branchProtectionRequiredReviewsRequiredApprovingReviewCount
            }
        }
    };

    await github.ExecuteAsync(repositoryList, settings, context.CancellationToken).ConfigureAwait(false);

    return github.IsError ? -1 : 0;
}
