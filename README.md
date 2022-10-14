# GitHubSettingsSync

[![Build(.NET)](https://github.com/finphie/GitHubSettingsSync/actions/workflows/build-dotnet.yml/badge.svg)](https://github.com/finphie/GitHubSettingsSync/actions/workflows/build-dotnet.yml)

GitHubの設定を同期するGitHub Actionsです。

## 説明

GitHubSettingsSyncは、GitHubリポジトリの設定を行うGitHub Actionsです。C#/.NET 7で実装しています。

## 使い方

```yml
on:
  workflow_dispatch:

jobs:
  sync-github-settings:
    runs-on: ubuntu-latest

    steps:
      - uses: actions/checkout@v3
      - name: GitHub Settings Sync
        uses: finphie/git-hub-settings-sync@main
        with:
          repositories: |
            GitHubSettingsSync
          has-issues: true
          has-projects: true
          has-wiki: true
          allow-merge-commit: true
          allow-rebase-merge: true
          allow-squash-merge: true
          allow-auto-merge: false
          delete-branch-on-merge: false
          allow-update-branch: false
          branch-protection: false
          branch-protection-name: main
          branch-protection-enforce-admins: false
          branch-protection-required-linear-history: false
          branch-protection-allow-force-pushes: false
          branch-protection-allow-deletions: false
          branch-protection-required-conversation-resolution: false
          branch-protection-required-status-checks-strict: false
          branch-protection-required-status-checks-contexts: null
          branch-protection-required-reviews: false
          branch-protection-required-reviews-dismiss-stale-reviews: false
          branch-protection-required-reviews-require-code-owner-review: false
          branch-protection-required-reviews-required-approving-review-count: 1
```

## 引数

引数|必須|デフォルト|説明
-|-|-|-
repositories|**true**|-|カンマ・半角スペース・改行区切りにしたリポジトリ名のリスト。
has-issues|false|true|Issuesを有効にするかどうか。
has-projects|false|true|Projectsを有効にするかどうか。
has-wiki|false|true|Wikiを有効にするかどうか。
allow-merge-commit|false|true|「Create a merge commit」を有効にするか。
allow-rebase-merge|false|true|「Rebase and Merge」を有効にするか。
allow-squash-merge|false|true|「Squash Merge」を有効にするかどうか。
allow-auto-merge|false|false|自動マージ機能を有効にするか。
delete-branch-on-merge|false|false|プルリクエストマージ時に、ブランチを自動的に削除するかどうか。
allow-update-branch|false|false|「Update branch」を有効にするかどうか。
branch-protection|false|false|ブランチ保護を有効にするかどうか。
branch-protection-name|false|main|ブランチ保護の対象ブランチ名。
branch-protection-enforce-admins|false|false|ブランチ保護を管理者にも適用するか。
branch-protection-required-linear-history|false|false|直線状の履歴を必須にするかどうか。
branch-protection-allow-force-pushes|false|false|強制プッシュを許可するかどうか。
branch-protection-allow-deletions|false|false|プッシュアクセス権を持つユーザーが、保護されたブランチを削除できるようにするかどうか。
branch-protection-required-conversation-resolution|false|false|マージ前にコメントの解決を必須にするかどうか。
branch-protection-required-status-checks-strict|false|false|マージする前にブランチを最新にする必要があるかどうか。
branch-protection-required-status-checks-contexts|false|null|合格する必要があるステータスチェックのリスト。
branch-protection-required-reviews|false|false|レビューを必須にするかどうか。
branch-protection-required-reviews-dismiss-stale-reviews|false|false|新しいコミットがプッシュされたときに、承認済みのレビューを却下するかどうか。
branch-protection-required-reviews-require-code-owner-review|false|false|コード所有者のレビューが必須かどうか。
branch-protection-required-reviews-required-approving-review-count|false|1|プルリクエストの承認に必要なレビュアーの数。（1～6人）

## 作者

finphie

## ライセンス

MIT

## クレジット

このプロジェクトでは、次のライブラリ等を使用しています。

### ライブラリ

- [CommunityToolkit.Diagnostics](https://github.com/CommunityToolkit/dotnet)
- [ConsoleAppFramework](https://github.com/Cysharp/ConsoleAppFramework)
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.DependencyInjection
- Microsoft.Extensions.Hosting
- Microsoft.Extensions.Logging
- Microsoft.Extensions.Options
- [Octokit](https://github.com/octokit/octokit.net)

### アナライザー

- Microsoft.CodeAnalysis.NetAnalyzers (SDK組み込み)
- [Microsoft.VisualStudio.Threading.Analyzers](https://github.com/Microsoft/vs-threading)
- [StyleCop.Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers)
