# GitHubSettingsSync

[![Build(.NET)](https://github.com/finphie/GitHubSettingsSync/actions/workflows/build-dotnet.yml/badge.svg)](https://github.com/finphie/GitHubSettingsSync/actions/workflows/build-dotnet.yml)
[![NuGet](https://img.shields.io/nuget/v/GitHubSettingsSync?color=0078d4&label=NuGet)](https://www.nuget.org/packages/GitHubSettingsSync/)
[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/DotNet/Packages/f8147011-dc70-430b-ba72-56ee4008f90e/Badge)](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/GitHubSettingsSync?preferRelease=true)

[日本語 (Japanese)](README.ja.md)

This is an application to synchronize GitHub settings.

## 説明

GitHubSettingsSync is an application for configuring GitHub repository settings.

- [Action](https://github.com/marketplace/actions/github-settings-sync)
- [NuGet](https://www.nuget.org/packages/GitHubSettingsSync)
- [Azure Artifacts](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/GitHubSettingsSync?preferRelease=true)
- [Binary](https://github.com/finphie/GitHubSettingsSync/releases/latest)
- [Docker](https://github.com/finphie/GitHubSettingsSync/pkgs/container/git-hub-settings-sync)

## Usage

### Action

```yaml
on:
  workflow_dispatch:

jobs:
  sync-github-settings:
    runs-on: ubuntu-latest

    steps:
      - name: GitHub Settings Sync
        uses: finphie/GitHubSettingsSync@v3.0.0
        with:
          repository: GitHubSettingsSync
          path: github-settings.json
        env:
          GITHUB_TOKEN: ${{ secrets.TOKEN }}
```

### .NET tool

```shell
GitHubSettingsSync \
    --repository GitHubSettingsSync \
    --path github-settings.json
```

## Arguments

|Argument|Required|Default|Description|
|-|-|-|-|
|repository|**true**|-|"owner/repo" format repository name.|
|path|**true**|-|File path of the configuration file.|

## Environment Variables

|Variable Name|Required|Default|Description|
|-|-|-|-|
|GITHUB_TOKEN|**true**|-|Token with write permission to Administration.|

## Configuration File

The file is in JSON format. By setting the value to `null` or omitting the key, the setting will be retained without changes.

### Configuration Example

```json
{
  "repository": {
    "security_and_analysis": {
      "secret_scanning": {
        "status": "disabled"
      },
      "secret_scanning_push_protection": {
        "status": "disabled"
      }
    },
    "has_issues": true,
    "has_projects": true,
    "has_wiki": true,
    "has_discussions": true,
    "allow_merge_commit": true,
    "allow_squash_merge": true,
    "allow_rebase_merge": true,
    "allow_auto_merge": false,
    "delete_branch_on_merge": false,
    "allow_update_branch": false,
    "merge_commit_title": "MERGE_MESSAGE",
    "merge_commit_message": "PR_TITLE",
    "squash_merge_commit_title": "COMMIT_OR_PR_TITLE",
    "squash_merge_commit_message": "COMMIT_MESSAGES"
  },
  "branches": [
    {
      "name": "main",
      "branch_protection": {
        "enforce_admins": false,
        "required_linear_history": false,
        "allow_force_pushes": false,
        "allow_deletions": false,
        "required_conversation_resolution": false,
        "required_pull_request_reviews": {
          "dismiss_stale_reviews": false,
          "require_code_owner_reviews": false,
          "required_approving_review_count": 0,
          "require_last_push_approval": false
        }
      }
    }
  ]
}
```

### Configuration Details

#### repository

|Key|Required|Default|Description|
|-|-|-|-|
|has_issues|false|null|Enable or disable Issues.|
|has_projects|false|null|Enable or disable Projects.|
|has_wiki|false|null|Enable or disable Wiki.|
|has_discussions|false|null|Enable or disable Discussions.|
|allow_merge_commit|false|null|Enable or disable "Create a merge commit".|
|allow_squash_merge|false|null|Enable or disable "Squash Merge".|
|allow_rebase_merge|false|null|Enable or disable "Rebase and Merge".|
|allow_auto_merge|false|null|Enable or disable auto-merge feature.|
|delete_branch_on_merge|false|null|Automatically delete branch after pull request merge.|
|allow_update_branch|false|null|Enable or disable "Update branch".|
|merge_commit_title|false|null|Type of commit title for merge. Either PR_TITLE or MERGE_MESSAGE. If PR_TITLE, specify PR_BODY or BLANK for merge_commit_message. If MERGE_MESSAGE, specify PR_TITLE for merge_commit_message.|
|merge_commit_message|false|null|Type of commit message for merge. Either PR_TITLE, PR_BODY, or BLANK.|
|squash_merge_commit_title|false|null|Type of commit title for squash merge. Either PR_TITLE or COMMIT_OR_PR_TITLE.|
|squash_merge_commit_message|false|null|Type of commit message for squash merge. Either PR_BODY, COMMIT_MESSAGES, or BLANK.|

##### security_and_analysis

|Key|Required|Default|Description|
|-|-|-|-|
|secret_scanning.status|false|null|Enable or disable secret scanning. Either enabled or disabled.|
|secret_scanning_push_protection.status|false|null|Enable or disable secret scanning push protection. Either enabled or disabled.|

#### branches

|Key|Required|Default|Description|
|-|-|-|-|
|name|**true**|-|Branch name.|

##### branch_protection

|Key|Required|Default|Description|
|-|-|-|-|
|enforce_admins|false|null|Apply branch protection to administrators.|
|required_linear_history|false|null|Require linear history.|
|allow_force_pushes|false|null|Allow force pushes.|
|allow_deletions|false|null|Allow users with push access to delete the protected branch.|
|required_conversation_resolution|false|null|Require conversation resolution before merging.|
|required_reviews|false|null|Require reviews before merging.|
|dismiss_stale_reviews|false|null|Dismiss approved reviews when new commits are pushed.|
|require_code_owner_reviews|false|null|Require reviews from code owners.|
|required_approving_review_count|false|null|Number of reviewers required to approve a pull request.|

## Author

finphie

## License

MIT

## Credits

This project uses the following libraries, etc.

### Libraries

- [ConsoleAppFramework](https://github.com/Cysharp/ConsoleAppFramework)

### Analyzers

- [DocumentationAnalyzers](https://github.com/DotNetAnalyzers/DocumentationAnalyzers)
- [IDisposableAnalyzers](https://github.com/DotNetAnalyzers/IDisposableAnalyzers)
- [Microsoft.CodeAnalysis.NetAnalyzers](https://github.com/dotnet/roslyn-analyzers)
- [Microsoft.VisualStudio.Threading.Analyzers](https://github.com/Microsoft/vs-threading)
- [Roslynator.Analyzers](https://github.com/dotnet/roslynator)
- [Roslynator.Formatting.Analyzers](https://github.com/dotnet/roslynator)
- [StyleCop.Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers)
