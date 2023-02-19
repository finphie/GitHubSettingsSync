using GitHubSettingsSync.Services.Settings;

namespace GitHubSettingsSync.Extensions;

/// <summary>
/// パラメーター関連の拡張メソッドです。
/// </summary>
static class ParameterExtensions
{
    /// <summary>
    /// <see cref="BooleanParameter"/>型を<see cref="Status"/>型に変換します。
    /// </summary>
    /// <param name="parameter">パラメーターの値。</param>
    /// <returns>
    /// <see cref="BooleanParameter.Unchanged"/>の場合は<see cref="Status.Unchanged"/>を返します。
    /// <see cref="BooleanParameter.True"/>の場合は<see cref="Status.Enabled"/>を返します。
    /// <see cref="BooleanParameter.False"/>の場合は<see cref="Status.Disabled"/>を返します。
    /// </returns>
    public static Status ToStatus(this BooleanParameter parameter)
    {
        return parameter switch
        {
            BooleanParameter.Unchanged => Status.Unchanged,
            BooleanParameter.True => Status.Enabled,
            BooleanParameter.False => Status.Disabled,
            _ => Status.Unchanged
        };
    }
}
