using ConsoleAppFramework;
using GitHubSettingsSync;

var app = ConsoleApp.Create();

app.Add("repository", Commands.RepositoryAsync);
app.Add("branch-protection", Commands.BranchProtectionAsync);
app.Run(args);
