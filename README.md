# GitHubSettingsSync

[![Build(.NET)](https://github.com/finphie/GitHubSettingsSync/actions/workflows/build-dotnet.yml/badge.svg)](https://github.com/finphie/GitHubSettingsSync/actions/workflows/build-dotnet.yml)
[![NuGet](https://img.shields.io/nuget/v/GitHubSettingsSync?color=0078d4&label=NuGet)](https://www.nuget.org/packages/GitHubSettingsSync/)
[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/DotNet/Packages/f8147011-dc70-430b-ba72-56ee4008f90e/Badge)](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/GitHubSettingsSync?preferRelease=true)

GitHubの設定を同期するアプリケーションです。

## 説明

GitHubSettingsSyncは、GitHubリポジトリの設定を行うアプリケーションです。

- [GitHubアクション](https://github.com/marketplace/actions/github-settings-sync)
- [NuGet](https://www.nuget.org/packages/GitHubSettingsSync)
- [Azure Artifacts](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/GitHubSettingsSync?preferRelease=true)
- [バイナリ](https://github.com/finphie/GitHubSettingsSync/releases/latest)
- [Dockerイメージ](https://github.com/finphie/GitHubSettingsSync/pkgs/container/git-hub-settings-sync)

## 使い方

### GitHubアクション

```yaml
on:
  workflow_dispatch:

jobs:
  sync-github-settings:
    runs-on: ubuntu-latest

    steps:
      - name: GitHub Settings Sync
        uses: finphie/GitHubSettingsSync@v2.0.0
        with:
          repositories: |
            GitHubSettingsSync
          has-issues: Unchanged
          has-projects: Unchanged
          has-wiki: Unchanged
          has-discussions: Unchanged
          allow-merge-commit: Unchanged
          allow-squash-merge: Unchanged
          allow-rebase-merge: Unchanged
          allow-auto-merge: Unchanged
          delete-branch-on-merge: Unchanged
          allow-update-branch: Unchanged
          merge-commit-title: Unchanged
          merge-commit-message: Unchanged
          squash-merge-commit-title: Unchanged
          squash-merge-commit-message: Unchanged
          branch-protection: false
          branch-protection-name: main
          branch-protection-enforce-admins: false
          branch-protection-required-linear-history: false
          branch-protection-allow-force-pushes: false
          branch-protection-allow-deletions: false
          branch-protection-required-conversation-resolution: false
          branch-protection-required-reviews: false
          branch-protection-required-reviews-dismiss-stale-reviews: false
          branch-protection-required-reviews-require-code-owner-reviews: false
          branch-protection-required-reviews-required-approving-review-count: 1
        env:
          GITHUB_TOKEN: {{ secrets.PAT }}
```

### .NETツール

```shell
GitHubSettingsSync \
    --repositories GitHubSettingsSync \
    --has-issues Unchanged \
    --has-projects Unchanged \
    --has-wiki Unchanged \
    --has-discussions Unchanged \
    --allow-merge-commit Unchanged \
    --allow-squash-merge Unchanged \
    --allow-rebase-merge Unchanged \
    --allow-auto-merge Unchanged \
    --delete-branch-on-merge Unchanged \
    --allow-update-branch Unchanged \
    --merge-commit-title Unchanged \
    --merge-commit-message Unchanged \
    --squash-merge-commit-title Unchanged \
    --squash-merge-commit-message Unchanged \
    --branch-protection false \
    --branch-protection-name main \
    --branch-protection-enforce-admins false \
    --branch-protection-required-linear-history false \
    --branch-protection-allow-force-pushes false \
    --branch-protection-allow-deletions false \
    --branch-protection-required-conversation-resolution false \
    --branch-protection-required-reviews false \
    --branch-protection-required-reviews-dismiss-stale-reviews false \
    --branch-protection-required-reviews-require-code-owner-reviews false \
    --branch-protection-required-reviews-required-approving-review-count 1
```

## 引数

引数|必須|デフォルト|説明
-|-|-|-
repositories|**true**|-|カンマ・半角スペース・改行区切りにした「オーナー名/リポジトリ名」形式のリスト。オーナー名を省略した場合は、「GITHUB_REPOSITORY_OWNER」環境変数を使用。
has-issues|false|Unchanged|Issuesを有効にするかどうか。
has-projects|false|Unchanged|Projectsを有効にするかどうか。
has-wiki|false|Unchanged|Wikiを有効にするかどうか。
has-discussions|false|Unchanged|Discussionsを有効にするかどうか。
allow-merge-commit|false|Unchanged|「Create a merge commit」を有効にするか。
allow-squash-merge|false|Unchanged|「Squash Merge」を有効にするかどうか。
allow-rebase-merge|false|Unchanged|「Rebase and Merge」を有効にするか。
allow-auto-merge|false|Unchanged|自動マージ機能を有効にするか。
delete-branch-on-merge|false|Unchanged|プルリクエストマージ時に、ブランチを自動的に削除するかどうか。
allow-update-branch|false|Unchanged|「Update branch」を有効にするかどうか。
merge-commit-title|false|Unchanged|マージにおけるコミットタイトルの種類。Unchanged・PullRequestTitle・MergeMessageのいずれか。
merge-commit-message|false|Unchanged|マージにおけるコミットメッセージの種類。Unchanged・PullRequestTitle・PullRequestBody・Blankのいずれか。
squash-merge-commit-title|false|Unchanged|スカッシュマージにおけるコミットタイトルの種類。Unchanged・PullRequestTitle・CommitOrPullRequestTitleのいずれか。
squash-merge-commit-message|false|Unchanged|スカッシュマージにおけるコミットメッセージの種類。Unchanged・PullRequestBody・CommitMessages・Blankのいずれか。
branch-protection|false|Unchanged|ブランチ保護を有効にするかどうか。
branch-protection-name|false|main|ブランチ保護の対象ブランチ名。
branch-protection-enforce-admins|false|false|ブランチ保護を管理者にも適用するか。
branch-protection-required-linear-history|false|false|直線状の履歴を必須にするかどうか。
branch-protection-allow-force-pushes|false|false|強制プッシュを許可するかどうか。
branch-protection-allow-deletions|false|false|プッシュアクセス権を持つユーザーが、保護されたブランチを削除できるようにするかどうか。
branch-protection-required-conversation-resolution|false|false|マージ前にコメントの解決を必須にするかどうか。
branch-protection-required-reviews|false|false|レビューを必須にするかどうか。
branch-protection-required-reviews-dismiss-stale-reviews|false|false|新しいコミットがプッシュされたときに、承認済みのレビューを却下するかどうか。
branch-protection-required-reviews-require-code-owner-reviews|false|false|コード所有者のレビューが必須かどうか。
branch-protection-required-reviews-required-approving-review-count|false|1|プルリクエストの承認に必要なレビュアーの数。（1～6人）

## 環境変数

引数|必須|デフォルト|説明
-|-|-|-
GITHUB_TOKEN|**true**|-|public_repoスコープを許可したGitHub Personal Access Token。
GITHUB_REPOSITORY_OWNER|false|${{ github.repository_owner }}|GitHubオーナー名。

## 作者

finphie

## ライセンス

MIT

## クレジット

このプロジェクトでは、次のライブラリ等を使用しています。

### ライブラリ

- [ConsoleAppFramework](https://github.com/Cysharp/ConsoleAppFramework)
- [FToolkit](https://github.com/finphie/FToolkit)
- Microsoft.Extensions.Hosting
- Microsoft.Extensions.Http

### アナライザー

- [DocumentationAnalyzers](https://github.com/DotNetAnalyzers/DocumentationAnalyzers)
- [IDisposableAnalyzers](https://github.com/DotNetAnalyzers/IDisposableAnalyzers)
- [Microsoft.CodeAnalysis.NetAnalyzers](https://github.com/dotnet/roslyn-analyzers)
- [Microsoft.VisualStudio.Threading.Analyzers](https://github.com/Microsoft/vs-threading)
- [StyleCop.Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers)

### その他

- [Microsoft.SourceLink.GitHub](https://github.com/dotnet/sourcelink)
