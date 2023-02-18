namespace GitHubSettingsSync.Models;

/// <summary>
/// GitHub設定の更新に関する操作を定義するインターフェイスです。
/// </summary>
public interface IUpdateGitHubSettings
{
    /// <summary>
    /// エラーが発生したかどうかを取得します。
    /// </summary>
    /// <value>
    /// GitHub設定の更新を行う際に、エラーが発生した場合は<see langword="true"/>を返します。
    /// それ以外の場合は<see langword="false"/>を返します。
    /// </value>
    bool IsError { get; }

    /// <summary>
    /// GitHub設定の更新を行います。
    /// </summary>
    /// <param name="repositories">リポジトリ名または「オーナー名/リポジトリ名」形式の文字列のリスト。</param>
    /// <param name="settings">GitHubに関する設定。</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン。</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="repositories"/>または<paramref name="settings"/>がnullです。</exception>
    ValueTask ExecuteAsync(IEnumerable<string> repositories, GitHubSettings settings, CancellationToken cancellationToken = default);
}
