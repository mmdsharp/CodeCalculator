// MATLABFileFinder.cs

namespace CodeCalculator.FileFinders;

internal sealed class MATLABFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            "slprj",
            "codegen",
            "work",
            "build"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "matlab.prj"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".mat",
            ".mex",
            ".mexw64",
            ".mexw32",
            ".mexmaci64"
        );
}
