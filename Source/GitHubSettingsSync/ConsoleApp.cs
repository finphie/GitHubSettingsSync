using System.Diagnostics.CodeAnalysis;

namespace ConsoleAppFramework;

/// <summary>
/// コンソールアプリケーションを提供します。
/// </summary>
[UnconditionalSuppressMessage("Trimming", "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code", Justification = "引数に配列を使わないので問題ない")]
[UnconditionalSuppressMessage("AOT", "IL3050:Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.", Justification = "引数に配列を使わないので問題ない")]
partial class ConsoleApp;
