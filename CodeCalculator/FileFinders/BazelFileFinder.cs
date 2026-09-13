// BazelFileFinder.cs

namespace CodeCalculator.FileFinders;

internal sealed class BazelFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "bazel-bin",
            "bazel-out",
            "bazel-testlogs",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "MODULE.bazel.lock"
        );
}
