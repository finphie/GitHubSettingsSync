using ConsoleAppFramework;
using GitHubSettingsSync;

var app = ConsoleApp.Create();

app.Add("repository", Commands.UpdateRepositoryAsync);
app.Add("branch-protection", Commands.UpdateBranchProtectionAsync);
app.Add("branch-protection delete", Commands.DeleteBranchProtectionAsync);
app.Run(args);
