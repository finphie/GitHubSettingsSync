using System.Text.Json.Serialization;

namespace GitHubSettingsSync.Repositories;

/// <inheritdoc/>
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, GenerationMode = JsonSourceGenerationMode.Metadata)]
[JsonSerializable(typeof(GitHubRepositorySettings))]
[JsonSerializable(typeof(GitHubBranchProtectionSettings))]
public sealed partial class JsonContext : JsonSerializerContext
{
}
