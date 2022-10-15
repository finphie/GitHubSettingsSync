namespace GitHubSettingsSync.Models.Helpers;

/// <summary>
/// GitHubリポジトリ関連のヘルパークラスです。
/// </summary>
static class GitHubRepositoryHelper
{
    /// <summary>
    /// オーナー名とリポジトリ名を取得します。
    /// </summary>
    /// <param name="repository">リポジトリ名または「オーナー名/リポジトリ名」形式の文字列。</param>
    /// <param name="defaultOwner">デフォルトのオーナー名。</param>
    /// <returns>オーナー名とリポジトリ名をタプルで返します。オーナー名が取得できなかった場合は、<paramref name="defaultOwner"/>がオーナー名となります。</returns>
    public static (string Owner, string RepositoryName) GetOwnerAndRepositoryName(string repository, string? defaultOwner = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(repository);

        var array = repository.Split('/', 2);

        if (array.Length < 2)
        {
            ArgumentException.ThrowIfNullOrEmpty(defaultOwner);
            return (defaultOwner, repository);
        }

        var owner = array[0];
        var repositoryName = array[1];

        ArgumentException.ThrowIfNullOrEmpty(owner);
        ArgumentException.ThrowIfNullOrEmpty(repositoryName);

        return (owner, repositoryName);
    }
}
