using Microsoft.Extensions.Options;

namespace GitHubSettingsSync.Models;

/// <summary>
/// 環境変数に関する検証クラスです。
/// </summary>
[OptionsValidator]
public sealed partial class EnvironmentVariablesValidator : IValidateOptions<EnvironmentVariables>
{
}
