﻿using System.Text.Json.Serialization;
using GitHubSettingsSync.Repositories.Entities;

namespace GitHubSettingsSync.Repositories;

/// <inheritdoc/>
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, PropertyNamingPolicy = JsonKnownNamingPolicy.KebabCaseLower, GenerationMode = JsonSourceGenerationMode.Metadata)]
[JsonSerializable(typeof(GitHubRepository))]
[JsonSerializable(typeof(GitHubBranchProtection))]
public sealed partial class JsonContext : JsonSerializerContext
{
}
