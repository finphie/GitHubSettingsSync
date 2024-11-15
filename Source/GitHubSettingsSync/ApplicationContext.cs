using System.Text.Json.Serialization;
using GitHubSettingsSync.Settings;

namespace GitHubSettingsSync;

/// <inheritdoc/>
[JsonSourceGenerationOptions(
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower,
    GenerationMode = JsonSourceGenerationMode.Metadata,
    UseStringEnumConverter = true)]
[JsonSerializable(typeof(GitHubSettings))]
sealed partial class ApplicationContext : JsonSerializerContext;
