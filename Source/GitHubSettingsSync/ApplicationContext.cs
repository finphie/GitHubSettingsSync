using System.Text.Json.Serialization;

namespace GitHubSettingsSync.Settings;

/// <inheritdoc/>
[JsonSourceGenerationOptions(
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower,
    GenerationMode = JsonSourceGenerationMode.Metadata,
    UseStringEnumConverter = true)]
[JsonSerializable(typeof(GitHubSettings))]
sealed partial class ApplicationContext : JsonSerializerContext;
