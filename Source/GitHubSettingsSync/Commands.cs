using System.Text.Json;
using FToolkit.Helpers.GitHub;
using FToolkit.Net.GitHub.Client;

namespace GitHubSettingsSync;

/// <summary>
/// コマンドを提供します。
/// </summary>
static class Commands
{
    /// <summary>
    /// Loads settings from a file and applies them to the repository.
    /// </summary>
    /// <param name="repository">-r, "owner/repo" format repository name.</param>
    /// <param name="path">File path of the configuration file.</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    public static async Task RunAsync(string repository, string path, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrEmpty(repository);
        ArgumentException.ThrowIfNullOrEmpty(path);

        var (repositoryOwner, repositoryName) = RepositoryHelper.GetRepositoryOwnerAndName(repository);
        Console.WriteLine($"Synchronizing GitHub settings to {repository}.");

        var bytes = File.ReadAllBytes(path);
        var settings = JsonSerializer.Deserialize(bytes, ApplicationContext.Default.GitHubSettings)
            ?? throw new InvalidOperationException("Failed to deserialize the settings.");

        var token = GitHubEnvironment.GetGitHubToken();
        var client = GitHubClient.Create(token);

        if (settings.Repository is not null)
        {
            Console.WriteLine("Updating repository settings.");
            await client.Repositories.UpdateAsync(repositoryOwner, repositoryName, settings.Repository, cancellationToken).ConfigureAwait(false);
        }

        if (settings.Branches is null)
        {
            return;
        }

        foreach (var branch in settings.Branches)
        {
            Console.WriteLine($"Updating branch settings for {branch.Name}.");
            await client.Branches.BranchProtection.UpdateAsync(repositoryOwner, repositoryName, branch.Name, branch.BranchProtection, cancellationToken).ConfigureAwait(false);
        }
    }
}
