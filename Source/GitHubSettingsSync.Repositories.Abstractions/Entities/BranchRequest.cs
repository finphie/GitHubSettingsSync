using System.Diagnostics.CodeAnalysis;

namespace GitHubSettingsSync.Repositories.Entities;

/// <summary>
/// ブランチ情報を表すクラスです。
/// </summary>
/// <param name="Owner">オーナー名。</param>
/// <param name="Name">リポジトリ名。</param>
/// <param name="Branch">ブランチ名。</param>
public record BranchRequest(string Owner, string Name, string Branch) : IRequest;

/// <summary>
/// ブランチ情報を表すクラスです。
/// </summary>
/// <typeparam name="T">設定の型。</typeparam>
/// <param name="Owner">オーナー名。</param>
/// <param name="Name">リポジトリ名。</param>
/// <param name="Branch">ブランチ名。</param>
/// <param name="Settings">設定。</param>
[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "可読性のため。")]
public sealed record BranchRequest<T>(string Owner, string Name, string Branch, T Settings) : BranchRequest(Owner, Name, Branch), IRequest<T>
    where T : notnull;
