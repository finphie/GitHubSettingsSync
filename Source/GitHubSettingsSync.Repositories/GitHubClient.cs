using System.Net.Http.Json;
using Microsoft.Extensions.Logging;

namespace GitHubSettingsSync.Repositories;

/// <summary>
/// GitHub APIのクライアント。
/// </summary>
public sealed partial class GitHubClient : IGitHubClient
{
    readonly ILogger<GitHubClient> _logger;
    readonly HttpClient _client;

    /// <summary>
    /// <see cref="GitHubClient"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー。</param>
    /// <param name="client">HTTPクライアント。</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>または<paramref name="client"/>がnullです。</exception>
    public GitHubClient(ILogger<GitHubClient> logger, HttpClient client)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(client);

        _logger = logger;
        _client = client;
    }

    /// <inheritdoc/>
    public async Task UpdateRepositoryAsync(string owner, string name, GitHubRepositorySettings settings, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(owner);
        ArgumentException.ThrowIfNullOrEmpty(name);

        UpdatingRepositorySettings();

        var response = await _client.PatchAsJsonAsync($"/repos/{owner}/{name}", settings, JsonContext.Default.GitHubRepositorySettings, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <inheritdoc/>
    public async Task UpdateBranchProtectionAsync(string owner, string name, string branch, GitHubBranchProtectionSettings settings, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(owner);
        ArgumentException.ThrowIfNullOrEmpty(name);

        UpdatingBranchProtectionSettings();

        var response = await _client.PutAsJsonAsync($"/repos/{owner}/{name}/branches/{branch}/protection", settings, JsonContext.Default.GitHubBranchProtectionSettings, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    [LoggerMessage(EventId = 1001, Level = LogLevel.Information, Message = "Updating repository settings.")]
    partial void UpdatingRepositorySettings();

    [LoggerMessage(EventId = 1002, Level = LogLevel.Information, Message = "Updating branch protection settings.")]
    partial void UpdatingBranchProtectionSettings();
}
