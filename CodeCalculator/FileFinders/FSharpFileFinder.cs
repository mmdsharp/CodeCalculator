// FSharpFileFinder.cs

namespace CodeCalculator.FileFinders;

internal sealed class FSharpFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "bin",
            "obj",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            "packages",
            "TestResults"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "paket.lock",
            "paket-files"
        );
}
