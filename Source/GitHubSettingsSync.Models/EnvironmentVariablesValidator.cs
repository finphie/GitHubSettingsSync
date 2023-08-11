using Microsoft.Extensions.Options;

namespace GitHubSettingsSync.Models;

[OptionsValidator]
public sealed partial class EnvironmentVariablesValidator : IValidateOptions<EnvironmentVariables>
{
}
