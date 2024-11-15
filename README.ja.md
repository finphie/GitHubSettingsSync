# GitHubSettingsSync

[![Build(.NET)](https://github.com/finphie/GitHubSettingsSync/actions/workflows/build-dotnet.yml/badge.svg)](https://github.com/finphie/GitHubSettingsSync/actions/workflows/build-dotnet.yml)
[![NuGet](https://img.shields.io/nuget/v/GitHubSettingsSync?color=0078d4&label=NuGet)](https://www.nuget.org/packages/GitHubSettingsSync/)
[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/DotNet/Packages/f8147011-dc70-430b-ba72-56ee4008f90e/Badge)](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/GitHubSettingsSync?preferRelease=true)

GitHubの設定を同期するアプリケーションです。

## 説明

GitHubSettingsSyncは、GitHubリポジトリの設定を行うアプリケーションです。

- [アクション](https://github.com/marketplace/actions/github-settings-sync)
- [NuGet](https://www.nuget.org/packages/GitHubSettingsSync)
- [Azure Artifacts](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/GitHubSettingsSync?preferRelease=true)
- [バイナリ](https://github.com/finphie/GitHubSettingsSync/releases/latest)
- [Docker](https://github.com/finphie/GitHubSettingsSync/pkgs/container/git-hub-settings-sync)

## 使い方

### アクション

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
          repository: GitHubSettingsSync
          path: github-settings.json
        env:
          GITHUB_TOKEN: ${{ secrets.TOKEN }}
```

### .NETツール

```shell
GitHubSettingsSync \
    --repository GitHubSettingsSync \
    --path github-settings.json
```

## 引数

|引数|必須|デフォルト|説明|
|-|-|-|-|
|repository|**true**|-|「オーナー名/リポジトリ名」形式のリポジトリ名。|
|path|**true**|-|設定ファイルのファイルパス。|

## 環境変数

|変数名|必須|デフォルト|説明|
|-|-|-|-|
|GITHUB_TOKEN|**true**|-|Administrationに書き込み許可が付与されたトークン。|

## 設定ファイル

JSON形式のファイルです。値が`null`の場合やキーを省略することで、設定を変更せずに保持します。

### 設定例

```json
{
  "repository": {
    "security_and_analysis": {
      "secret_scanning": {
        "status": "enabled"
      },
      "secret_scanning_push_protection": {
        "status": "enabled"
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

### 設定詳細

#### リポジトリ設定

|キー|必須|デフォルト|説明|
|-|-|-|-|
|has_issues|false|null|Issuesを有効にするかどうか。|
|has_projects|false|null|Projectsを有効にするかどうか。|
|has_wiki|false|null|Wikiを有効にするかどうか。|
|has_discussions|false|null|Discussionsを有効にするかどうか。|
|allow_merge_commit|false|null|「Create a merge commit」を有効にするか。|
|allow_squash_merge|false|null|「Squash Merge」を有効にするかどうか。|
|allow_rebase_merge|false|null|「Rebase and Merge」を有効にするか。|
|allow_auto_merge|false|null|自動マージ機能を有効にするか。|
|delete_branch_on_merge|false|null|プルリクエストマージ時に、ブランチを自動的に削除するかどうか。|
|allow_update_branch|false|null|「Update branch」を有効にするかどうか。|
|merge_commit_title|false|null|マージにおけるコミットタイトルの種類。PR_TITLE/MERGE_MESSAGEのいずれか。PR_TITLEでは、merge_commit_messageにPR_BODYまたはBLANKを指定してください。MERGE_MESSAGEでは、merge_commit_messageにPR_TITLEを指定してください。|
|merge_commit_message|false|null|マージにおけるコミットメッセージの種類。PR_TITLE/PR_BODY/BLANKのいずれか。|
|squash_merge_commit_title|false|null|スカッシュマージにおけるコミットタイトルの種類。PR_TITLE/COMMIT_OR_PR_TITLEのいずれか。|
|squash_merge_commit_message|false|null|スカッシュマージにおけるコミットメッセージの種類。PR_BODY/COMMIT_MESSAGES/BLANKのいずれか。|

#### ブランチ保護設定

|キー|必須|デフォルト|説明|
|-|-|-|-|
|name|**true**|-|ブランチ保護の対象ブランチ名。|
|enforce_admins|false|null|ブランチ保護を管理者にも適用するか。|
|required_linear_history|false|null|直線状の履歴を必須にするかどうか。|
|allow_force_pushes|false|null|強制プッシュを許可するかどうか。|
|allow_deletions|false|null|プッシュアクセス権を持つユーザーが、保護されたブランチを削除できるようにするかどうか。|
|required_conversation_resolution|false|null|マージ前にコメントの解決を必須にするかどうか。|
|required_reviews|false|null|レビューを必須にするかどうか。|
|dismiss_stale_reviews|false|null|新しいコミットがプッシュされたときに、承認済みのレビューを却下するかどうか。|
|require_code_owner_reviews|false|null|コード所有者のレビューが必須かどうか。|
|required_approving_review_count|false|null|プルリクエストの承認に必要なレビュアーの数。|

## 作者

finphie

## ライセンス

MIT

## クレジット

このプロジェクトでは、次のライブラリ等を使用しています。

### ライブラリ

- [ConsoleAppFramework](https://github.com/Cysharp/ConsoleAppFramework)

### アナライザー

- [DocumentationAnalyzers](https://github.com/DotNetAnalyzers/DocumentationAnalyzers)
- [IDisposableAnalyzers](https://github.com/DotNetAnalyzers/IDisposableAnalyzers)
- [Microsoft.CodeAnalysis.NetAnalyzers](https://github.com/dotnet/roslyn-analyzers)
- [Microsoft.VisualStudio.Threading.Analyzers](https://github.com/Microsoft/vs-threading)
- [Roslynator.Analyzers](https://github.com/dotnet/roslynator)
- [Roslynator.Formatting.Analyzers](https://github.com/dotnet/roslynator)
- [StyleCop.Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers)
