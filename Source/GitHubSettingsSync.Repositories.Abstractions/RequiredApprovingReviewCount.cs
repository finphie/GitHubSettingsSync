using CommunityToolkit.Diagnostics;

namespace GitHubSettingsSync.Repositories;

/// <summary>
/// プルリクエストの承認に必要なレビュアーの数。
/// </summary>
public readonly struct RequiredApprovingReviewCount
{
    /// <summary>
    /// <see cref="RequiredApprovingReviewCount"/>構造体の新しいインスタンスを初期化します。
    /// </summary>
    public RequiredApprovingReviewCount() => Value = 1;

    /// <summary>
    /// <see cref="RequiredApprovingReviewCount"/>構造体の新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="value">値</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/>が1～6の範囲ではありません。</exception>
    public RequiredApprovingReviewCount(int value)
    {
        Guard.IsInRange(value, 1, 7);
        Value = value;
    }

    /// <summary>
    /// デフォルトのレビュアー数を返します。
    /// </summary>
    /// <value>
    /// デフォルトは1人です。
    /// </value>
    public static RequiredApprovingReviewCount Default => new();

    /// <summary>
    /// レビュアーの数を取得します。
    /// </summary>
    /// <value>
    /// レビュアーの数（1～6人）を返します。
    /// </value>
    public int Value { get; }
}
