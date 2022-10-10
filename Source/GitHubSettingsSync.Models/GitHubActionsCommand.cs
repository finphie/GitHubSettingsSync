namespace GitHubSettingsSync.Models;

/// <summary>
/// GitHub Actions関連のコマンドです。
/// </summary>
static class GitHubActionsCommand
{
    /// <summary>
    /// 指定されたタイトルのグループを開始します。
    /// </summary>
    /// <param name="title">タイトル。</param>
    public static void GroupStart(string title) => Console.WriteLine($"::group::{title}");

    /// <summary>
    /// グループを終了します。
    /// </summary>
    public static void GroupEnd() => Console.WriteLine("::endgroup::");
}
