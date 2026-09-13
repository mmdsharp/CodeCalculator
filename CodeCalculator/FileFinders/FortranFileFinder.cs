// FortranFileFinder.cs

namespace CodeCalculator.FileFinders;

internal sealed class FortranFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "build",
            "bin",
            "obj",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "Makefile"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".mod",
            ".o",
            ".a"
        );
}
